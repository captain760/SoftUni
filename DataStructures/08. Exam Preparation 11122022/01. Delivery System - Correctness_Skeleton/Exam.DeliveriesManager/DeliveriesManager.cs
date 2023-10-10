using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        private Dictionary<string,Deliverer> deliverersById = new Dictionary<string, Deliverer>();
        private Dictionary<string,Package> packagesById = new Dictionary<string, Package>();
        private Dictionary<string,string> packageDeliverer = new Dictionary<string,string>();
        public void AddDeliverer(Deliverer deliverer)
        {
            deliverersById.Add(deliverer.Id, deliverer);
        }

        public void AddPackage(Package package)
        {
            packagesById.Add(package.Id, package);
        }

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            if (!deliverersById.ContainsKey(deliverer.Id) || !packagesById.ContainsKey(package.Id))
            {
                throw new ArgumentException();
            }
            packageDeliverer[package.Id] = deliverer.Id;
        }

        public bool Contains(Deliverer deliverer)
        {
            return deliverersById.ContainsKey(deliverer.Id);
        }

        public bool Contains(Package package)
        {
            return packagesById.ContainsKey(package.Id);
        }

        public IEnumerable<Deliverer> GetDeliverers()
        {
            return new List<Deliverer>(deliverersById.Values);
        }

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName()
        {
            var deliverersLoad = new Dictionary<string, List<string>>();
            foreach (var package in packageDeliverer)
            {
                if (!deliverersLoad.ContainsKey(package.Value))
                {
                    deliverersLoad[package.Value] = new List<string>();
                }
                deliverersLoad[package.Value].Add(package.Key);
            }
            return deliverersLoad.OrderByDescending(x => x.Value.Count).ThenBy(kvp => deliverersById[kvp.Key].Name).Select(kvp => deliverersById[kvp.Key]);
        }

        public IEnumerable<Package> GetPackages()
        {
            return new List<Package>(packagesById.Values);
        }

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver()
        {

            return packagesById.Values.OrderByDescending(x => x.Weight).ThenBy(x => x.Receiver);
        }

        public IEnumerable<Package> GetUnassignedPackages()
        {
            return packagesById.Where(x => !packageDeliverer.ContainsKey(x.Key)).Select(x=>x.Value);
        }
    }
}
