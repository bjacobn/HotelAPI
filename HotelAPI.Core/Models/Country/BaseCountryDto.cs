using Microsoft.Build.Framework;
using System.Text.Json.Serialization;

namespace HotelAPI.Core.Models.Country
{
    //Abstract class can't instiatnt but used for inheritance purpososes
    public abstract class BaseCountryDto
    {
        [JsonPropertyOrder(1)]
        [Required]
        public string Name { get; set; }
        [JsonPropertyOrder(2)]  
        public string ShortName { get; set; }
    }
}
