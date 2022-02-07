using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            Cars = new List<Car>();
            this.capacity = capacity;
        }
        public List<Car> Cars { get { return cars; } set { cars = value; } }
        public int Count { get {return Cars.Count; } }
       

        public string AddCar(Car Car)
        {
            //bool carExists = false;
            //foreach (var car in Cars)
            //{
            //    if (car.RegistrationNumber == Car.RegistrationNumber)
            //    {
            //        carExists = true;
            //        break;
            //    }
            //}
            if (Cars.Any(x=>x.RegistrationNumber == Car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (Cars.Count >= capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(Car);
                return $"Successfully added new car {Car.Make} {Car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            bool carExists = false;
            foreach (var car in Cars)
            {
                if (car.RegistrationNumber == registrationNumber)
                {
                    carExists = true;
                    break;
                }
            }
            if (!carExists)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Cars.RemoveAll(x => x.RegistrationNumber == registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            //foreach (var item in Cars)
            //{
            //    if (item.RegistrationNumber == registrationNumber)
            //    {
            //        return item.ToString();
            //    }
            //}
            return Cars.FirstOrDefault(x=>x.RegistrationNumber==registrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var number in RegistrationNumbers)
            {
                //RemoveCar(number);
                Cars.RemoveAll(x => x.RegistrationNumber == number);
            }
        }
    }
}
