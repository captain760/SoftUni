using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Athlete athlete1;
        private Athlete athlete2;
        private Gym gym1;
        private Gym gym2;
        [SetUp]
        public void SetUp()
        {
            gym1 = new Gym("Olimpia", 1);
            gym2 = new Gym("Olimpia2", 10);
            athlete1 = new Athlete("Bobo");
            athlete2 = new Athlete("Toto");
        }
        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(gym1);
            Assert.AreEqual(0, gym1.Count);
        }
        [Test]
        public void TestNameIsNotNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 12));
           
        }
        [Test]
        public void TestCapacityIsNotNegative()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Oly", -12));

        }
        [Test]
        public void TestCapacityIsFull()
        {
            gym1.AddAthlete(athlete1);
            Assert.Throws<InvalidOperationException>(() => gym1.AddAthlete(athlete2));

        }
        [Test]
        public void TestCapacityIsCorrect()
        {
            gym2.AddAthlete(athlete1);
            gym2.AddAthlete(athlete2);
            Assert.AreEqual(2, gym2.Count);

        }
        [Test]
        public void TestRemovingAthleteIsCorrect()
        {
            
            gym2.AddAthlete(athlete1);
            gym2.AddAthlete(athlete2);
            gym2.RemoveAthlete("Bobo");
            Assert.AreEqual(1, gym2.Count);

        }
        [Test]
        public void TestRemovingNonExistentAthlete()
        { 
            gym2.AddAthlete(athlete1);
            gym2.AddAthlete(athlete2);
            
            Assert.Throws<InvalidOperationException>(() => gym2.RemoveAthlete("Momo"));

        }
        [Test]
        public void TestInjuringAthleteIsCorrect()
        {

            gym2.AddAthlete(athlete1);
            gym2.AddAthlete(athlete2);
            
            Assert.AreEqual(athlete1, gym2.InjureAthlete("Bobo"));

        }
        [Test]
        public void TestInjuringNonExistentAthlete()
        {
            gym2.AddAthlete(athlete1);
            gym2.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() => gym2.InjureAthlete("Momo"));

        }
        [Test]
        public void TestReportingIsCorrect()
        {

            gym2.AddAthlete(athlete1);
            gym2.AddAthlete(athlete2);

            Assert.AreEqual("Active athletes at Olimpia2: Bobo, Toto", gym2.Report());

        }
    }
}
