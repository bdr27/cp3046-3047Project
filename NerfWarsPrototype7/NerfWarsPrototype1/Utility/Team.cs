using System;
using System.Collections.Generic;

namespace NerfWarsLeaderboard.Utility
{
    public class Team
    {
        private List<Player> players;
        private string teamName;

        public Team()
        {
            players = new List<Player>();
        }

        public Team(string teamName, List<Player> playerNames)
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

        public override bool Equals(object obj)
        {
            Team other;
            try
            {
                other = obj as Team;
                if (teamName.Equals(other.teamName))
                {
                    //Checks all the players in team A are not in team B
                    for (int i = 0; i < players.Count; i++)
                    {
                        //Checks if player name is not in other team
                        bool validPlayer = false;
                        for (int j = 0; j < other.players.Count; j++)
                        {
                            if (players[i].Equals(other.players[j]))
                            {
                                validPlayer = true;
                                break;
                            }
                        }
                        if (!validPlayer)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                //Wrong object entered
            }
            return false;
        }
    }
}
