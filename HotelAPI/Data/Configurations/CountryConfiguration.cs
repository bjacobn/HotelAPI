using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        //Interface builds configuraiton
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}
