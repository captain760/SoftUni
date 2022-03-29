using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (!computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            if (computers.Any(x=>x.Components.Any(y=>y.Id == id)))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            var computer = computers.Where(x => x.Id == computerId).First();
            if (componentType == "CentralProcessingUnit")
            {
                var component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                computer.AddComponent(component);
                if (!components.Contains(component))
                {
                    components.Add(component);
                }
                return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            }
            else if (componentType == "Motherboard")
            {
                var component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                computer.AddComponent(component);
                if (!components.Contains(component))
                {
                    components.Add(component);
                }
                return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            }
            else if (componentType == "PowerSupply")
            {
                var component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                computer.AddComponent(component);
                if (!components.Contains(component))
                {
                    components.Add(component);
                }
                return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            }
            else if (componentType == "RandomAccessMemory")
            {
                var component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                computer.AddComponent(component);
                if (!components.Contains(component))
                {
                    components.Add(component);
                }
                return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            }
            else if (componentType == "SolidStateDrive")
            {
                var component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                computer.AddComponent(component);
                if (!components.Contains(component))
                {
                    components.Add(component);
                }
                return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            }
            else if (componentType == "VideoCard")
            {
                var component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                computer.AddComponent(component);
                if (!components.Contains(component))
                {
                    components.Add(component);
                }
                return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x=>x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            if (computerType == "Laptop")
            {
                var computer = new Laptop(id, manufacturer, model, price);
                computers.Add(computer);
                return string.Format(SuccessMessages.AddedComputer,id);
            }
            else if (computerType == "DesktopComputer")
            {
                var computer = new DesktopComputer(id, manufacturer, model, price);
                computers.Add(computer);
                return string.Format(SuccessMessages.AddedComputer, id);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (!computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            if (computers.Any(x => x.Peripherals.Any(y => y.Id == id)))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            var computer = computers.Where(x => x.Id == computerId).First();
            if (peripheralType == "Headset")
            {
                var peripheral = new Headset(id, manufacturer, model, price, overallPerformance,connectionType);
                computer.AddPeripheral(peripheral);
                if (!peripherals.Contains(peripheral))
                {
                    peripherals.Add(peripheral);
                }
                return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
            }
            else if (peripheralType == "Keyboard")
            {
                var peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                computer.AddPeripheral(peripheral);
                if (!peripherals.Contains(peripheral))
                {
                    peripherals.Add(peripheral);
                }
                return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
            }
            else if (peripheralType == "Monitor")
            {
                var peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                computer.AddPeripheral(peripheral);
                if (!peripherals.Contains(peripheral))
                {
                    peripherals.Add(peripheral);
                }
                return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
            }
            else if (peripheralType == "Mouse")
            {
                var peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                computer.AddPeripheral(peripheral);
                if (!peripherals.Contains(peripheral))
                {
                    peripherals.Add(peripheral);
                }
                return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

        }

        public string BuyBest(decimal budget)
        {
            var computer = computers.OrderByDescending(x => x.OverallPerformance).Where(x => x.Price <= budget).FirstOrDefault();
            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            if (!computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            var computer = computers.Where(x => x.Id == id).FirstOrDefault();
            computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            if (!computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            var computer = computers.Where(x => x.Id == id).FirstOrDefault();
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            var computer = computers.Where(x => x.Id == computerId).FirstOrDefault();
            var component = components.Where(x => x.GetType().Name == componentType).FirstOrDefault();
            computer.RemoveComponent(componentType);
            if (component != null)
            {
                components.Remove(component);
            }
            
            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            var computer = computers.Where(x => x.Id == computerId).FirstOrDefault();
            var peripheral = peripherals.Where(x => x.GetType().Name == peripheralType).FirstOrDefault();
            computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);
            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }
    }
}
