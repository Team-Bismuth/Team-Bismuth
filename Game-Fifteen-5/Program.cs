namespace Game_Fifteen
{
    using System;

    public class Program
    {
        public static int[,] a = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
        public static int x = 3; 
        public static int y = 3;
        public static bool repeat = true;
        public static int counter;           
        public static string[] topScorers = new string[5];
        public static int topCount = 0;
        private const int TOP_SCORES_TO_KEEP = 5;
        private const int FIELD_ROWS = 4;
        private const int FIELD_COLS = 4;

        private static Random randomGenerator = new Random();

        static void PrintTable()
        {
            Console.WriteLine(" ------------- ");
            for (int row = 0; row < FIELD_ROWS; row++)
            {
                Console.Write("| ");
                for (int col = 0; col < FIELD_COLS; col++)
                {
                    if (a[row, col] < 10 && a[row, col] != 0)
                    {
                        Console.Write(" {0} ", a[row, col]);
                    }
                    else if (a[row, col] >= 10)
                    {
                        Console.Write("{0} ", a[row, col]);
                    }
                    else if (a[row, col] == 0)
                    {
                            Console.Write("   ");
                    }                
                }

                Console.WriteLine("|");
            }

            Console.WriteLine(" ------------- ");
        }

        static void GenerateTable()
        {
            counter = 0;

            for (int i = 0; i < 1000; i++)
            {
                int n = randomGenerator.Next(3);
                if (n == 0)
                {
                    int nx = x - 1;
                    int ny = y;
                    if (nx >= 0 && nx <= 3 && ny >= 0 && ny <= 3)
                    {
                        int temp = a[x, y];
                        a[x, y] = a[nx, ny];
                        a[nx, ny] = temp;
                        x = nx;
                        y = ny;
                    }
                    else
                    {
                        n++;
                        i--;
                    }
                }

                if (n == 1)
                {
                    int nx = x;
                    int ny = y + 1;
                    if (nx >= 0 && nx <= 3 && ny >= 0 && ny <= 3)
                    {
                        int temp = a[x, y];
                        a[x, y] = a[nx, ny];
                        a[nx, ny] = temp;
                        x = nx;
                        y = ny;
                    }
                    else
                    {
                        n++;
                        i--;
                    }
                }

                if (n == 2)
                {
                    int nx = x + 1;
                    int ny = y;
                    if (nx >= 0 && nx <= 3 && ny >= 0 && ny <= 3)
                    {
                        int temp = a[x, y];
                        a[x, y] = a[nx, ny];
                        a[nx, ny] = temp;
                        x = nx;
                        y = ny;
                    }
                    else
                    {
                        n++;
                        i--;
                    }
                }

                if (n == 3)
                {
                    int nx = x;
                    int ny = y - 1;
                    if (nx >= 0 && nx <= 3 && ny >= 0 && ny <= 3)
                    {
                        int temp = a[x, y];
                        a[x, y] = a[nx, ny];
                        a[nx, ny] = temp;
                        x = nx;
                        y = ny;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
        }

        public static bool Proverka(int i, int j)
        {
            if ((i == x - 1 || i == x + 1) && j == y)
            {
                return true;
            }

            if ((i == x) && (j == y - 1 || j == y + 1))
            {
                return true;
            }

            return false;
        }

        public static void Move(int n)
        {
            int k = x;
            int l = y;
            bool flag = true;
            for (int i = 0; i < 4; i++)
            {
                if (flag)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (a[i, j] == n)
                        {
                            k = i;
                            l = j;
                            flag = false;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            bool flag2 = Proverka(k, l);
            if (!flag2)
            {
                Console.WriteLine("Illegal move!");
            }
            else
            {
                int temp = a[k, l];
                a[k, l] = a[x, y];
                a[x, y] = temp;
                x = k; 
                y = l;
                counter++;
                PrintTable();
            }
        }

        static bool Solved()
        {
            if (a[3, 3] == 0)
            {
                int n = 1;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (n <= 15)
                        {
                            if (a[i, j] == n)
                            {
                                n++;
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
            GenerateTable();
            PrintTable();
        }

        static void AddAndSort(int i, string res)
        {
            if (i == 0)
            {
                topScorers[i] = res;
            }

            for (int j = 0; j < i; j++)
            {
                topScorers[j] = topScorers[j + 1];
            }

            topScorers[i] = res;
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
            while (repeat)
            {
                GenerateTable();
                PrintGameInitializeInfo();
                PrintTable();
                bool isGameSolved = Solved();
                while (!isGameSolved)
                {
                    Console.Write("Enter a number to move: ");
                    string command = Console.ReadLine();
                    int number;
                    bool isMoveCommand = int.TryParse(command, out number);
                    if (isMoveCommand)
                    {
                        if (number >= 1 && number <= 15)
                        {
                            Move(number);
                        }
                        else
                        {
                            Console.WriteLine("Illegal move!");
                        }
                    }
                    else
                    {
                        if (command == "exit")
                        {
                            PrintGameAboutInfo();
                            repeat = false;
                            break;
                        }
                        else
                        {
                            if (command == "restart")
                            {
                                RestartGame();
                            }
                            else
                            {
                                if (command == "top")
                                {
                                    PrintTop();
                                }
                                else
                                {
                                    Console.WriteLine("Illegal command!");
                                }
                            }
                        }
                    }

                    isGameSolved = Solved();
                }

                if (isGameSolved)
                {
                    Console.WriteLine("Congratulations! You won the game in {0} moves.", counter);
                   
                    Console.Write("Please enter your name for the top scoreboard: ");
                   
                    string nickname = Console.ReadLine();
                  
                    string res = counter + " moves by " + nickname;

                    if (topCount < 5)
                    {
                        topScorers[topCount] = res;

                        topCount++;

                        Array.Sort(topScorers);
                    }
                    else
                    {
                        for (int i = 4; i >= 0; i++)
                        {
                            if (topScorers[i].CompareTo(res) <= 0)
                            {
                                AddAndSort(i, res);
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
                "\t- \"<number>\": moves this number in the empty space;\n"+
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
