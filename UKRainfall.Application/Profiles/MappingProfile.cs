using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKRainfall.Application.Features.Readings;
using UKRainfall.Application.Models.Reading;
using AutoMapper;

namespace UKRainfall.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reading, ReadingListVm>().ReverseMap();
        }                
    }
}
