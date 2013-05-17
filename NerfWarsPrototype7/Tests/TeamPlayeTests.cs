using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard
{
    [TestClass]
    public class TeamPlayeTests
    {
        [TestMethod]
        public void TeamPlayinitializeTest()
        {
            List<string> playerNames = setPlayerNames();
            string teamName = "Crazy 8's";

            TeamPlay teamPlayTest = new TeamPlay(playerNames, teamName);
            Assert.AreEqual(playerNames, teamPlayTest.GetPlayerNames());
            Assert.AreEqual(teamName, teamPlayTest.GetTeamName());
            Assert.AreEqual(0, teamPlayTest.GetTag());
            Assert.AreEqual(0, teamPlayTest.GetFlag());
        }

        private List<string> setPlayerNames()
        {
            List<string> playerNames = new List<string>();
            playerNames.Add("John");
            playerNames.Add("Mary");
            playerNames.Add("Jill");
            playerNames.Add("Bob");
            
            return playerNames;
        }

        [TestMethod]
        public void TeamPlayCapTest()
        {
            List<string> playerNames = setPlayerNames();
            string teamName = "Crazy 8's";

            TeamPlay teamPlayTest = new TeamPlay(playerNames, teamName);
            teamPlayTest.AddFlag();
            Assert.AreEqual(1, teamPlayTest.GetFlag());
            teamPlayTest.MinusFlag();
            Assert.AreEqual(0, teamPlayTest.GetFlag());
        }

        [TestMethod]
        public void TeamPlayTagTest()
        {
            List<string> playerNames = setPlayerNames();
            string teamName = "Crazy 8's";

            TeamPlay teamPlayTest = new TeamPlay(playerNames, teamName);
            teamPlayTest.AddTag();
            Assert.AreEqual(1, teamPlayTest.GetTag());
            teamPlayTest.MinusTag();
            Assert.AreEqual(0, teamPlayTest.GetTag());
        }
        [TestMethod]
        public void TeamPlayScoreTest()
        {
            List<string> playerNames = setPlayerNames();
            string teamName = "Crazy 8's";

            TeamPlay teamPlayTest = new TeamPlay(playerNames, teamName);
            teamPlayTest.AddFlag();
            teamPlayTest.AddTag();
            teamPlayTest.AddTag();
            teamPlayTest.AddTag();

            Assert.AreEqual(1, teamPlayTest.GetFlag());
            Assert.AreEqual(3, teamPlayTest.GetTag());
            Assert.AreEqual(8, teamPlayTest.GetScore());
        }
    }
}
