using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NerfWarsLeaderboard.Utility
{
    public class MOCKDataBaseHandler : DataBaseHandler
    {
        private Dictionary<int,Player> players;
        private Dictionary<int,Team> teams;
        private static int playerCounter = 0;
        private static int teamCounter = 0;

        public Dictionary<int,Player> LoadPlayers()
        {
            players = new Dictionary<int,Player>();
            players.Add(playerCounter++, new Player("John", "Smith", 5, "Allow Smith", "444", "Sick"));
            players.Add(playerCounter++, new Player("Mary", "Yohan", 5, "Allow Yohan", "444", "Sick"));
            players.Add(playerCounter++, new Player("Jill", "Bowe", 5, "Allow Bowe", "444", "Sick"));
            players.Add(playerCounter++, new Player("Bob", "Winter", 5, "Allow Winter", "444", "Sick"));
            return players;
        }

        public void SavePlayers(List<Player> players)
        {
            throw new NotImplementedException();
        }

        public void SaveTeams(List<Team> teams)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Team> LoadTeams()
        {
            teams = new Dictionary<int, Team>();
            teams.Add(teamCounter++, new Team("Wildcats", "47454545", players));
            teams.Add(teamCounter++, new Team("Super Awesome", "47454545", players));
            teams.Add(teamCounter++, new Team("The cool kids","47454545", players));
            return teams;
        }

        public void UpdatePlayer(Player player)
        {
            int ID = player.GetP_ID();
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].GetP_ID() == ID)
                {
                    players[i] = player;
                    break;
                }
            }
        }

        public void InsertPlayer(Player player)
        {
            players.Add(playerCounter, player);
        }

        public void DeletePlayer(int playerNumber)
        {
            players.Remove(playerNumber);
        }

        public void UpdateTeam(Team team)
        {
            //I do nothing in this version
        }

        public void InsertTeam(Team team)
        {
            teams.Add(playerCounter, team);
        }

        public void DeleteTeam(int teamCounter)
        {
            teams.Remove(teamCounter);
        }

        public Dictionary<int, Player> GetPlayers()
        {
            return players;
        }

        public Dictionary<int, Team> GetTeams()
        {
            return teams;
        }
    }
}
