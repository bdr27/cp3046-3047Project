using System;
using System.Diagnostics;
using LeaderBoardApp.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeaderBoardAppTests
{
    [TestClass]
    public class MatchTest
    {
        [TestMethod]
        public void MatchStringTest()
        {
            var match = new MatchResult();
            match.SetTeamAID(1);
            match.SetTeamBID(2);
            var scoreTeamA = new Score();
            var scoreTeamB = new Score();
            match.SetTeamAScore(scoreTeamA);
            match.SetTeamBScore(scoreTeamB);
            Assert.AreEqual(match.ToString(), "1: tag: 0, flag: 0, score 0, 2: tag: 0, flag: 0, score 0");
        }
    }
}
