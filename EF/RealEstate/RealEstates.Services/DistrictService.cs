using AutoMapper.QueryableExtensions;
using RealEstates.Data;
using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services
{
    public class DistrictService : BaseService, IDistrictService
    {
        private readonly ApplicationDbContext dbContext;
        public DistrictService(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            var districts = dbContext
                .Districts      
                .ProjectTo<DistrictInfoDto>(Mapper.ConfigurationProvider)
                //.Select(q=>new DistrictInfoDto
                //{
                //    Name = q.Name,
                //    AveragePricePersquareMeter = q.Properties.Where(r=>r.Price.HasValue).Average(w=>w.Price/(decimal)w.Size) ??0,
                //    PropertyCount = q.Properties.Count
                //})
                .OrderByDescending(p=>p.AveragePricePersquareMeter)
                .Take(count)
                .ToList();
            return districts;
        }
    }
}
