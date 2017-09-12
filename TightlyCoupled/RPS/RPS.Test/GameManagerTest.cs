using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPS.BLL;
using NUnit.Framework;

namespace RPS.Test
{
    [TestFixture]
    public class GameManagerTest
    {
        [Test]
        public void RockTest()
        {
            GameManager gm = new GameManager(new AlwaysRock());

            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Rock).Player1Result);
            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Scissors).Player1Result);
            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Paper).Player1Result);
        }

        [Test]
        public void PaperTest()
        {
            GameManager gm = new GameManager(new AlwaysPaper());

            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Paper).Player1Result);
            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Rock).Player1Result);
            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Scissors).Player1Result);
        }

        [Test]
        public void ScissorsTest()
        {
            GameManager gm = new GameManager(new AlwaysScissors());

            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Scissors).Player1Result);
            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Paper).Player1Result);
            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Rock).Player1Result);

        }
    }
}
