// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
   using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
	public class StageTests
    {
		private List<Song> songs;
		private List<Performer> performers;
		private Performer performer1;
		private Performer performer2;
		private Performer performer3;
		private Song song1;
		private Song song2;
		private Song song3;
		private Song song4;
		private Stage stage;

		[SetUp]
		public void SetUp()
        {
			songs = new List<Song>();
			performers = new List<Performer>();
			performer1 = new Performer("Ivan", "Ivanov", 33);
			performer2 = new Performer("Pesho", "Peshov", 17);
			performer3 =null;
			song1 = new Song("Panairi", new TimeSpan(0, 2, 30));
			song2 = new Song("Pazarite", new TimeSpan(0, 0, 30));
			song4 = new Song("Pazari", new TimeSpan(0, 1, 30));
			song3 = null;
			stage = new Stage();
		}

		[Test]
	    public void TestConstructor()
	    {
			Assert.IsNotNull(songs);
			Assert.IsNotNull(performers);
		}
		[Test]
		public void TestThatPerformerCanNotBeNull()
		{
			stage.AddPerformer(performer1);
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer3), "Can not be null!");
		}
		[Test]
		public void TestThatPerformerCanNotBeBelow18()
		{
			stage.AddPerformer(performer1);
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer2), "You can only add performers that are at least 18.");
		}
		[Test]
		public void TestThatSongCanNotBeNull()
		{
			stage.AddSong(song1);
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(song3), "Can not be null!");
		}
		[Test]
		public void TestThatSongCanNotBeBelow1min()
		{
			stage.AddSong(song1);
			Assert.Throws<ArgumentException>(() => stage.AddSong(song2), "You can only add songs that are longer than 1 minute.");
		}
		[Test]
		public void TestThatSongCanNotBeNullWhenAddingSongToPerformer()
		{
			
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null,"Soso"), "Can not be null!");
		}
		[Test]
		public void TestThatPerformerCanNotBeNullWhenAddingSongToPerformer()
		{

			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("Gogo", null), "Can not be null!");
		}
		[Test]
		public void TestThatSongDoesNotExistWhenAddingSongToPerformer()
		{
			stage.AddPerformer(performer1);
			stage.AddSong(song1);
			stage.AddSongToPerformer("Panairi", "Ivan Ivanov");
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Gogo", "Ivan Ivanov"), "There is no song with this name.");
		}
		[Test]
		public void TestThatPerformerDoesNotExistWhenAddingSongToPerformer()
		{
			stage.AddPerformer(performer1);
			stage.AddSong(song1);
			
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Panairi", "Ivana Ivanova"), "There is no performer with this name.");
		}
		[Test]
		public void TestThatPerformerAcceptsSong()
		{
			stage.AddPerformer(performer1);
			stage.AddSong(song1);

			Assert.AreEqual(stage.AddSongToPerformer("Panairi", "Ivan Ivanov"), "Panairi (02:30) will be performed by Ivan Ivanov");
		}
		[Test]
		public void TestPlayTimeIsCorrect()
		{
			stage.AddPerformer(performer1);
			//stage.AddPerformer(performer2);
			stage.AddSong(song1);
			stage.AddSong(song4);
			stage.AddSongToPerformer("Panairi", "Ivan Ivanov");
			stage.AddSongToPerformer("Pazari", "Ivan Ivanov");

			Assert.AreEqual("1 performers played 2 songs", stage.Play());
		}
		[Test]
		public void TestThatPerformerCounterIsCorrect()
		{
			stage.AddPerformer(performer1);
			Assert.AreEqual(1, stage.Performers.Count);
		}
	}
}