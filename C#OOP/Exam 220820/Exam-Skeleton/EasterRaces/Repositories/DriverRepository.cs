using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> drivers;

        public DriverRepository()
        {
            drivers = new List<IDriver>();
        }
        public List<IDriver> Models => drivers;
        public void Add(IDriver model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return Models;
        }

        public IDriver GetByName(string name)
        {
            return Models.Where(x => x.Name == name).FirstOrDefault();
        }

        public bool Remove(IDriver model)
        {
            return Models.Remove(model);
        }
    }
}
