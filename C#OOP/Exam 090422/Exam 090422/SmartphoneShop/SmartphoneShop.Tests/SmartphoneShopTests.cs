using NUnit.Framework;
using System;
namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop shop;
        private Shop shop2;
        private Smartphone phone1;
        private Smartphone phone2;
       [SetUp]
       public void SetUp()
        {
            shop = new Shop(1);
            shop2 = new Shop(2);
            phone1 = new Smartphone("Nokia", 98);
            phone2 = new Smartphone("LG", 98);
        }
        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(shop);
        }
        [Test]
        public void TestCapacityBelow0ThrowExcep()
        {

            Assert.Throws<ArgumentException>(() => new Shop(-2));
        }
        [Test]
        public void TestCount()
        {

            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void TestAddThrowExcepOnExistingPhone()
        {
            shop.Add(phone1);
            Assert.Throws<InvalidOperationException>(() => shop.Add(phone1));
        }
        [Test]
        public void TestAddThrowExcepOnMaxCapacity()
        {
            shop.Add(phone1);
            Assert.Throws<InvalidOperationException>(() => shop.Add(phone2));
        }
        [Test]
        public void TestCapacity()
        {
            shop.Add(phone2);

            Assert.AreEqual(1, shop.Capacity);
        }
        [Test]
        public void TestRemoveThrowExcepOnNonExistingPhone()
        {
            shop.Add(phone1);
            Assert.Throws<InvalidOperationException>(() => shop.Remove("LG"));
        }
        [Test]
        public void TestRemoveDoTheJob()
        {
            shop2.Add(phone1);
            shop2.Add(phone2);
            shop2.Remove("LG");
            Assert.AreEqual(1, shop2.Count);
        }
        [Test]
        public void TestTestPhoneThrowExcepOnNonExistingPhone()
        {
            shop.Add(phone1);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Samsung",90));
        }
        [Test]
        public void TestTestPhoneThrowExcepOnCurrentCapacityBelowRequired()
        {
            shop.Add(phone1);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Nokia", 99));
        }
        [Test]
        public void TestNormalReduceWhenUsing()
        {
            shop.Add(phone1);
            shop.TestPhone("Nokia", 2);
            Assert.AreEqual(96, phone1.CurrentBateryCharge);
        }
        [Test]
        public void TestChargePhoneThrowExcepOnNonExistingPhone()
        {
            shop.Add(phone1);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Samsung"));
        }
        [Test]
        public void TestNormalCharge()
        {
            shop.Add(phone1);
            shop.TestPhone("Nokia", 2);
            shop.ChargePhone("Nokia");
            Assert.AreEqual(98, phone1.CurrentBateryCharge);
        }
        [Test]
        public void Test1()
        {
            shop2.Add(phone1);
            shop2.Add(phone2);
            Assert.AreEqual(2, shop2.Count);
        }
        [Test]
        public void TestNormalCharge2()
        {
            shop.Add(phone1);
            shop.TestPhone("Nokia", 2);
            shop.ChargePhone("Nokia");
            Assert.AreEqual(98, phone1.MaximumBatteryCharge);
        }
        [Test]
        public void TestNormalCharge3()
        {
            shop.Add(phone1);
            shop.TestPhone("Nokia", 2);
            shop.ChargePhone("Nokia");
            Assert.AreEqual(phone1.MaximumBatteryCharge, phone1.CurrentBateryCharge);
        }
    }
}