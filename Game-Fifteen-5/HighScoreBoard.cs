namespace Game_Fifteen
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    public sealed class HighScoreBoard
    {
        private const int TopScoresToKeep = 5;

        private List<Player> players;

        public HighScoreBoard()
        {
            this.players = new List<Player>();
        }

        public IList<Player> Players
        {
            get
            {
                return new ReadOnlyCollection<Player>(this.players);
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
            this.players.Sort();
            this.DeleteAllExceptTopPlayers();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Scoreboard:");
            if (this.players == null || this.players.Count == 0)
            {
                result.AppendLine("EMPTY");
            }
            else
            {
                foreach (Player player in this.players)
                {
                    result.Append((this.players.IndexOf(player) + 1).ToString());
                    result.Append(". " + player.ToString());
                    result.AppendLine();
                }
            }

            return result.ToString();
        }

        private void DeleteAllExceptTopPlayers()
        {
            for (int index = 0; index < this.players.Count(); index++)
            {
                if (index > TopScoresToKeep - 1)
                {
                    this.players.Remove(this.players[index]);
                }
            }
        }
    }
}
