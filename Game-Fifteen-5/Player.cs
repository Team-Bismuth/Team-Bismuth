namespace Game_Fifteen
{
    using System;

    public class Player : IComparable
    {
        public const string UnnamedPlayer = "Anonymous";

        private string name;
        private int moves;
       
        public Player(string name, int moves)
        {
            this.Name = name;
            this.Moves = moves;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.name = UnnamedPlayer;
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int Moves
        {
            get
            {
                return this.moves;
            }

            set
            {
                this.moves = value;
            }
        }

        public int CompareTo(object player)
        {
            Player currentPlayer = (Player)player;
            int result = this.moves.CompareTo(currentPlayer.Moves);
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0} : {1};", this.Name, this.Moves);
        }
    }
}
