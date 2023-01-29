using HotelAPI.Data;

namespace HotelAPI.Core.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetials(int id);
    }
}
