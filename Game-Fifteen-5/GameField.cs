namespace Game_Fifteen
{
    using System;
    using System.Text;

    public class GameField
    {
        private const int FieldRows = 4;
        private const int FieldCols = 4;

        private int[,] field;
        
        public GameField()
        {
            this.Field = new int[FieldRows, FieldCols] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
        }

        public int[,] Field
        {
            get { return this.field; }
            set { this.field = value; }
        }

        public void PrintField()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder printer = new StringBuilder();
            printer.AppendLine(" ------------- ");
            for (int row = 0; row < FieldRows; row++)
            {
                printer.Append("| ");
                for (int col = 0; col < FieldCols; col++)
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
        }
    }
}
