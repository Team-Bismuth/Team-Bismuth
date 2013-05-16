using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Fifteen
{
    class Engine
    {
        public const int DirectionUp = 1;
        public const int DirectionRight = 2;
        public const int DirectionDown = 3;
        public const int DirectionLeft = 4;

        private static Random randomGenerator = new Random();

        private GameField gameField;
        private int movesCounter;
        private HighScoreBoard highScore;

        public HighScoreBoard HighScore
        {
            get { return highScore; }
            set { highScore = value; }
        }
        

        public int MovesCounter
        {
            get { return movesCounter; }
            set { movesCounter = value; }
        }
        

        public GameField GameField
        {
            get { return gameField; }
            set { gameField = value; }
        }
        
        public Engine()
        {
            this.GameField = new GameField();
            this.MovesCounter = 0;
            this.HighScore = new HighScoreBoard();
        }


        public void GenerateTable()
        {
            int[] zeroPos = new int[2] { 3, 3 };
            int stepBack = 0;
            for (int i = 0; i < 256; i++)
            {
                int direction = randomGenerator.Next(1, 5);
                if (direction != stepBack)
                {
                    stepBack = (direction > 2) ? stepBack = direction - 2 : stepBack = direction + 2;

                    if (direction == DirectionUp)
                    {
                        if (zeroPos[0] > 0)
                        {
                            int oldValue = this.gameField.Field[zeroPos[0] - 1, zeroPos[1]];
                            this.gameField.Field[zeroPos[0] - 1, zeroPos[1]] = 0;
                            this.gameField.Field[zeroPos[0], zeroPos[1]] = oldValue;
                            zeroPos[0] = zeroPos[0] - 1;
                        }
                        else
                        {
                            direction++;
                        }
                    }

                    if (direction == DirectionRight)
                    {
                        if (zeroPos[1] < 3)
                        {
                            int oldValue = this.gameField.Field[zeroPos[0], zeroPos[1] + 1];
                            this.gameField.Field[zeroPos[0], zeroPos[1] + 1] = 0;
                            this.gameField.Field[zeroPos[0], zeroPos[1]] = oldValue;
                            zeroPos[1] = zeroPos[1] + 1;
                        }
                        else
                        {
                            direction++;
                        }
                    }

                    if (direction == DirectionDown)
                    {
                        if (zeroPos[0] < 3)
                        {
                            int oldValue = this.gameField.Field[zeroPos[0] + 1, zeroPos[1]];
                            this.gameField.Field[zeroPos[0] + 1, zeroPos[1]] = 0;
                            this.gameField.Field[zeroPos[0], zeroPos[1]] = oldValue;
                            zeroPos[0] = zeroPos[0] + 1;
                        }
                        else
                        {
                            direction++;
                        }
                    }

                    if (direction == DirectionLeft)
                    {
                        if (zeroPos[1] > 0)
                        {
                            int oldValue = this.gameField.Field[zeroPos[0], zeroPos[1] - 1];
                            this.gameField.Field[zeroPos[0], zeroPos[1] - 1] = 0;
                            this.gameField.Field[zeroPos[0], zeroPos[1]] = oldValue;
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

        public void Move(int number)
        {
            for (int rows = 0; rows < 4; rows++)
            {
                for (int cols = 0; cols < 4; cols++)
                {
                    if (this.gameField.Field[rows, cols] == number)
                    {
                        if (CheckPositionUp(this.gameField.Field, rows, cols))
                        {
                            this.gameField.Field[rows, cols] = 0;
                            this.gameField.Field[rows - 1, cols] = number;
                        }
                        else if (CheckPositionDown(this.gameField.Field, rows, cols))
                        {
                            this.gameField.Field[rows, cols] = 0;
                            this.gameField.Field[rows + 1, cols] = number;
                        }
                        else if (CheckPositionLeft(this.gameField.Field, rows, cols))
                        {
                            this.gameField.Field[rows, cols] = 0;
                            this.gameField.Field[rows, cols - 1] = number;
                        }
                        else if (CheckPositionRight(this.gameField.Field, rows, cols))
                        {
                            this.gameField.Field[rows, cols] = 0;
                            this.gameField.Field[rows, cols + 1] = number;
                        }
                        else
                        {
                            Command.DisplayIllegalBlinkMessage(24, 16, "Illegal Move!", 0, 16);
                            return;
                        }

                        this.movesCounter++;
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

        public bool isGameSolved()
        {
            if (this.gameField.Field[3, 3] == 0)
            {
                int number = 1;
                for (int row = 0; row < this.gameField.Field.GetLength(0); row++)
                {
                    for (int col = 0; col < this.gameField.Field.GetLength(1); col++)
                    {
                        if (number <= 15)
                        {
                            if (this.gameField.Field[row, col] == number)
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

        public void RestartGame()
        {
            this.gameField=new GameField();
            this.GenerateTable();
            Console.SetCursorPosition(0, 9);
            this.gameField.PrintField();
        }

        public void StartGame()
        {
            bool gameInProgress = true;
            while (gameInProgress)
            {
                GenerateTable();
                Command.PrintGameInitializeInfo();
                Console.SetCursorPosition(0, 9);
                this.gameField.PrintField();
                bool isSolved = isGameSolved();
                while (!isSolved)
                {
                    Console.Write("Enter a number to move: ");
                    string command = Console.ReadLine();
                    int number = 0;

                    Console.SetCursorPosition(24, 16);
                    Console.Write(new string(' ', command.Length));

                    bool isMoveCommand = int.TryParse(command, out number);
                    if (isMoveCommand)
                    {
                        if (number >= 1 && number <= 15)
                        {
                            Move(number);
                            Console.SetCursorPosition(0, 9);
                            this.gameField.PrintField();
                        }
                        else
                        {
                            Command.DisplayIllegalBlinkMessage(24, 16, "Illegal Move!", 0, 16);
                        }
                    }
                    else
                    {
                        if (Command.CommandType(command)==Command.Commands.exit.ToString())
                        {
                            Console.SetCursorPosition(0, 17);
                            Command.PrintGameAboutInfo();
                            gameInProgress = false;
                            break;
                        }
                        else if (Command.CommandType(command) == Command.Commands.restart.ToString())
                        {
                            RestartGame();
                        }
                        else if (Command.CommandType(command) == Command.Commands.top.ToString())
                        {
                            Console.SetCursorPosition(0, 17);
                            Console.WriteLine(this.highScore.ToString());
                        }
                        else
                        {
                            Command.DisplayIllegalBlinkMessage(24, 16, "Illegal Command!", 0, 16);
                        }
                    }

                    isSolved = isGameSolved();
                }

                if (isSolved)
                {
                    Console.WriteLine("Congratulations! You won the game in {0} moves.", this.movesCounter);

                    Console.Write("Please enter your name for the top scoreboard: ");

                    string nickname = Console.ReadLine();

                    Player player = new Player(nickname, this.movesCounter);

                    this.highScore.AddPlayer(player);
                    this.highScore.ToString();
                }
            }
        }
    }
}
