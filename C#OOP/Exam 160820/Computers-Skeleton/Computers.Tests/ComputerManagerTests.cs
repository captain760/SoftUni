using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            ComputerManager manager = new ComputerManager();
            Computer first = new Computer("IBM", "ThinkPad", 1000);
            manager.AddComputer(first);
            Assert.AreEqual(1, manager.Count);

        }
        [Test]
        public void Test2()
        {
            ComputerManager manager = new ComputerManager();
            Computer first = new Computer("IBM", "ThinkPad", 1000);
            manager.AddComputer(first);

            Computer third = new Computer("IBM", "ThinkPad", 2000);
            Assert.Throws<ArgumentException>(() => manager.AddComputer(third), "This computer already exists.");
        }
        [Test]
        public void Test3()
        {
            ComputerManager manager = new ComputerManager();
            Computer first = new Computer("IBM", "ThinkPad", 1000);
            manager.AddComputer(first);
            manager.RemoveComputer("IBM", "ThinkPad");
            Assert.AreEqual(0, manager.Computers.Count);
            manager.AddComputer(first);
            Assert.AreEqual(first, manager.RemoveComputer("IBM", "ThinkPad"));

        }
        [Test]
        public void Test4()
        {
            ComputerManager manager = new ComputerManager();
            Computer first = new Computer("IBM", "ThinkPad", 1000);
            manager.AddComputer(first);
            Assert.AreEqual(first, manager.GetComputer("IBM", "ThinkPad"));
            Assert.Throws<ArgumentException>(() => manager.GetComputer("Lenovo", "ThinkPad"), "There is no computer with this manufacturer and model.");

        }
        [Test]
        public void Test5()
        {
            ComputerManager manager = new ComputerManager();
            Computer first = new Computer("IBM", "ThinkPad", 1000);
            Computer second = new Computer("IBM", "IdeaPad", 1500);
            Computer third = new Computer("Lenovo", "ThinkPad", 2000);
            manager.AddComputer(first);
            manager.AddComputer(second);
            manager.AddComputer(third);

            Assert.AreEqual(2, manager.GetComputersByManufacturer("IBM").Count);

        }
        [Test]
        public void Test6()
        {
            ComputerManager manager = new ComputerManager();
            Computer second = null;
            Computer first = new Computer(null, "ThinkPad", 1000);
            Assert.AreEqual(null, first.Manufacturer);
            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(second), "Can not be null!");

        }
        [Test]
        public void Test7()
        {
            ComputerManager manager = new ComputerManager();

            Computer first = new Computer("Ibm", "ThinkPad", 1000);

            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(null, "IdeaPad"), "Can not be null!");

        }
        [Test]
        public void Test8()
        {
            ComputerManager manager = new ComputerManager();

            Computer first = new Computer("Ibm", "ThinkPad", 1000);

            Assert.Throws<ArgumentNullException>(() => manager.GetComputer("Ibm", null), "Can not be null!");

        }
        [Test]
        public void Test9()
        {
            ComputerManager manager = new ComputerManager();
            Computer first = new Computer("IBM", "ThinkPad", 1000);
            Computer second = new Computer("IBM", "IdeaPad", 1500);

            manager.AddComputer(first);
            manager.AddComputer(second);
            List<Computer> list = new List<Computer> { first, second };

            Assert.AreEqual(list, manager.GetComputersByManufacturer("IBM"));

        }
        [Test]
        public void Test10()
        {
            ComputerManager manager = new ComputerManager();
            Computer first = new Computer("IBM", "ThinkPad", 1000);
            manager.AddComputer(first);
            Assert.True(manager.Computers is IReadOnlyCollection<Computer>);

        }
        [Test]
        public void Test11()
        {
            ComputerManager manager = new ComputerManager();
            Computer first = new Computer("IBM", "ThinkPad", 1000);
            manager.AddComputer(first);

            Assert.Throws<ArgumentException>(() => manager.RemoveComputer("Lenovo", "ThinkPad"), "There is no computer with this manufacturer and model.");

        }
    }
}