using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Data
{
    public class HotelListDbContext : DbContext
    {
        public HotelListDbContext(DbContextOptions options) : base(options)
        {
         
        }

        //Entities
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        
        //Seed Data Method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //Countries
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Jamaica",
                    ShortName = "JM"
                },
               new Country
               {
                   Id = 2,
                   Name = "Bahamas",
                   ShortName = "BS"
               },
               new Country
               {
                   Id = 3,
                   Name = "Cayman Island",
                   ShortName = "CI"
               }

              );


            //Hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sandals Resort",
                    Address = "Negril",
                    Rating = 4.5,
                    CountryId = 1

                },
               new Hotel
               {
                   Id = 2,
                   Name = "Comfort Suites",
                   Address = "George Town",
                   Rating = 4.3,
                   CountryId = 3
               },
               new Hotel
               {
                   Id = 3,
                   Name = "Grand Palldium ",
                   Address = "Negril",
                   Rating = 5,
                   CountryId = 1
               }

             );
        }
    }   
}
