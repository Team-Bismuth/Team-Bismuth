using System;
using Game_Fifteen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameFifteen.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Test_Player_Constructor()
        {
            Player player = new Player("Pesho", 123);
            string name = "Pesho";
            Assert.AreEqual(name, player.Name);
        }

        [TestMethod]
        public void Test_Player_WithoutName()
        {
            Player player = new Player("", 123);
            string name = "Anonymous";
            Assert.AreEqual(name, player.Name);
        }

        [TestMethod]
        public void Test_Player_CompareTo()
        {
            Player player = new Player("Pesho", 123);
            Player player1 = new Player("Gosho", 124);
            int expected = -1;
            Assert.AreEqual(expected, player.CompareTo(player1));
        }

        [TestMethod]
        public void Test_Player_ToString()
        {
            Player player = new Player("Pesho", 123);
            string result = "Pesho : 123;";
            Assert.AreEqual(result, player.ToString());
        }
    }
}
