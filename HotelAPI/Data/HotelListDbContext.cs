using HotelAPI.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Data
{
    public class HotelListDbContext : IdentityDbContext<ApiUser>
    {
        public HotelListDbContext(DbContextOptions options) : base(options)
        {
         
        }

        //Entities
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        
        //Seed Data 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            //Points to Configuraiton folder
            modelBuilder.ApplyConfiguration(new RoleConfiguration());        
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
        }
    }   
}
