using Microsoft.Build.Framework;

namespace HotelAPI.Models.Country
{
    //Abstract class can't instiatnt but used for inheritance purpososes
    public abstract  class BaseCountryDto
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }

    }
}
