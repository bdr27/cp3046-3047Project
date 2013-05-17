using System;
using System.Collections.Generic;
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
            List<Team> teams = new List<Team>();
            teams.Add(new Team("Wildcats", LoadPlayers()));
            teams.Add(new Team("Super Awesome", LoadPlayers()));
            teams.Add(new Team("The cool kids", LoadPlayers()));
            return teams;
        }

        public void UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public void InsertPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public void DeletePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void InsertTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
