using HotelAPI.Data;
using HotelAPI.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using AutoMapper;

namespace HotelAPI.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListDbContext _context;

        public CountriesRepository(HotelListDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public async Task<Country> GetDetials(int id)
        {
            //Go to Countries, include all Hotels, and get first record with Id record passed in
            //FirstOrdDefualt returns null if not found
            return await _context.Countries.Include(q => q.Hotels)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
