namespace Game_Fifteen
{
    using System;
    using System.Threading;

    public static class Command
    {
        public enum Commands
        {
            restart,
            top,
            exit
        }

        public static string CommandType(string input)
        {
            string inputToLower = input.ToLower();
            string output = string.Empty;

            if (inputToLower == Commands.exit.ToString() || inputToLower == Commands.restart.ToString() || inputToLower == Commands.top.ToString())
            {
                output = inputToLower;
                return output;
            }
            else
            {
                DisplayIllegalBlinkMessage(24, 16, "Illegal Command!", 0, 16);
            }

            return string.Empty;
        }

        public static void DisplayIllegalBlinkMessage(int left, int top, string message, int backLeft, int backTop)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(message);
            Thread.Sleep(900);
            Console.SetCursorPosition(left, top);
            Console.Write(new string(' ', message.Length));
            Console.SetCursorPosition(backLeft, backTop);
            Thread.Sleep(0);
        }

        public static void PrintGameInitializeInfo()
        {
            Console.WriteLine(
                "Let's play “GAME FIFTEEN”.\n" +
                "Try to arrange the numbers sequentially from  1 to 15.\n" +
                "\nCommands :\n" +
                "\t- \"<number>\": moves this number in the empty space;\n" +
                "\t- \"top\": shows the top scores;\n" +
                "\t- \"restart\": starts a new game;\n" +
                "\t- \"exit\": exits the application.\n");
        }

        public static void PrintGameAboutInfo()
        {
            Console.WriteLine(
                "\"GAME FIFTEEN\" v1.0\n" +
                "Copyright 2013 Telerik Academy, Team “Bismuth”.\n" +
                "All rights reserved.");
        }
    }
}
