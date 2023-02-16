using AutoMapper;
using RollOffFormApi.DTO;
using RollOffFormApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffFormApi.Profiles
{
    public class RolloffProfile : Profile
    {
        public RolloffProfile()
        {
            CreateMap<MyDatum, MyDatumDTO>().ReverseMap();
        }
    }
}
