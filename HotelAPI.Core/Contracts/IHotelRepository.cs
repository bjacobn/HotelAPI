using HotelAPI.Data;
using HotelAPI.Core.Models.Hotels;
using HotelAPI.Core.Contracts;

namespace HotelAPI.Core.Contracts
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
    }
}
