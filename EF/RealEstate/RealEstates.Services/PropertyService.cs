using AutoMapper;
using AutoMapper.QueryableExtensions;

using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services
{
    public class PropertyService : BaseService, IPropertiesService
    {
        private readonly ApplicationDbContext dbContext;
        
        public PropertyService(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        public void Add(int size, int yardSize, int floor, int totalFloors, string district, int year, int price, string propertyType, string buildingType)
        {
            var property = new Property
            {
                Size = size,
                YardSize = yardSize<=0?null:yardSize,
                Floor = floor <= 0 || floor>255? null : floor,
                TotalFloors = totalFloors <= 0 || totalFloors>255 ? null : totalFloors,
                Year = year<1800?null:year,
                Price = price<=0?null:price,
            };
            var dbDistrict = dbContext.Districts.FirstOrDefault(x => x.Name == district);
            if (dbDistrict == null)
            {
                dbDistrict = new District { Name = district };
                            
            }
            property.District = dbDistrict;

            var dbPropType = dbContext.PropertyTypes.FirstOrDefault(x => x.Name == propertyType);
            if (dbPropType == null)
            {
                dbPropType = new PropertyType { Name = propertyType };
                
            }
            property.PropertyType = dbPropType;

            var dbBuildType = dbContext.BuildingTypes.FirstOrDefault(x => x.Name == buildingType);
            if (dbBuildType == null)
            {
                dbBuildType = new BuildingType { Name = buildingType };
                
            }
            property.BuildingType = dbBuildType;

            dbContext.Properties.Add(property);
            dbContext.SaveChanges();
        }

        public decimal AveragePrice()
        {
            decimal avg = dbContext.Properties.Where(x=>x.Price.HasValue).Average(q => q.Price / (decimal)q.Size) ?? 0;
            return avg;
        }

        public decimal AveragePrice(int districtId)
        {
            decimal avg = dbContext.Properties.Where(x => x.Price.HasValue && x.District.Id == districtId).Average(q => q.Price / (decimal)q.Size) ?? 0;
            return avg;
        }

        public decimal AverageSize(int districtId)
        {
            decimal avg = (decimal)dbContext.Properties.Where(x => x.District.Id == districtId).Average(q => q.Size);
            return avg;
        }

        public IEnumerable<PropertyInfoFullData> GetFulldata(int count)
        {
            //Year>2015 middle Floor

            var props = dbContext.Properties
                .Where(x => x.Floor.HasValue && x.Floor.Value > 2 && x.Floor.Value < 6 && x.Year.HasValue && x.Year>2015)
                .ProjectTo<PropertyInfoFullData>(Mapper.ConfigurationProvider)
                .OrderBy(x=>x.Price)
                .ThenBy(x=>x.Size)
                .ThenBy(x=>x.Year)
                .Take(count)
                .ToList();
            return props;
        }

        public IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize)
        {
           
            var properties = dbContext
                .Properties
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice && x.Size >= minSize && x.Size <= maxSize)
                .ProjectTo<PropertyInfoDto>(Mapper.ConfigurationProvider)
                //.Select(x=>new PropertyInfoDto
                //{
                //    Size = x.Size,
                //    DistrictName = x.District.Name,
                //    BuildingType = x.BuildingType.Name,
                //    PropertyType = x.PropertyType.Name,
                //    Price = x.Price ?? 0
                //})
                .ToList();

            return properties;
        }
    }
}
