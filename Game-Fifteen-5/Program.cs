namespace Game_Fifteen
{
    using System;
    using System.Text;
    using System.Threading;
    public class Program
    {
        public static int[,] gameField = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };

        public static int counter=0;
        public static string[] topScorers = new string[5];
        public static int topCount = 0;
        private const int TOP_SCORES_TO_KEEP = 5;
        private const int FIELD_ROWS = 4;
        private const int FIELD_COLS = 4;

        private static Random randomGenerator = new Random();

        static void PrintTable()
        {
            StringBuilder printer = new StringBuilder();
            printer.AppendLine(" ------------- ");
            for (int row = 0; row < FIELD_ROWS; row++)
            {
                printer.Append("| ");
                for (int col = 0; col < FIELD_COLS; col++)
                {
                    if (gameField[row, col] < 10 && gameField[row, col] != 0)
                    {
                        printer.AppendFormat(" {0} ", gameField[row, col]);
                    }
                    else if (gameField[row, col] >= 10)
                    {
                        printer.AppendFormat("{0} ", gameField[row, col]);
                    }
                    else if (gameField[row, col] == 0)
                    {
                        printer.AppendFormat("   ");
                    }
                }

                printer.AppendLine("|");
            }

            printer.AppendLine(" ------------- ");

            Console.SetCursorPosition(0, 9);
            Console.Write(printer.ToString());

        }      

        static void GenerateTableNEW()
        {
            int[] zeroPos = new int[2] { 3, 3 };
            int stepBack = 0;
            for (int i = 0; i < 256; i++)
            {
                int direction = randomGenerator.Next(1, 5);
                if (direction != stepBack)
                {
                    stepBack = direction;

                    if (direction == 1)
                    {
                        if (zeroPos[0] > 0)
                        {
                            int oldValue = gameField[zeroPos[0] - 1, zeroPos[1]];
                            gameField[zeroPos[0] - 1, zeroPos[1]] = 0;
                            gameField[zeroPos[0], zeroPos[1]] = oldValue;
                            zeroPos[0] = zeroPos[0] - 1;
                        }
                        else
                        {
                            direction++;
                        }
                    }

                    if (direction == 2)
                    {
                        if (zeroPos[1] < 3)
                        {
                            int oldValue = gameField[zeroPos[0], zeroPos[1] + 1];
                            gameField[zeroPos[0], zeroPos[1] + 1] = 0;
                            gameField[zeroPos[0], zeroPos[1]] = oldValue;
                            zeroPos[1] = zeroPos[1] + 1;
                        }
                        else
                        {
                            direction++;
                        }
                    }

                    if (direction == 3)
                    {
                        if (zeroPos[0] < 3)
                        {
                            int oldValue = gameField[zeroPos[0] + 1, zeroPos[1]];
                            gameField[zeroPos[0] + 1, zeroPos[1]] = 0;
                            gameField[zeroPos[0], zeroPos[1]] = oldValue;
                            zeroPos[0] = zeroPos[0] + 1;
                        }
                        else
                        {
                            direction++;
                        }
                    }

                    if (direction == 4)
                    {
                        if (zeroPos[1] > 0)
                        {
                            int oldValue = gameField[zeroPos[0], zeroPos[1] - 1];
                            gameField[zeroPos[0], zeroPos[1] - 1] = 0;
                            gameField[zeroPos[0], zeroPos[1]] = oldValue;
                            zeroPos[1] = zeroPos[1] - 1;
                        }
                        else
                        {
                            direction--;
                        }
                    }

                }
                else
                {
                    i--;
                }
            }
        
        }

        static void MoveNEW(int number)
        {
            for (int rows = 0; rows < 4; rows++)
            {
                for (int cols = 0; cols < 4; cols++)
                {
                    if (gameField[rows, cols] == number)
                    {
                        if (CheckPositionUp(gameField, rows, cols))
                        {
                            gameField[rows, cols] = 0;
                            gameField[rows - 1, cols] = number;
                        }
                        else if (CheckPositionDown(gameField, rows, cols))
                        {
                            gameField[rows, cols] = 0;
                            gameField[rows + 1, cols] = number;
                        }
                        else if (CheckPositionLeft(gameField, rows, cols))
                        {
                            gameField[rows, cols] = 0;
                            gameField[rows, cols - 1] = number;
                        }
                        else if (CheckPositionRight(gameField, rows, cols))
                        {
                            gameField[rows, cols] = 0;
                            gameField[rows, cols + 1] = number;
                        }
                        else
                        {
                            DisplayIllegalAction();
                            return;
                        }

                        counter++;
                        return;
                    }
                }
            }

            return;
        }

        static bool CheckPositionUp(int[,] gameField, int row, int col)
        {
            if (row > 0)
            {
                if (gameField[row - 1, col] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static bool CheckPositionDown(int[,] gameField, int row, int col)
        {
            if (row < 3)
            {
                if (gameField[row + 1, col] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static bool CheckPositionLeft(int[,] gameField, int row, int col)
        {
            if (col > 0)
            {
                if (gameField[row, col - 1] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static bool CheckPositionRight(int[,] gameField, int row, int col)
        {
            if (col < 3)
            {
                if (gameField[row, col + 1] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void DisplayIllegalAction()
        {
            Console.SetCursorPosition(24, 15);
            Console.Write("Illegal move!");
            Thread.Sleep(1000);
            Console.SetCursorPosition(24, 15);
            Console.Write("             ");
            Console.SetCursorPosition(0, 15);
            Thread.Sleep(0);
        }

        static bool isGameSolved()
        {
            if (gameField[3, 3] == 0)
            {
                int number = 1;
                for (int row = 0; row < FIELD_ROWS; row++)
                {
                    for (int col = 0; col < FIELD_COLS; col++)
                    {
                        if (number <= 15)
                        {
                            if (gameField[row, col] == number)
                            {
                                number++;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        static void RestartGame()
        {
            GenerateTableNEW();
            PrintTable();
        }

        static void AddAndSort(int i, string result)
        {
            if (i == 0)
            {
                topScorers[i] = result;
            }

            for (int j = 0; j < i; j++)
            {
                topScorers[j] = topScorers[j + 1];
            }

            topScorers[i] = result;
        }

        static void PrintTop()
        {
            Console.WriteLine("\nScoreboard:");
            if (topCount != 0)
            {
                for (int i = 5 - topCount; i < 5; i++)
                {
                    Console.WriteLine("{0}", topScorers[i]);
                }
            }
            else
            {
                Console.WriteLine("-");
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            bool gameInProgress = true;
            while (gameInProgress)
            {
               GenerateTableNEW();
                PrintGameInitializeInfo();
                PrintTable();
                bool isSolved = isGameSolved();
                while (!isSolved)
                {
                    Console.Write("Enter a number to move: ");
                    string command = Console.ReadLine();
                    int number = 0;

                    Console.SetCursorPosition(24, 15);
                    Console.Write(new string(' ',command.Length));

                    bool isMoveCommand = int.TryParse(command, out number);
                    if (isMoveCommand)
                    {
                        if (number >= 1 && number <= 15)
                        {                       
                            MoveNEW(number);
                            PrintTable();
                        }
                        else
                        {
                            DisplayIllegalAction();
                        }
                    }
                    else
                    {
                        if (command == "exit")
                        {
                            PrintGameAboutInfo();
                            gameInProgress = false;
                            break;
                        }
                        else if (command == "restart")
                        {
                            RestartGame();
                        }
                        else if (command == "top")
                        {
                            PrintTop();
                        }
                        else
                        {
                            Console.SetCursorPosition(24, 15);
                            Console.Write("Illegal command!");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(24, 15);
                            Console.Write("                ");
                            Console.SetCursorPosition(0, 15);
                            Thread.Sleep(0);
                        }
                    }

                    isSolved = isGameSolved();
                }

                if (isSolved)
                {
                    Console.WriteLine("Congratulations! You won the game in {0} moves.", counter);

                    Console.Write("Please enter your name for the top scoreboard: ");

                    string nickname = Console.ReadLine();

                    string result = counter + " moves by " + nickname;

                    if (topCount < 5)
                    {
                        topScorers[topCount] = result;

                        topCount++;

                        Array.Sort(topScorers);
                    }
                    else
                    {
                        for (int i = TOP_SCORES_TO_KEEP - 1; i >= 0; i++)
                        {
                            if (topScorers[i].CompareTo(result) <= 0)
                            {
                                AddAndSort(i, result);
                            }
                        }
                    }

                    PrintTop();
                }
            }
        }
        private static void PrintGameInitializeInfo()
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

        private static void PrintGameAboutInfo()
        {
            Console.WriteLine(
                "\"GAME FIFTEEN\" v1.0\n" +
                "Copyright 2013 Telerik Academy, Team “Bismuth”.\n" +
                "All rights reserved.");
        }
    }
}
