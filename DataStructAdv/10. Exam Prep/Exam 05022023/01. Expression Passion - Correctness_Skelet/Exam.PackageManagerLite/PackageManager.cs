using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Exam.PackageManagerLite
{
    public class PackageManager : IPackageManager
    {
        private Dictionary<string, Package> packages = new Dictionary<string, Package>();
        
        public void AddDependency(string packageId, string dependencyId)
        {
            if (!packages.ContainsKey(packageId) || !packages.ContainsKey(dependencyId))
            {
                throw new ArgumentException();
            }
            packages[dependencyId].Parent = packages[packageId];
            packages[packageId].Children.Add(packages[dependencyId]);
            
        }

        public bool Contains(Package package)
        {
            return packages.ContainsKey(package.Id);
        }

        public int Count()=>packages.Count;

        public IEnumerable<Package> GetDependants(Package package)
        {
            if (!packages.ContainsKey(package.Id))
            {
                throw new ArgumentException();
            }
            var p = packages.Values.Where(p=>p.Children.Contains(package));
            return p;
        }

        public IEnumerable<Package> GetIndependentPackages()
        {
            return packages.Values.Where(x=>x.Children.Count==0).OrderByDescending(p=>p.ReleaseDate).ThenBy(p=>p.Version);
        }

        public IEnumerable<Package> GetOrderedPackagesByReleaseDateThenByVersion()
        {
            var pack = packages.Values.GroupBy(p => p.Name).Select(g=>g.OrderByDescending(x=>x.Version).First());
            return pack.OrderByDescending(p => p.ReleaseDate).ThenBy(x=>x.Version);
        }

        public void RegisterPackage(Package package)
        {
            foreach (var pack in packages.Values)
            {
                if (pack.Name == package.Name && pack.Version==package.Version)
                {
                    throw new ArgumentException();
                }
            }
            packages.Add(package.Id, package);
            
        }

        public void RemovePackage(string packageId)
        {
            if (!packages.ContainsKey(packageId))
            {
                throw new ArgumentException();
            }
            var packToDelete = packages[packageId];
            
            packages.Remove(packageId);
            foreach (var pack in packToDelete.Children)
            {
                packages.Remove(pack.Id);
            }
        }

       
    }
}
