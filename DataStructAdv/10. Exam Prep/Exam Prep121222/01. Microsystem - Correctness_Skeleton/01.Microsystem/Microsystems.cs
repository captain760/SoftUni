namespace _01.Microsystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Microsystems : IMicrosystem
    {
        private Dictionary<int, Computer>ms = new Dictionary<int, Computer>();

        public void CreateComputer(Computer computer)
        {
           if (ms.ContainsKey(computer.Number))
            {
                throw new ArgumentException();
            }
            ms.Add(computer.Number, computer);
        }

        public bool Contains(int number)
        {
            return ms.ContainsKey(number);
        }

        public int Count()
        {
            return ms.Count;
        }

        public Computer GetComputer(int number)
        {
            if (!ms.ContainsKey(number))
            {
                throw new ArgumentException();
            }
            return ms[number];
        }

        public void Remove(int number)
        {
            if (!ms.ContainsKey(number))
            {
                throw new ArgumentException();
            }
            ms.Remove(number);
        }

        public void RemoveWithBrand(Brand brand)
        {
            bool containsBrand = false;
            foreach (var pc in ms.Values)
            {
                if (pc.Brand == brand)
                {
                    ms.Remove(pc.Number);
                    containsBrand = true;
                }
            }
            if (!containsBrand)
            {
                throw new ArgumentException();
            }            
        }

        public void UpgradeRam(int ram, int number)
        {
            if (!ms.ContainsKey(number))
            {
                throw new ArgumentException();
            }
            if (ms[number].RAM < ram)
            {
                ms[number].RAM = ram;
            }
        }

        public IEnumerable<Computer> GetAllFromBrand(Brand brand)
        {
            return ms.Values.Where(pc=>pc.Brand.Equals(brand)).OrderByDescending(x=>x.Price);
        }

        public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
        {
            return ms.Values.Where(pc => pc.ScreenSize == screenSize).OrderByDescending(pc => pc.Number);
        }

        public IEnumerable<Computer> GetAllWithColor(string color)
        {
            return ms.Values.Where(pc => pc.Color == color).OrderByDescending(pc => pc.Price);
        }

        public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
        {
            return ms.Values.Where(pc => pc.Price >= minPrice && pc.Price<=maxPrice).OrderByDescending(pc => pc.Price);
        }
    }
}
