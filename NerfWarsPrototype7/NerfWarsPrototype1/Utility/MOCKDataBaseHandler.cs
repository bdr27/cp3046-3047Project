using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NerfWarsLeaderboard.Utility
{
    public class MOCKDataBaseHandler : DataBaseHandler
    {
        private List<Player> players;
        private List<Team> teams;

        public List<Player> LoadPlayers()
        {
            players = new List<Player>();
            players.Add(new Player("John", "Smith", 5, "Allow Smith", "444", "Sick"));
            players.Add(new Player("Mary", "Yohan", 5, "Allow Yohan", "444", "Sick"));
            players.Add(new Player("Jill", "Bowe", 5, "Allow Bowe", "444", "Sick"));
            players.Add(new Player("Bob", "Winter", 5, "Allow Winter", "444", "Sick"));
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

        public List<Team> LoadTeams()
        {
            teams = new List<Team>();
            teams.Add(new Team("Wildcats", "47454545", players));
            teams.Add(new Team("Super Awesome", "47454545", players));
            teams.Add(new Team("The cool kids","47454545", players));
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
            players.Add(player);
        }

        public void DeletePlayer(Player player)
        {
            players.Remove(player);
        }

        public void UpdateTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void InsertTeam(Team team)
        {
            teams.Add(team);
        }

        public void DeleteTeam(Team team)
        {
            teams.Remove(team);
        }

        public List<Player> GetPlayers()
        {
            return players;
        }

        public List<Team> GetTeams()
        {
            return teams;
        }
    }
}
