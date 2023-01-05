﻿using HotelAPI.Models.Hotels;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models.Country
{
    //GET
    public class GetCountryDto : BaseCountryDto
    {    
        public int Id { get; set; }     
    }  
}
