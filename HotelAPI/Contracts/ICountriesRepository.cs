using HotelAPI.Data;

namespace HotelAPI.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetials(int id);
    }
}
