using System;
using System.Collections.Generic;

namespace NerfWarsLeaderboard.Utility
{
    public class Team
    {
        private Dictionary<int,Player> players;
        private string tName;
        private string contact;

        public Team()
        {
            players = new Dictionary<int,Player>();
        }

        public Team(string tName, string contact, Dictionary<int, Player> playerNames)
        {
            this.tName = tName;
            this.players = playerNames;
            this.contact = contact;
        }

        public void SetTName(string tName)
        {
            this.tName = tName;
        }

        public void AddTeamPlayer(Player player, int playerCount)
        {
            players.Add(playerCount, player);
        }

        public void SetPlayerNames(Dictionary<int, Player> player)
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
                var playerValues = player.Value;
                playerNames.Add(playerValues.GetFName());
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
