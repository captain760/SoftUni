using System;
using NUnit.Framework;
[TestFixture]
public class HeroRepositoryTests
{
    private HeroRepository repo;
    private Hero hero1;
    private Hero hero2;
    [SetUp]
    public void SetUp()
    {
        repo = new HeroRepository();
        hero1 = new Hero("bobo", 13);
        hero2 = new Hero("toto", 10);
    }
    [Test]
    public void TestConstructor()
    {
        Assert.IsNotNull(repo);
    }
    [Test]
    public void TestNullHeroThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => repo.Create(null));
    }
    [Test]
    public void TestExistingHeroThrowsException()
    {
        repo.Create(hero1);
        Assert.Throws<InvalidOperationException>(() => repo.Create(new Hero("bobo", 345)));
    }
    [Test]
    public void TestCreatingHeroThrowsSuccessMessage()
    {
        
        Assert.AreEqual("Successfully added hero bobo with level 13", repo.Create(hero1));
    }
    [Test]
    public void TestRemovingNullHeroThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => repo.Remove(null));
    }
    [Test]
    public void TestRemovingExistingHeroReturnTrue()
    {
        repo.Create(hero1);
        repo.Create(hero2);
        Assert.IsTrue(repo.Remove("toto"));
    }
    [Test]
    public void TestReturningHeroWithHighestLevel()
    {
        repo.Create(hero1);
        repo.Create(hero2);
        Assert.AreSame(hero1,repo.GetHeroWithHighestLevel());
    }
    [Test]
    public void TestReturningHeroWithRequiredName()
    {
        repo.Create(hero1);
        repo.Create(hero2);
        Assert.AreSame(hero2, repo.GetHero("toto"));
    }
}