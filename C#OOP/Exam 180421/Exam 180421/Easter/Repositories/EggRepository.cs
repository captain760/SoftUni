using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs;
        public EggRepository()
        {
            eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => eggs;

        public void Add(IEgg model)
        {
            eggs.Add(model);
        }

        public IEgg FindByName(string name)
        {
            return eggs.Where(x => x.Name == name).FirstOrDefault();
        }

        public bool Remove(IEgg model)
        {
            return eggs.Remove(model);
        }
    }
}
