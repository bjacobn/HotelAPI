using AutoMapper;
using HotelAPI.Data;
using HotelAPI.Core.Models.Country;
using HotelAPI.Core.Models.Hotels;
using HotelAPI.Core.Models.Users;

namespace HotelAPI.Core.Configurations
{
    public class MapperConfig : Profile
    {
        //Create maps between data types
        public MapperConfig()
        {
            //Map both direction
            //Copies respective field data between 2 objects
            CreateMap<Country, CreateCountryDto>().ReverseMap();   
            CreateMap<Country, GetCountryDto>().ReverseMap();   
            CreateMap<Country, CountryDto>().ReverseMap();   
            CreateMap<Country, UpdateCountryDto>().ReverseMap();
            
            CreateMap<Hotel, HotelDto>().ReverseMap();   
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            
            CreateMap<ApiUserDto, ApiUser>().ReverseMap();   
        }
    }
}
