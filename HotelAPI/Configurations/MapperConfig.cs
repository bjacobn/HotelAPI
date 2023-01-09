using AutoMapper;
using HotelAPI.Data;
using HotelAPI.Models.Country;
using HotelAPI.Models.Hotels;

namespace HotelAPI.Configurations
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
        }
    }
}
