using OnlineShop.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Peripherals
{
    public abstract class Peripheral : Product, IPeripheral
    {
        private string connectionType;
       
        public Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType) : base(id, manufacturer, model, price, overallPerformance)
        {
            ConnectionType = connectionType;
        }

        public string ConnectionType
        {
            get
            {
                return connectionType;
            }
            private set
            {
                connectionType = value;
            }
        }
        public override string ToString()
        {
            return $"  Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id}) Connection Type: {connectionType}";
        }
    }
}
