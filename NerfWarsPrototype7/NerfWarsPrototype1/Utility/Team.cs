using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Team
    {
        private List<Player> players;
        private string teamName;

        public Team()
        {
            players = new List<Player>();
        }

        public Team(List<Player> playerNames, string teamName)
        {
            this.teamName = teamName;
            this.players = playerNames;
        }

        public void SetTeamName(string teamName)
        {
            this.teamName = teamName;
        }

        public void AddTeamPlayer(Player player)
        {
            players.Add(player);
        }

        public void SetPlayerNames(List<Player> player)
        {
            this.players = player;
        }

        public string getTeamName()
        {
            return teamName;
        }

        public List<string> getPlayerFirstName()
        {
            List<string> playerNames = new List<string>();
            foreach (var player in players)
            {
                playerNames.Add(player.getFirstName());
            }
            return playerNames;
        }

        public override string ToString()
        {
            return teamName;
        }
    }
}
