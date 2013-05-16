using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;

namespace IgraS15
{
        static class Command
        {
            private enum Commands { restart, top, exit };

            public static string CommandType(string input)
            {
                string inputToLower = input.ToLower();
                string output;

                if (inputToLower == Commands.exit.ToString() || inputToLower == Commands.restart.ToString() || inputToLower == Commands.top.ToString())
                {
                    output = inputToLower;
                }
                else
                {
                    throw new ArgumentException("Invalid Command!");
                }

                return output;
            }

            public static void DisplayIllegalAction()
            {
                Console.SetCursorPosition(24, 15);
                Console.Write("Illegal move!");
                Thread.Sleep(1000);
                Console.SetCursorPosition(24, 15);
                Console.Write("             ");
                Console.SetCursorPosition(0, 15);
                Thread.Sleep(0);
            }

        }
    
}
