using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass()]
    public class MarbleGame_Tests
    {
        [TestMethod()]
        public void PlayGame__Test1()
        {
            MarbleGame marbleGame = new MarbleGame();

            marbleGame.PlayGame(9, 25);
            long highScore = marbleGame.GetHighScore();

            Assert.AreEqual(32, highScore);
        }

        [TestMethod()]
        public void PlayGame__Test2()
        {
            MarbleGame marbleGame = new MarbleGame();

            marbleGame.PlayGame(10, 1618);
            long highScore = marbleGame.GetHighScore();

            Assert.AreEqual(8317, highScore);
        }

        [TestMethod()]
        public void PlayGame__Test3()
        {
            MarbleGame marbleGame = new MarbleGame();

            marbleGame.PlayGame(13, 7999);
            long highScore = marbleGame.GetHighScore();

            Assert.AreEqual(146373, highScore);
        }

        [TestMethod()]
        public void PlayGame__Test4()
        {
            MarbleGame marbleGame = new MarbleGame();

            marbleGame.PlayGame(17, 1104);
            long highScore = marbleGame.GetHighScore();

            Assert.AreEqual(2764, highScore);
        }

        [TestMethod()]
        public void PlayGame__Test5()
        {
            MarbleGame marbleGame = new MarbleGame();

            marbleGame.PlayGame(21, 6111);
            long highScore = marbleGame.GetHighScore();

            Assert.AreEqual(54718, highScore);
        }

        [TestMethod()]
        public void PlayGame__Test6()
        {
            MarbleGame marbleGame = new MarbleGame();

            marbleGame.PlayGame(30, 5807);
            long highScore = marbleGame.GetHighScore();

            Assert.AreEqual(37305, highScore);
        }
    }
}