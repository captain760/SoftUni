namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class RobotsTests
    {
        private RobotManager manager;
        private Robot robot1;
        private Robot robot2;
        private Robot robot3;
        [SetUp]
        public void SetUp()
        {
            manager = new RobotManager(2);
            robot1 = new Robot("bobo", 20);
            robot2 = new Robot("toto", 25);
            robot3 = new Robot("gogo", 30);
        }
        [Test]
        public void TestConstructorIsNotNull()
        {
            Assert.IsNotNull(manager);
        }
        [Test]
        public void TestCapacityNotNegative()
        {
            
            Assert.Throws<ArgumentException>(() => new RobotManager(-20));
        }
        [Test]
        public void TestDuplicateRobot()
        {
            manager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() => manager.Add(robot1));
        }
        [Test]
        public void TestOverCapacity()
        {
            manager.Add(robot1);
            manager.Add(robot2);
            Assert.Throws<InvalidOperationException>(() => manager.Add(robot3));
        }
        [Test]
        public void TestInvalidRobotRemove()
        {
            manager.Add(robot1);
            manager.Add(robot2);
            Assert.Throws<InvalidOperationException>(() => manager.Remove("momo"));
        }
        [Test]
        public void TestRobotRemoveCorrectOne()
        {
            manager.Add(robot1);
            manager.Add(robot2);
            manager.Remove("bobo");
            Assert.AreEqual(1, manager.Count);
        }
        [Test]
        public void TestInvalidRobotWork()
        {
            manager.Add(robot1);
            manager.Add(robot2);
            Assert.Throws<InvalidOperationException>(() => manager.Work("momo","hard",2));
        }
        [Test]
        public void TestHugeWorkBatteryUsage()
        {
            manager.Add(robot1);
            manager.Add(robot2);
            Assert.Throws<InvalidOperationException>(() => manager.Work("bobo", "hard", 200));
        }
        [Test]
        public void TestWorkBatteryUsageIsCorrect()
        {
            manager.Add(robot1);
            manager.Add(robot2);
            manager.Work("bobo", "hard", 2);

            Assert.AreEqual(18,robot1.Battery);
        }
        [Test]
        public void TestChargeBatteryUsage()
        {
            manager.Add(robot1);
            
            Assert.Throws<InvalidOperationException>(() => manager.Charge(null));
        }
        [Test]
        public void TestChargeBatteryUsageIsCorrect()
        {
            manager.Add(robot1);
            
            manager.Work("bobo", "hard", 10);
            manager.Charge("bobo");

            Assert.AreEqual(20, robot1.Battery);
        }
    }
}
