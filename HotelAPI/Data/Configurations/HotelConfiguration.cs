using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        //Interface builds configuraiton
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
