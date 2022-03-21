namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void WarriorConstructorShouldSetWarriorCorrect()
        {
            Warrior warrior = new Warrior("Bobo", 2, 20);
            Assert.AreEqual("Bobo", warrior.Name);
            Assert.AreEqual(2, warrior.Damage);
            Assert.AreEqual(20, warrior.HP);
        }
        [Test]
        public void WarriorNameShouldBeNotNullOrWhitespace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("", 2, 20), "Name should not be empty or whitespace!");
        }
        [Test]
        public void WarriorDamageShouldBePositive()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Gogo", -2, 20), "Damage value should be positive!");
            Assert.Throws<ArgumentException>(() => new Warrior("Gogo", 0, 20), "Damage value should be positive!");
        }
        [Test]
        public void WarriorHPShouldBePositive()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Koko", 2, -20), "HP should not be negative!");
        }
        [Test]
        public void WarriorCanNotAttackIfHisHPIsBelow30()
        {
            Warrior warrior = new Warrior("Koko", 15, 29);
            Warrior enemy = new Warrior("Boko", 15, 55);       Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy), "Your HP is too low in order to attack other warriors!");
        }
        [Test]
        public void WarriorCanNotAttackEnemyWhoseHPIsBelow30()
        {
            Warrior warrior = new Warrior("Koko", 15, 55);
            Warrior enemy = new Warrior("Boko", 15, 25); Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy), "Enemy HP must be greater than 30 in order to attack him!");
        }
        [Test]
        public void WarriorCanNotAttackEnemyWhoseDamageIMoreThanHisOwnHP()
        {
            Warrior warrior = new Warrior("Koko", 15, 55);
            Warrior enemy = new Warrior("Boko", 75, 35); Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy), "You are trying to attack too strong enemy");
        }
        [Test]
        public void WarriorShouldZeroTheHPOfWeakEnemy()
        {
            Warrior warrior = new Warrior("Koko", 37, 55);
            Warrior enemy = new Warrior("Boko", 45, 35);
            warrior.Attack(enemy);
            Assert.AreEqual(0, enemy.HP);
        }
    }
}