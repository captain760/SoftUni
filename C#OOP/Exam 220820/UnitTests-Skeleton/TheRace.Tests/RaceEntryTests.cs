using NUnit.Framework;
using System;
using TheRace;


namespace TheRace.Tests
{
   
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitCar unitCar1;
        private UnitCar unitCar2;
        
        private UnitDriver unitDriver1;
        private UnitDriver unitDriver2;
        private UnitDriver unitDriver3;
        [SetUp]
        public void Setup()
        {
            unitCar1 = new UnitCar("bmv", 240, 2450.5);
            unitCar2 = new UnitCar("Merc", 220, 2450.5);
            
            unitDriver1 = new UnitDriver("Bobo", unitCar1);
            unitDriver2 = new UnitDriver("Toto", unitCar2);
            unitDriver3 = null;
            raceEntry = new RaceEntry();
        }
        [Test]
        public void Test1()
        {
            Assert.IsNotNull(raceEntry);
        }

        [Test]
        public void Test2()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(unitDriver3), "Driver cannot be null.");
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual(0,raceEntry.Counter);
            raceEntry.AddDriver(unitDriver1);
            raceEntry.AddDriver(unitDriver2);
            Assert.AreEqual(2, raceEntry.Counter);
        }
        [Test]
        public void Test4()
        {
            raceEntry.AddDriver(unitDriver1);
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(unitDriver1), "Driver {0} is already added.");
        }
        [Test]
        public void Test5()
        {
            raceEntry.AddDriver(unitDriver1);
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower(), "The race cannot start with less than 2 participants.");
        }
        [Test]
        public void Test6()
        {
            raceEntry.AddDriver(unitDriver1);
            raceEntry.AddDriver(unitDriver2);
            Assert.AreEqual(230,raceEntry.CalculateAverageHorsePower());
        }
    }
}