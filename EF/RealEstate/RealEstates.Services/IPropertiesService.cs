using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services
{
    public interface IPropertiesService
    {
        void Add(int Size, int YardSize, int Floor, int TotalFloors, string District, int year, int Price, string PropertyType, string BuildingType);
        decimal AveragePrice();
        decimal AveragePrice(int districtId);
        decimal AverageSize(int districtId);
        IEnumerable<PropertyInfoFullData> GetFulldata(int count);
        IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize);


    }
}
