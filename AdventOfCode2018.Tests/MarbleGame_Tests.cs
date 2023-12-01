using Xunit;

namespace AdventOfCode2018.Tests
{
    public class MarbleGame_Tests
    {
        [Fact]
        public void PlayGame__Test1()
        {
            MarbleGame marbleGame = new MarbleGame();

            marbleGame.PlayGame(9, 25);
            long highScore = marbleGame.GetHighScore();

            Assert.Equal(32, highScore);
        }

        [Fact]
        public void PlayGame__Test2()
        {
            MarbleGame marbleGame = new MarbleGame();

            marbleGame.PlayGame(10, 1618);
            long highScore = marbleGame.GetHighScore();

            Assert.Equal(8317, highScore);
        }

        [Fact]
        public void PlayGame__Test3()
        {
            MarbleGame marbleGame = new MarbleGame();

            marbleGame.PlayGame(13, 7999);
            long highScore = marbleGame.GetHighScore();

            Assert.Equal(146373, highScore);
        }

        [Fact]
        public void PlayGame__Test4()
        {
            MarbleGame marbleGame = new MarbleGame();

            marbleGame.PlayGame(17, 1104);
            long highScore = marbleGame.GetHighScore();

            Assert.Equal(2764, highScore);
        }

        [Fact]
        public void PlayGame__Test5()
        {
            MarbleGame marbleGame = new MarbleGame();

            marbleGame.PlayGame(21, 6111);
            long highScore = marbleGame.GetHighScore();

            Assert.Equal(54718, highScore);
        }

        [Fact]
        public void PlayGame__Test6()
        {
            MarbleGame marbleGame = new MarbleGame();

            marbleGame.PlayGame(30, 5807);
            long highScore = marbleGame.GetHighScore();

            Assert.Equal(37305, highScore);
        }
    }
}