﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelAPI.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        //Interface builds configuraiton
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
             builder.HasData(
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                 new IdentityRole
                 {
                     Name = "User",
                     NormalizedName = "USER"
                 }

                );
        }
    }
}
