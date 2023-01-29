using HotelAPI.Core.Models.Hotels;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Core.Models.Country
{
    //GET
    public class GetCountryDto : BaseCountryDto
    {    
        public int Id { get; set; }     
    }  
}
