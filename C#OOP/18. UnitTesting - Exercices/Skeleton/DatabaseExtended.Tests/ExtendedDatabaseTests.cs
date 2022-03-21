namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        [TestCase(4)]
        [TestCase(15)]
        [TestCase(16)]
        public void DatabaseCapacityShouldBeAbleToAdd16IntegersInConstructor(int count)
        {
            Person[] elements = new Person[count];
            for (int i = 0; i < count; i++)
            {
                Person person = new Person(1234567890 + i, "Bobo" + i);
                elements[i] = person;
            }
            Database database = new Database(elements);
            Assert.AreEqual(count, database.Count);
        }
        [Test]
        public void AddMethodShouldThrowExceptionWhenElementsAreMoreThan16()
        {
            Database database = new Database();
            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(1234567890+i, "Bobo"+i);
                database.Add(person);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17,"Toto")), "Provided data length should be in range [0..16]!");
        }
        [Test]
        public void DatabaseCapacityShouldThrowExceptionWhenElementsAreMoreThan16()
        {
            Person[] elements = new Person[17];

            Assert.Throws<ArgumentException>(() => new Database(elements), "Provided data length should be in range [0..16]!");
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
            Database database = new Database(new Person(12,"gogo"), new Person(13, "jojo"), new Person(14, "koko"));
            database.Remove();

            Assert.AreEqual(2, database.Count);
        }
        [Test]
        public void AddExistingIDShouldThrowException()
        {
            Database database = new Database(new Person(12, "gogo"), new Person(13, "jojo"), new Person(14, "koko"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(12, "momo")), "There is already user with this Id!");
        }
    
        [Test]
        public void AddExistingUsernameShouldThrowException()
        {
            Database database = new Database(new Person(12, "gogo"), new Person(13, "jojo"), new Person(14, "koko"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(15, "gogo")), "There is already user with this username!");
        }
        [Test]
        public void LookingForNonExistingUserShouldThrowException()
        {
            Database database = new Database(new Person(12, "gogo"), new Person(13, "jojo"), new Person(14, "koko"));

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("momo"), "No user is present by this username!");
        }
        [Test]
        public void LookingForUserWithoutParameterShouldThrowException()
        {
            Database database = new Database(new Person(12, "gogo"), new Person(13, "jojo"), new Person(14, "koko"));

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(""), "No user is present by this username!");
        }
        [Test]
        public void LookingForNonExistingIDShouldThrowException()
        {
            Database database = new Database(new Person(12, "gogo"), new Person(13, "jojo"), new Person(14, "koko"));

            Assert.Throws<InvalidOperationException>(() => database.FindById(15), "No user is present by this Id!");
        }
        [Test]
        public void LookingForNegativeIDShouldThrowException()
        {
            Database database = new Database(new Person(12, "gogo"), new Person(13, "jojo"), new Person(14, "koko"));

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-2), "Id should be a positive number!");
        }
        [Test]
        public void LookingForExistingUserByNameShouldReturnIt()
        {
            Database database = new Database(new Person(12, "gogo"), new Person(13, "jojo"), new Person(14, "koko"));

            Assert.AreEqual(new Person(12, "gogo").UserName, database.FindByUsername("gogo").UserName);
            Assert.AreEqual(new Person(12, "gogo").Id, database.FindByUsername("gogo").Id);
        }
        [Test]
        public void LookingForExistingUserByIDShouldReturnIt()
        {
            Database database = new Database(new Person(12, "gogo"), new Person(13, "jojo"), new Person(14, "koko"));
            Person jojo = new Person(13, "jojo");
            Assert.AreEqual(jojo.UserName, database.FindById(13).UserName);
            Assert.AreEqual(jojo.Id, database.FindById(13).Id);
        }
    }
}