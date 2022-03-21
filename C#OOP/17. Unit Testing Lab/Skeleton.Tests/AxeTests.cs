using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLossesDurabilityAfterAnAttack()
        {
            Dummy target = new Dummy(12, 15);
            Axe axe = new Axe(50, 100);
            axe.Attack(target);
            Assert.AreEqual(axe.DurabilityPoints, 99);
        }
        [Test]
        public void TestAttackingWithBrokenAxe()
        {
            Dummy target = new Dummy(12, 15);
            Axe axe = new Axe(1, 1);
            axe.Attack(target);
            Assert.Throws<InvalidOperationException>(() => axe.Attack(target),"Axe is broken.");
        }
    }
}