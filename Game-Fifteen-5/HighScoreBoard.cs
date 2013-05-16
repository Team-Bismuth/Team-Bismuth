using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace IgraS15
{
    public sealed class HighScoreBoard
    {
        private const int TopScoresToKeep = 5;

        private List<Player> players;

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
            DeleteAllExceptTopPlayers();
        }

        private void DeleteAllExceptTopPlayers()
        {
            for (int index = 0; index < this.players.Count(); index++)
            {
                if (index > TopScoresToKeep-1)
                {
                    this.players.Remove(players[index]);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Scoreboard:");
            foreach (Player player in this.players)
            {
                result.Append((this.players.IndexOf(player) + 1).ToString());
                result.Append(". " + player.ToString());
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}
