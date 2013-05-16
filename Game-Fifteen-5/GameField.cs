using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IgraS15
{
    public class GameField
    {
        private const int FIELD_ROWS = 4;
        private const int FIELD_COLS = 4;


        private int[,] field;

        public int[,] Field
        {
            get { return field; }
            set { field = value; }
        }
        
        public GameField()
        {
            this.Field = new int[FIELD_ROWS, FIELD_COLS] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
        }

        public void PrintField()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder printer = new StringBuilder();
            printer.AppendLine(" ------------- ");
            for (int row = 0; row < FIELD_ROWS; row++)
            {
                printer.Append("| ");
                for (int col = 0; col < FIELD_COLS; col++)
                {
                    if (this.Field[row, col] < 10 && this.Field[row, col] != 0)
                    {
                        printer.AppendFormat(" {0} ", this.Field[row, col]);
                    }
                    else if (this.Field[row, col] >= 10)
                    {
                        printer.AppendFormat("{0} ", this.Field[row, col]);
                    }
                    else if (this.Field[row, col] == 0)
                    {
                        printer.AppendFormat("   ");
                    }
                }

                printer.AppendLine("|");
            }

            printer.AppendLine(" ------------- ");

            return printer.ToString();

            //Console.SetCursorPosition(0, 9);
            //Console.Write(printer.ToString());

        }
    }
}
