using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System.Collections.Generic;

namespace OnlineShop.Models.Products.Computers
{
    public interface IComputer : IProduct
    {
        IReadOnlyCollection<IComponent> Components { get; }

        IReadOnlyCollection<IPeripheral> Peripherals { get; }

        void AddComponent(IComponent component);

        IComponent RemoveComponent(string componentType);

        void AddPeripheral(IPeripheral peripheral);

        IPeripheral RemovePeripheral(string peripheralType);
    }
}
