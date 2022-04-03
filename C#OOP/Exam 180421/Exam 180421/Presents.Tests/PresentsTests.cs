namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Present present2;
        private Present present3;
        private Bag bag;
         
        [SetUp]
        public void SetUp()
        {
            present = new Present("Bobo", 13.5);
            bag = new Bag();
            bag.Create(present);
        }
        [Test]
        public void TestIfConstructorIsNotNull()
        {
            Assert.IsNotNull(present);
            Assert.IsNotNull(bag);
        }
        [Test]
        public void TestIfNullPresentThrowsException()
        {
            present = null;
                Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }
        [Test]
        public void TestIfExistingPresentThrowsException()
        {
            
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }
        [Test]
        public void TestSuccessCreatingPresent()
        {
            present2 = new Present("Toto", 13.2);
            Assert.AreEqual("Successfully added present Toto.", bag.Create(present2));
        }
        [Test]
        public void TestRemovePresent()
        {
            present2 = new Present("Toto", 13.2);
            bag.Create(present2);
            bag.Remove(present2);
            Assert.AreEqual(1, bag.GetPresents().Count);
        }
        [Test]
        public void TestLeastMagicPresentReturnCorrectOne()
        {
            present2 = new Present("Toto", 13.2);
            present3 = new Present("Gogo", 13.0);
            bag.Create(present2);
            bag.Create(present3);
            
            Assert.AreEqual(present3, bag.GetPresentWithLeastMagic());
        }
        [Test]
        public void TestPresentWithSpecificNameReturnCorrectOne()
        {
            present2 = new Present("Toto", 13.2);
            present3 = new Present("Gogo", 13.0);
            bag.Create(present2);
            bag.Create(present3);

            Assert.AreEqual(present2, bag.GetPresent("Toto"));
        }
    }
}
