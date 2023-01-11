using HotelAPI.Contracts;
using HotelAPI.Data;

namespace HotelAPI.Repository
{
    //Inherits from both class and interface
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        //Daisy chain Dbcontext down to base
        public HotelRepository(HotelListDbContext context) : base(context)
        {
        }
    }
}
