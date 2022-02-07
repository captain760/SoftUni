using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string regNumber;
        public Car(string make, string model, int horsePower,string regNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = regNumber;
        }
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int HorsePower { get { return horsePower; } set { horsePower = value; } }
        public string RegistrationNumber { get { return regNumber; } set { regNumber = value; } }
        public override string ToString()
        {
            return $"Make: {make}\nModel: {model}\nHorsePower: {horsePower}\nRegistrationNumber: {regNumber}";

        }
    }
}
