namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    [TestFixture]
    public class Tests
    {
        private Book book;
        private Dictionary<int, string> footnote1;

        [SetUp]
        public void SetUp()
        {
            book = new Book("FirstBook", "Bobo");
            footnote1 = new Dictionary<int, string> { { 1, "hello" } };
        }
        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(book);
        }
        [Test]
        public void TestNullNameThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Book(null, "Bobo"));
        }
        [Test]
        public void TestNullAuthorThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Book("Gogo", null));
        }
        [Test]
        public void TestFootnoteCounter()
        {
            Assert.AreEqual(0, book.FootnoteCount);
        }
        [Test]
        public void TestGetters()
        {
            Assert.AreEqual("FirstBook", book.BookName);
            Assert.AreEqual("Bobo", book.Author);
        }
        [Test]
        public void TestAddingSameFootnoteThrowsException()
        {
            book.AddFootnote(1, "Boom");
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "Boom"));
        }
        [Test]
        public void TestAddingFootnoteIsIncreasingDictionaryCounter()
        {
            book.AddFootnote(1, "Boom");
            book.AddFootnote(2, "Moob");
            Assert.AreEqual(2,book.FootnoteCount);
        }
        [Test]
        public void TestFindingNonExistentFootnoteThrowsException()
        {
            book.AddFootnote(1, "Boom");
            book.AddFootnote(2, "Moob");
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(3));
        }
        [Test]
        public void TestFindingExistentFootnoteReturnIt()
        {
            book.AddFootnote(1, "Boom");
            book.AddFootnote(2, "Moob");
            Assert.AreEqual("Footnote #2: Moob", book.FindFootnote(2));
        }
        [Test]
        public void TestAlteringNonExistentFootnoteThrowsException()
        {
            book.AddFootnote(1, "Boom");
            book.AddFootnote(2, "Moob");
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(3,"BaBoom"));
        }
        [Test]
        public void TestAlteringExistentFootnoteAltersIt()
        {
            book.AddFootnote(1, "Boom");
            book.AddFootnote(2, "Moob");
            book.AlterFootnote(2, "Zoom");
            Assert.AreEqual("Footnote #2: Zoom",book.FindFootnote(2));
        }
    }
}