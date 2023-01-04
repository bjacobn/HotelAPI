using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Data
{
    public class HotelListDbContext : DbContext
    {
        public HotelListDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
