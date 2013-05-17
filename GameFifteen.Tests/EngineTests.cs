using System;
using Game_Fifteen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameFifteen.Tests
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void Test_Engine_Construct()
        {
            Engine engine = new Engine();
            int moves = 0;
            int hsBoardCount = 0;
            Assert.AreEqual(moves, engine.MovesCounter);
            Assert.AreEqual(hsBoardCount, engine.HighScore.Players.Count);
        }
    }
}
