namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        [TestCase(4)]
        [TestCase(15)]
        [TestCase(16)]
        public void DatabaseCapacityShouldBeAbleToAdd16IntegersInConstructor(int count)
        {
            int[] elements = new int[count];
            Database database = new Database(elements);  
            Assert.AreEqual(count, database.Count);
        }
        [Test]
        public void AddMethodShouldThrowExceptionWhenElementsAreMoreThan16()
        {
            Database database = new Database();
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(17), "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void DatabaseCapacityShouldThrowExceptionWhenElementsAreMoreThan16()
        {
            int[] elements = new int[17];
            
            Assert.Throws<InvalidOperationException>(() => new Database(elements), "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void RemoveElementFromEmptyDatabaseShouldReturnException()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove(), "The collection is empty!");
        }
        [Test]
        public void RemoveElementShouldRemoveTheLastElementInTheDatabase()
        {
            Database database = new Database(1,2,3,4,5);
            database.Remove();

            Assert.AreEqual(4, database.Count);
        }
        [Test]
        public void FetchMethodSouldReturnTheElementsInArray()
        {
            Database database = new Database(1, 2, 3, 4, 2);
            database.Remove();
            int[] fetched = database.Fetch();
            int[] expected = new int[] { 1, 2, 3, 4 };
            Assert.AreEqual(expected, fetched);
        }
    }
}
