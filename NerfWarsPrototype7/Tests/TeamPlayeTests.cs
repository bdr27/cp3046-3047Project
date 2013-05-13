using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NerfWars.Utility;

namespace NerfWars
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
            Assert.AreEqual(playerNames, teamPlayTest.getPlayerNames());
            Assert.AreEqual(teamName, teamPlayTest.getTeamName());
            Assert.AreEqual(0, teamPlayTest.getTag());
            Assert.AreEqual(0, teamPlayTest.getFlag());
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
            teamPlayTest.addFlag();
            Assert.AreEqual(1, teamPlayTest.getFlag());
            teamPlayTest.minusFlag();
            Assert.AreEqual(0, teamPlayTest.getFlag());
        }

        [TestMethod]
        public void TeamPlayTagTest()
        {
            List<string> playerNames = setPlayerNames();
            string teamName = "Crazy 8's";

            TeamPlay teamPlayTest = new TeamPlay(playerNames, teamName);
            teamPlayTest.addTag();
            Assert.AreEqual(1, teamPlayTest.getTag());
            teamPlayTest.minusTag();
            Assert.AreEqual(0, teamPlayTest.getTag());
        }
        [TestMethod]
        public void TeamPlayScoreTest()
        {
            List<string> playerNames = setPlayerNames();
            string teamName = "Crazy 8's";

            TeamPlay teamPlayTest = new TeamPlay(playerNames, teamName);
            teamPlayTest.addFlag();
            teamPlayTest.addTag();
            teamPlayTest.addTag();
            teamPlayTest.addTag();

            Assert.AreEqual(1, teamPlayTest.getFlag());
            Assert.AreEqual(3, teamPlayTest.getTag());
            Assert.AreEqual(8, teamPlayTest.getScore());
        }
    }
}
