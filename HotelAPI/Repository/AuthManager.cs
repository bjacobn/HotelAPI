using HotelAPI.Models.Users;
using HotelAPI.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using HotelAPI.Data;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Azure.Core;
using ServiceStack.Web;

namespace HotelAPI.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApiUser _user;

        private const string _loginProvider = "HotelListingApi";
        private const string _refreshToken = "RefreshToken";


        public AuthManager(IMapper mapper, UserManager<ApiUser> userManger, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManger;
            _configuration = configuration;
        }


        //CREATE TOKEN ----------------------

        public async Task<string> CreateRefreshToken()
        {
            //Remove Token
            await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);

            //Create new one
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);

            //Store it in db
            var result = await _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newRefreshToken);

            
            return newRefreshToken;

        }


        //LOGIN  -------------------------

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {


            //Get user with email address
            _user = await _userManager.FindByEmailAsync(loginDto.Email);


            //Validate password and email provided belongs to user
            bool isValidUser = await _userManager.CheckPasswordAsync(_user, loginDto.Password);

            if (_user == null || isValidUser == false)
            {
                return null;
            }

            var token = await GenerateToken();
            return new AuthResponseDto
            {
                Token = token,
                UserId = _user.Id,
                RefreshToken = await CreateRefreshToken()
            };

        }


        //REGISTER ---------------------

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
        {
            //Map it
            _user = _mapper.Map<ApiUser>(userDto);

            //Check for same value
            _user.UserName = userDto.Email;

            //Try create user with password entered
            var result = await _userManager.CreateAsync(_user, userDto.Password);

            //Add to roles if succesful
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(_user, "User");
            }


            //
            return result.Errors;
        }

        //VERIFY TOKEN ------------------------

        public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            //Get token that came in with the request
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);

            //Find username in the token
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;

            //Get user with that username
            _user = await _userManager.FindByNameAsync(username);

            //Check user exists
            if (_user == null || _user.Id != request.UserId)
            {
                return null;
            }

            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user, _loginProvider, _refreshToken, request.RefreshToken);

            if (isValidRefreshToken)
            {
                var token = await GenerateToken();
                return new AuthResponseDto
                {
                    Token = token,
                    UserId = _user.Id,
                    RefreshToken = await CreateRefreshToken()
                };
            }

            //
            await _userManager.UpdateSecurityStampAsync(_user);
            return null;
        }


        //GENERATE TOKEN----------------------

        private async Task<string> GenerateToken()
        {
            //Reads from appseetings
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));


            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            //Gets roles user has
            var roles = await _userManager.GetRolesAsync(_user);

            //
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            var userClaims = await _userManager.GetClaimsAsync(_user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),

            }
            .Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );

            //Coverts above token to flat string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
