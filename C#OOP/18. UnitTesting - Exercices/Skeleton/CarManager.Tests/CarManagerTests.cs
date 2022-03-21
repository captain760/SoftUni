namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void SettingNewCarShouldSetAllFieldsRespectively()
        {
            Car car = new Car("BMW", "GT", 13.5, 60.5);
            Assert.AreEqual(0, car.FuelAmount);
            Assert.AreEqual("BMW", car.Make);
            Assert.AreEqual("GT", car.Model);
            Assert.AreEqual(13.5, car.FuelConsumption);
            Assert.AreEqual(60.5, car.FuelCapacity);
        }
        [Test]
        public void EmptyNameShouldThrowException()
        {

            Assert.Throws<ArgumentException>(() => new Car("", "GT", 13.56, 66.7), "Make cannot be null or empty!");
        }
        [Test]
        public void EmptyModelShouldThrowException()
        {

            Assert.Throws<ArgumentException>(() => new Car("BMW", "", 13.56, 66.7), "Model cannot be null or empty!");
        }
        [Test]
        public void NegativeOrZeroFuelConsumptionShouldThrowException()
        {

            Assert.Throws<ArgumentException>(() => new Car("BMW", "GT", -13.56, 66.7), "Fuel consumption cannot be zero or negative!");
            Assert.Throws<ArgumentException>(() => new Car("BMW", "GT", 0, 66.7), "Fuel consumption cannot be zero or negative!");
        }
        
        [Test]
        public void NegativeFuelCapacityShouldThrowException()
        {                      
            Assert.Throws<ArgumentException>(() => new Car("BMW", "GT", 13.5, -1), "Fuel capacity cannot be zero or negative!");
        }
        [Test]
        public void NegativeOrZeroFuelToRefuelShouldThrowException()
        {
            Car car = new Car("BMW", "GT", 13.5, 60.5);
            Assert.Throws<ArgumentException>(() => car.Refuel(-20), "Fuel amount cannot be zero or negative!");
            Assert.Throws<ArgumentException>(() => car.Refuel(0), "Fuel amount cannot be zero or negative!");
        }
        [Test]
        public void PositiveRefuelShouldRefillRespectively()
        {
            Car car = new Car("BMW", "GT", 13.5, 60.5);
            car.Refuel(80);
            Assert.AreEqual(60.5,car.FuelAmount);
        }
        [Test]
        public void UncoverableDistanceShouldThrowException()
        {
            Car car = new Car("BMW", "GT", 13.5, 60.5);
            Assert.Throws<InvalidOperationException>(() => car.Drive(1000), "You don't have enough fuel to drive!");
        }
        [Test]
        public void PositiveDriveShouldRemoveFuelRespectively()
        {
            Car car = new Car("BMW", "GT", 10, 60);
            car.Refuel(20);
            car.Drive(10);
            Assert.AreEqual(19, car.FuelAmount);
        }
    }
}