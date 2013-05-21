using System;
using System.Collections.Generic;

namespace NerfWarsLeaderboard.Utility
{
    public class Team
    {
        private List<Player> players;
        private string tName;
        private string contact;

        public Team()
        {
            players = new List<Player>();
        }

        public Team(string tName, string contact, List<Player> playerNames)
        {
            this.tName = tName;
            this.players = playerNames;
            this.contact = contact;
        }

        public void SetTName(string tName)
        {
            this.tName = tName;
        }

        public void AddTeamPlayer(Player player)
        {
            players.Add(player);
        }

        public void SetPlayerNames(List<Player> player)
        {
            this.players = player;
        }

        public string GetTeamName()
        {
            return tName;
        }

        public List<string> GetPlayerFirstName()
        {
            List<string> playerNames = new List<string>();
            foreach (var player in players)
            {
                playerNames.Add(player.GetFName());
            }
            return playerNames;
        }
        public void SetContact(string contact)
        {
            this.contact = contact;
        }

        public override string ToString()
        {
            return tName;
        }

        public override bool Equals(object obj)
        {
            Team other;
            try
            {
                other = obj as Team;
                if (other != null)
                {
                    if (tName.Equals(other.tName))
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
            }
            catch (Exception)
            {
                //Wrong object entered
            }
            return false;
        }
    }
}
