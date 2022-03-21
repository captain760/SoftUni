namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void EnrolledWarriorsCanNotEnrollAgain()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Bobo", 2, 350));
            arena.Enroll(new Warrior("Koko", 3, 120));
            arena.Enroll(new Warrior("Boko", 4, 220));
            arena.Enroll(new Warrior("Choko", 5, 320));
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Choko", 6, 350)), "Warrior is already enrolled for the fights!");
        }
        [Test]
        public void MissingWarriorsCanNotFight()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Bobo", 2, 350));
            arena.Enroll(new Warrior("Koko", 3, 120));
            
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Choko","Bobo"), $"There is no fighter with name Choko enrolled for the fights!");
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Bobo","Toto"), $"There is no fighter with name Toto enrolled for the fights!"); 
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Momo","Toto"), $"There is no fighter with name Toto enrolled for the fights!"); 
        }
        [Test]
        public void CheckingWarriorsCountShouldBeCorrect()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Bobo", 2, 350));
            arena.Enroll(new Warrior("Koko", 3, 120));

            Assert.AreEqual(2, arena.Count);
        }
        [Test]
        public void WarriorsShouldFightIfAsked()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Bobo", 50, 350));
            arena.Enroll(new Warrior("Koko", 40, 120));
            arena.Fight("Bobo", "Koko");
            Assert.AreEqual(310, arena.Warriors.First(x=>x.Name=="Bobo").HP);
            Assert.AreEqual(70, arena.Warriors.First(x=>x.Name=="Koko").HP);
        }
    }
}
