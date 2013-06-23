using System;
using System.Collections.Generic;
using LeaderBoardApp.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeaderBoardAppTests
{
    [TestClass]
    public class TeamTests
    {
        #region helper
        private Dictionary<int, Player> GetPlayers()
        {
            var players = new Dictionary<int, Player>();
            var playerCounter = 1;
            players.Add(playerCounter++, new Player("john", "smith", 24, "", "40404040", ""));
            players.Add(playerCounter++, new Player("Jill", "smith", 12, "", "40404034", ""));
            players.Add(playerCounter++, new Player("Geroge", "Lucas", 25, "Marie", "5556565", "I like starwars"));
            foreach (var player in players)
            {
                player.Value.SetP_ID(player.Key);
                Console.WriteLine("\t" + player.Value.Details());
            }
            return players;
        }
#endregion

        #region Clone Tests
        [TestMethod]
        public void TeamPlayerListCloneTest()
        {
            var players = new List<int>();
            foreach (var player in GetPlayers())
            {
                players.Add(player.Key);
            }
            var team = new Team("WildCats", "4545454", players);
            Assert.AreSame(team.GetPlayerIDs(), players);
            Assert.AreNotSame(team.ClonePlayerIDs(), players);
        }

        [TestMethod]
        public void TeamCloneTest()
        {
            var players = new List<int>();
            foreach (var player in GetPlayers())
            {
                players.Add(player.Key);
            }
            var team = new Team("WildCats", "4545454", players);
            Assert.AreNotSame(team, team.Clone());
        }
        #endregion

        #region AddPlayer Tests
        [TestMethod]
        public void TeamTestAddPlayers()
        {
            var team = new Team("Wildcats", "47404049", new List<int>());
            var players = GetPlayers();
            foreach(var player in players)
            {
                team.AddPlayer(player.Value.GetP_ID());
            }
            var teamPlayers = team.GetPlayerIDs();

            foreach (var player in players)
            {
                Assert.IsTrue(teamPlayers.Contains(player.Value.GetP_ID()));
            }
        }
        #endregion

        #region IsValidTeam Tests

        [TestMethod]
        public void TeamTestIsNotValidTeam()
        {
            var team = new Team("","", new List<int>());
            Assert.IsFalse(team.IsValidTeam());
        }

        [TestMethod]
        public void TeamTestIsValidTeam()
        {
            var team = new Team("Wildcats", "454545467", new List<int>());
            Assert.IsTrue(team.IsValidTeam());
        }

        #endregion

    }
}
