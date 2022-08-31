using RealEstates.Data;
using RealEstates.Models;


namespace RealEstates.Services
{
    public class TagService : BaseService, ITagService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IPropertiesService propertiesService;

        public TagService(ApplicationDbContext dbContext,IPropertiesService propertiesService)
        {
            this.dbContext = dbContext;
            this.propertiesService = propertiesService;
        }
        public void Add(string name, int? importance = null)
        {
            var tag = new Tag
            {
                Name = name,
                Importance = importance
            };
            dbContext.Tags.Add(tag);
            dbContext.SaveChanges();

        }
        public void BulkTagToProperties()
        {
            
            
            var allProperties = dbContext.Properties.ToList();
            foreach (var prop in allProperties)
            {
                //Expensive - Cheap
                var avgPriceForDistrict = this.propertiesService.AveragePrice(prop.DistrictId);
                if (prop.Price.HasValue && prop.Price > avgPriceForDistrict)
                {
                    Tag tag = GetTag("Expensive");
                    prop.Tags.Add(tag);
                }

                else if (prop.Price.HasValue && prop.Price <= avgPriceForDistrict)
                {
                    var tag = GetTag("Cheap");
                    prop.Tags.Add(tag);
                }
                

                // newBuild - Old

                var limitingYear = DateTime.Now.AddYears(-25).Year;
                if (prop.Year.HasValue && prop.Year <= limitingYear)
                {
                    var tag = GetTag("Old");
                    prop.Tags.Add(tag);
                }

                else if (prop.Year.HasValue && prop.Year > limitingYear)
                {
                    var tag = GetTag("NewBuild");
                    prop.Tags.Add(tag);
                }

                // Big - Small
                var avgSize = this.propertiesService.AverageSize(prop.DistrictId);
                if (prop.Size > avgSize)
                {
                    var tag = GetTag("Big");
                    prop.Tags.Add(tag);
                }

                else if (prop.Size <= avgSize)
                {
                    var tag = GetTag("Small");
                    prop.Tags.Add(tag);
                }

                //LastFloor - FirstFloor

                if (prop.Floor.HasValue && prop.Floor.Value != 0 && prop.TotalFloors.HasValue && prop.Floor.Value == prop.TotalFloors.Value)
                {
                    var tag = GetTag("LastFloor");
                    prop.Tags.Add(tag);
                }

                else if (prop.Floor.HasValue && prop.Floor.Value == 1)
                {
                    var tag = GetTag("FirstFloor");
                    prop.Tags.Add(tag);
                }

                //top Imot

                if (prop.Price.HasValue && prop.Price <= avgPriceForDistrict && prop.Size > avgSize && (prop.Floor > 1 && prop.Floor < prop.TotalFloors))
                {
                    var tag = GetTag("Топ Имот");
                    prop.Tags.Add(tag);
                }
                Console.Write(".");
                
            }
            dbContext.SaveChanges();
        }

        private Tag GetTag(string v) => dbContext.Tags.FirstOrDefault(x => x.Name == v);
    }
}
