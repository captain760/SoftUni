using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product,IComponent
    {
        private int generation;
        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance)
        {
            Generation = generation;
        }

        public int Generation 
        {
            get
            {
                return generation;
            }
            private set
            {
                generation = value;
            }
        }
        public override string ToString()
        {
            
            return $"  Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id}) Generation: {Generation}";
        }
    }
}
