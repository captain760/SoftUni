using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLossesHealthWhenAttacked()
        {
            Dummy dummy = new Dummy(10, 15);
            Axe axe = new Axe(2, 50);
            axe.Attack(dummy);
            Assert.AreEqual(8, dummy.Health);
        }
        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(1, 1);
            Axe axe = new Axe(1, 10);
            axe.Attack(dummy);
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Dummy is dead.");
        }
        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 1);
            Axe axe = new Axe(1, 10);            
            Assert.AreEqual(1,dummy.GiveExperience());
        }
        [Test]
        public void AliveDummyCanNotGiveXP()
        {
            Dummy dummy = new Dummy(1, 1);
            Axe axe = new Axe(1, 10);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Dummy is dead.");
        }
    }
}