using System;
using Game_Fifteen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameFifteen.Tests
{
    [TestClass]
    public class GameFieldTests
    {
        [TestMethod]
        public void Test_GameField_Init()
        {
            GameField field = new GameField();
            int[,] initField = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Assert.AreEqual(initField[row, col], field.Field[row, col]);
                }
            }
           
        }
    }
}
