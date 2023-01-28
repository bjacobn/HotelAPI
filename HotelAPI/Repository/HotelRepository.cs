﻿using AutoMapper;
using HotelAPI.Contracts;
using HotelAPI.Data;

namespace HotelAPI.Repository
{
    //Inherits from both class and interface
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        private readonly IMapper _mapper;

        //Daisy chain Dbcontext down to base
        public HotelRepository(HotelListDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }
    }
}
