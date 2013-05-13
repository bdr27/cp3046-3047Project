using System;
using System.Collections.Generic;
using System.Text;

namespace NerfWarsLeaderboard.Utility
{
    public class MOCKDataBaseHandler : DataBaseHandler
    {
        private List<Player> players;
        private List<Team> teams;

        public List<Player> loadPlayers()
        {
            players = new List<Player>();
            players.Add(new Player("John", "Smith", 5, "Allow Smith", "444", "Sick"));
            players.Add(new Player("Mary", "Yohan", 5, "Allow Yohan", "444", "Sick"));
            players.Add(new Player("Jill", "Bowe", 5, "Allow Bowe", "444", "Sick"));
            players.Add(new Player("Bob", "Winter", 5, "Allow Winter", "444", "Sick"));
            return players;
        }

        public void savePlayers(List<Player> players)
        {
            throw new NotImplementedException();
        }

        public void saveTeams(List<Team> teams)
        {
            throw new NotImplementedException();
        }

        public List<Team> loadTeams()
        {
            List<Team> teams = new List<Team>();
            teams.Add(new Team("Wildcats", loadPlayers()));
            teams.Add(new Team("Super Awesome", loadPlayers()));
            teams.Add(new Team("The cool kids", loadPlayers()));
            return teams;
        }

        public void updatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public void insertPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public void deletePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public void updateTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void insertTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void deleteTeam(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
