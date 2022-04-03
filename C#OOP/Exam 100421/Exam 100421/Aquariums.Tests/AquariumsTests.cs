namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;
        private string aquarName;
        private int capacity;
        private Aquarium aquarium;
        
        [SetUp]
        public void StetUp()
        {
            fish = new Fish("Gogo");
            capacity = 200;
            aquarName = "TheBigOne";
            aquarium = new Aquarium(aquarName, capacity);

        }
        [Test]
        public void TestOfConstructor()
        {
            Assert.IsNotNull(aquarium);
        }
        [Test]
        public void TestNameIsNotEmpty()
        {
            aquarName = "";
            Assert.Throws<ArgumentNullException>(() => new Aquarium(aquarName, 300));
        }
        [Test]
        public void TestAquariumCapacityIsNotNegative()
        {
            aquarName = "NegativeOne";
            Assert.Throws<ArgumentException>(() => new Aquarium(aquarName, -300));
        }
        [Test]
        public void TestAquariumCapacityIsFull()
        {
            aquarium = new Aquarium(aquarName, 1);
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
        }
        [Test]
        public void TestAquariumIsAddingFish()
        {
            aquarium = new Aquarium(aquarName, 5);
            aquarium.Add(fish);
            aquarium.Add(fish);
            aquarium.Add(fish);
            aquarium.Add(fish);
            Assert.AreEqual(4,aquarium.Count);
        }
        [Test]
        public void TestRemovingNullFish()
        {
            aquarium = new Aquarium(aquarName, 1);
            
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(null));
        }
        [Test]
        public void TestAquariumIsRemovingFish()
        {
            aquarium = new Aquarium(aquarName, 5);
            aquarium.Add(fish);
            aquarium.RemoveFish("Gogo");
            
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]
        public void TestSellingNullFish()
        {
            aquarium = new Aquarium(aquarName, 1);
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Bobo"));
        }
        [Test]
        public void TestAquariumIsSellingFishAccordingly()
        {
            aquarium = new Aquarium(aquarName, 5);
            aquarium.Add(fish);
            

            Assert.AreEqual(fish, aquarium.SellFish("Gogo"));
            Assert.AreEqual(1, aquarium.Count);
            Assert.IsTrue(!fish.Available);
        }
        [Test]
        public void TestReporting()
        {
            aquarium = new Aquarium(aquarName, 5);
            aquarium.Add(fish);
            aquarium.Add(fish);
            Assert.AreEqual("Fish available at TheBigOne: Gogo, Gogo", aquarium.Report());
        }
    }
}
