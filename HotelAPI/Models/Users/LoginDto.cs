using System.ComponentModel.DataAnnotations;


namespace HotelAPI.Models.Users
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your password limited to {2} to {1} charactoers", MinimumLength = 6)]
        public string Password { get; set; }

    }
}
