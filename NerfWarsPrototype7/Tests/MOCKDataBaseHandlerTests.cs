using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NerfWarsLeaderboard.Utility;

namespace Tests
{
    [TestClass]
    public class MOCKDataBaseHandlerTests
    {
        [TestMethod]
        public void TestLoadPlayers()
        {
            DataBaseHandler dbHandler = new MOCKDataBaseHandler();
            List<Player> dbHandlerPlayers = dbHandler.loadPlayers();
            List<Player> testPlayers = loadTestPlayers();
            for (int i = 0; i < dbHandlerPlayers.Count; i++)
            {
                Assert.AreEqual(testPlayers[i], dbHandlerPlayers[i]);
            }
            Assert.AreNotEqual(testPlayers[0], testPlayers[1]);
            Assert.AreNotEqual(testPlayers[1], testPlayers[2]);
        }

        private List<Player> loadTestPlayers()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player("John", "Smith", 5, "Allow Smith", "444", "Sick"));
            players.Add(new Player("Mary", "Yohan", 5, "Allow Yohan", "444", "Sick"));
            players.Add(new Player("Jill", "Bowe", 5, "Allow Bowe", "444", "Sick"));
            players.Add(new Player("Bob", "Winter", 5, "Allow Winter", "444", "Sick"));

            return players;
        }

        [TestMethod]
        public void TestLoadTeams()
        {
            DataBaseHandler dbHandler = new MOCKDataBaseHandler();
            List<Team> dbHandlerTeams = dbHandler.loadTeams();
            List<Team> testTeams = loadTestTeams();
            for (int i = 0; i < dbHandlerTeams.Count; i++)
            {
                Assert.AreEqual(testTeams[i], dbHandlerTeams[i]);
            }
        }

        private List<Team> loadTestTeams()
        {
            List<Team> teams = new List<Team>();
            teams.Add(new Team("Wildcats", loadTestPlayers()));
            teams.Add(new Team("Super Awesome", loadTestPlayers()));
            teams.Add(new Team("The cool kids", loadTestPlayers()));
            return teams;
        }
    }
}
