using Newtonsoft.Json;
using RealEstates.Data;
using RealEstates.Services;

namespace RealEstates.Importer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new ApplicationDbContext();
            IPropertiesService propertyService = new PropertyService(dbContext);
            var props = JsonConvert.DeserializeObject<IEnumerable<PropsAsJsonDto>>(File.ReadAllText("../../../Imoti.json"));
            foreach (var jsonProp in props)
            {
                propertyService.Add(jsonProp.Size, jsonProp.YardSize, jsonProp.Floor, jsonProp.TotalFloors, jsonProp.District, jsonProp.Year, jsonProp.Price, jsonProp.Type, jsonProp.BuildingType);
                Console.Write(".");
            }

        }
    }
}