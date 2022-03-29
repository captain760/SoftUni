using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<Components.IComponent> components;
        private readonly List<IPeripheral> peripherals;
        
        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<Components.IComponent>();
            peripherals = new List<IPeripheral>();
            
        }
        public IReadOnlyCollection<Components.IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get 
            {
                if (this.components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                return base.OverallPerformance + this.components.Average(x => x.OverallPerformance);
            }            
	    }
        public override decimal Price 
        {
            get
            {
                return base.Price + components.Sum(x => x.Price) + peripherals.Sum(x => x.Price);
            }
            
        }


        public void AddComponent(Components.IComponent component)
        {
            if (components.Any(x=>x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            peripherals.Add(peripheral);
        }

        public Components.IComponent RemoveComponent(string componentType)
        {
            if (components.Count ==0 || !components.Any(x=>x.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            Components.IComponent removed = components.FirstOrDefault(x => x.GetType().Name == componentType);
            components.Remove(removed);
            return removed;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count == 0 || !peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
            IPeripheral removed = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            peripherals.Remove(removed);
            return removed;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {Price:f2} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id})");
            sb.AppendLine($" Components ({components.Count}):");
            foreach (var item in components)
            {
                
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({peripherals.Select(x => x.OverallPerformance).DefaultIfEmpty(0).Average():f2}):");
            foreach (var item in peripherals)
            {
                
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
