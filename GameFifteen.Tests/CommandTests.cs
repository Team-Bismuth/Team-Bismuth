using System;
using Game_Fifteen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameFifteen.Tests
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void Test_Command_Output()
        {
            string command = "top";
            Assert.AreEqual(command,Command.CommandType(command));
        }

        [TestMethod]
        public void Test_Command_Output_NotACommand()
        {
            string command = "topp";
            Assert.AreEqual(string.Empty, Command.CommandType(command));
        }
    }
}
