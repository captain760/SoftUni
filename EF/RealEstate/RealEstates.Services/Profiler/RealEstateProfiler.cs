using AutoMapper;
using RealEstates.Models;
using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services.Profiler
{
    public class RealEstateProfiler:Profile
    {
        public RealEstateProfiler()
        {
            this.CreateMap<Property, PropertyInfoDto>()
                .ForMember(x=>x.BuildingType, y=>y.MapFrom(s=>s.BuildingType.Name))
                .ForMember(x=>x.PropertyType, y=>y.MapFrom(s=>s.PropertyType.Name));
            this.CreateMap<District, DistrictInfoDto>()
                .ForMember(x => x.AveragePricePersquareMeter, y => y.MapFrom(s => s.Properties.Where(r => r.Price.HasValue).Average(w => w.Price / (decimal)w.Size ?? 0)));
            this.CreateMap<Property, PropertyInfoFullData>()
                .ForMember(x => x.BuildingType, y => y.MapFrom(s => s.BuildingType.Name))
                .ForMember(x => x.PropertyType, y => y.MapFrom(s => s.PropertyType.Name)); 
            this.CreateMap<Tag, TagDto>();
        }
    }
}
