using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GuessingGame.BLL;
namespace GuessingGame.Test
{
    [TestFixture]
    public class GameManagerTest
    {
        [Test]
        public void InvalidGuessTest()
        {
            GameManager gameInstance = new BLL.GameManager();
            gameInstance.Start();
            GuessResult actual = gameInstance.ProcessGuess(42);
            Assert.AreEqual(GuessResult.Invalid, actual);
        }
        [Test]
        public void GuessTooHigh()
        {
            GameManager gameInstance = new BLL.GameManager();

            gameInstance.Start(5);
            GuessResult actual = gameInstance.ProcessGuess(10);

            Assert.AreEqual(GuessResult.TooHigh, actual);

        }
        [Test]
        public void TooLowTestGuess()
        {
            GameManager gameInstance = new BLL.GameManager();
            gameInstance.Start(10);
            GuessResult actual = gameInstance.ProcessGuess(8);

            Assert.AreEqual(GuessResult.TooLow, actual);

        }

        [Test]
        public void CorrectGuessResult()
        {
            GameManager gameInstance = new BLL.GameManager();
            gameInstance.Start(10);
            GuessResult actual = gameInstance.ProcessGuess(10);

            Assert.AreEqual(GuessResult.Correct, actual);
        }
    }
}
