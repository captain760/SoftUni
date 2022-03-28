using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AddingItemnACellWhichDoesNotExistShouldThrowException()
        {
            BankVault vault = new BankVault();
            Item item = new Item("bobo", "123456");
            Assert.Throws<ArgumentException>(() => vault.AddItem("A12", item), "Cell doesn't exists!");
        }
        [Test]
        public void AddingItemInACellWhichIsTakenAlreadyShouldThrowException()
        {
            BankVault vault = new BankVault();
            Item item = new Item("bobo", "123456");
            vault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => vault.AddItem("A1", item), "Cell is already taken!");
        }
        [Test]
        public void AddingItemWhichIdAlreadyExistsShouldThrowException()
        {
            BankVault vault = new BankVault();
            Item item = new Item("bobo", "123456");
            vault.AddItem("B1", item);
            Assert.Throws<InvalidOperationException>(() => vault.AddItem("A1", item), "Item is already in cell!");
        }
        [Test]
        public void RemovingItemFromACellWhichDoesNotExistShouldThrowException()
        {
            BankVault vault = new BankVault();
            Item item = new Item("bobo", "123456");
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A12", item), "Cell doesn't exists!");
        }
        [Test]
        public void RemovingItemWhichDoesNotExistsShouldThrowException()
        {
            BankVault vault = new BankVault();
            Item item = new Item("bobo", "123456");
            vault.AddItem("B1", item);
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("B1", new Item("bobo","1234567")), "Item in that cell doesn't exists!");
        }
    }
}