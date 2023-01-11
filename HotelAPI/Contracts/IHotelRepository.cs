using HotelAPI.Data;
using HotelAPI.Models.Hotels;
using HotelAPI.Contracts;

namespace HotelAPI.Contracts
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
    }
}
