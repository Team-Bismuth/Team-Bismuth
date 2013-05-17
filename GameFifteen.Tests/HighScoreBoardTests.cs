using System;
using System.Text;
using Game_Fifteen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameFifteen.Tests
{
    [TestClass]
    public class HighScoreBoardTests
    {
        [TestMethod]
        public void Test_HighScoreBoard_toString_FourPlayers()
        {
            HighScoreBoard hsBoard = new HighScoreBoard();
            hsBoard.AddPlayer(new Player("Pesho", 123));
            hsBoard.AddPlayer(new Player("Pesho", 123));
            hsBoard.AddPlayer(new Player("Pesho", 123));
            hsBoard.AddPlayer(new Player("Pesho", 123));
            StringBuilder result = new StringBuilder();
            result.AppendLine("Scoreboard:");
            result.AppendLine("1. Pesho : 123;");
            result.AppendLine("2. Pesho : 123;");
            result.AppendLine("3. Pesho : 123;");
            result.AppendLine("4. Pesho : 123;");
            Assert.AreEqual(result.ToString(), hsBoard.ToString());
        }

        [TestMethod]
        public void Test_HighScoreBoard_toString_NoPlayers()
        {
            HighScoreBoard hsBoard = new HighScoreBoard();
            StringBuilder result = new StringBuilder();
            result.AppendLine("Scoreboard:");
            result.AppendLine("EMPTY");
            Assert.AreEqual(result.ToString(), hsBoard.ToString());
        }

        [TestMethod]
        public void Test_HighScoreBoard_toString()
        {
            HighScoreBoard hsBoard = new HighScoreBoard();
            hsBoard.AddPlayer(new Player("Pesho", 123));
            string result = "ScoreBoard:\nEMPTY";
            Assert.AreNotEqual(result, hsBoard.ToString());
        }

        [TestMethod]
        public void Test_HighScoreBoard_Sort()
        {
            HighScoreBoard hsBoard = new HighScoreBoard();
            hsBoard.AddPlayer(new Player("Pesho", 123));
            hsBoard.AddPlayer(new Player("Pesho", 124));
            hsBoard.AddPlayer(new Player("Pesho", 120));
            hsBoard.AddPlayer(new Player("Pesho", 99));
            hsBoard.AddPlayer(new Player("Pesho", 999));
            StringBuilder result = new StringBuilder();
            result.AppendLine("Scoreboard:");
            result.AppendLine("1. Pesho : 99;");
            result.AppendLine("2. Pesho : 120;");
            result.AppendLine("3. Pesho : 123;");
            result.AppendLine("4. Pesho : 124;");
            result.AppendLine("5. Pesho : 999;");
            Assert.AreEqual(result.ToString(), hsBoard.ToString());
        }

        [TestMethod]
        public void Test_HighScoreBoard_ManyPlayers()
        {
            HighScoreBoard hsBoard = new HighScoreBoard();
            hsBoard.AddPlayer(new Player("Pesho", 123));
            hsBoard.AddPlayer(new Player("Pesho", 1240));
            hsBoard.AddPlayer(new Player("Pesho", 120));
            hsBoard.AddPlayer(new Player("Pesho", 99));
            hsBoard.AddPlayer(new Player("Pesho", 999));
            hsBoard.AddPlayer(new Player("Pesho", 85));
            hsBoard.AddPlayer(new Player("Pesho", 9990));
            StringBuilder result = new StringBuilder();
            result.AppendLine("Scoreboard:");
            result.AppendLine("1. Pesho : 85;");
            result.AppendLine("2. Pesho : 99;");
            result.AppendLine("3. Pesho : 120;");
            result.AppendLine("4. Pesho : 123;");
            result.AppendLine("5. Pesho : 999;");
            Assert.AreEqual(result.ToString(), hsBoard.ToString());
        }
    }
}
