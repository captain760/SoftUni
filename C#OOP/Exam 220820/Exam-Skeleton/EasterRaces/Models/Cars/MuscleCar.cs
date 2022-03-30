using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars
{
    public class MuscleCar : Car, ICar
    {
        public MuscleCar(string model, int horsePower) : base(model, horsePower, 5000, 400, 600)
        {
        }
    }
}
