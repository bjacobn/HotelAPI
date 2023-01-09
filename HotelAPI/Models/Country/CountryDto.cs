using HotelAPI.Models.Hotels;
using System.Text.Json.Serialization;

namespace HotelAPI.Models.Country
{
    public class CountryDto : BaseCountryDto
    {
        public int Id { get; set; }
        [JsonPropertyOrder (3)]
        public List<HotelDto> Hotels { get; set; }
    }
}
