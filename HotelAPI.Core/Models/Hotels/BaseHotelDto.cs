using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Core.Models.Hotels
{
    
    public abstract class BaseHotelDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        // ? Not required
        public double? Rating { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CountryId { get; set; }
    }
}
