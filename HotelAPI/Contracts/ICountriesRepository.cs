using HotelAPI.Data;

namespace HotelAPI.Repositories
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetials(int id);
    }
}
