using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeaderBoardApp.Utility;
using System.Collections.Generic;

namespace LeaderBoardAppTests
{
    [TestClass]
    public class LadderTierTests
    {
        [TestMethod]
        public void LadderTierRandomLadderTest()
        {
            var lt = new LadderTier();
            var totalTeams = 22;
            var teamIDs = GetTeamIDs(totalTeams);
            var testIds = GetTeamIDs(totalTeams);
            lt.GenerateMatches(teamIDs);
            var matches = lt.GetAllMatches();
            foreach (var match in matches.Values)
            {
                Assert.IsTrue(testIds.Contains(match.GetTeamAID()));
                Assert.IsTrue(testIds.Contains(match.GetTeamBID()));
            }
            Assert.AreEqual(6, matches.Count);
        }

        [TestMethod]
        public void LadderTierExactLadderTest()
        {
            var lt = new LadderTier();
            var totalTeams = 16;
            var teamIDs = GetTeamIDs(totalTeams);
            var testIds = GetTeamIDs(totalTeams);
            lt.GenerateMatches(teamIDs);
            var matches = lt.GetAllMatches();
            foreach (var match in matches.Values)
            {
                Assert.IsTrue(testIds.Contains(match.GetTeamAID()));
                Assert.IsTrue(testIds.Contains(match.GetTeamBID()));
            }
            Assert.AreEqual(8, matches.Count);
        }

        private List<int> GetTeamIDs(int tt)
        {
            var teams = new List<int>();
            for (int i = 0; i < tt; i++)
            {
                teams.Add(i + 1);
            }
            return teams;

        }

        [TestMethod]
        public void LadderTierAllMatchesNotPlayed()
        {
            var lt = new LadderTier();
            var totalTeams = 16;
            var teamIDs = GetTeamIDs(totalTeams);
            lt.GenerateMatches(teamIDs);
            Assert.IsFalse(lt.AllMatchesPlayed());
        }

        [TestMethod]
        public void LadderTierAllMatchesPlayed()
        {
            var lt = new LadderTier();
            var totalTeams = 16;
            var teamIDs = GetTeamIDs(totalTeams);
            lt.GenerateMatches(teamIDs);
            var matches = lt.GetAllMatches();
            var scoreA = new Score();
            scoreA.AddFlag();
            var scoreB = new Score();
            scoreB.AddTag();
            foreach (var match in matches)
            {
                var key = match.Key;
                var value = match.Value;
                var teamAID = match.Value.GetTeamAID();
                value.SetTeamAScore(scoreA);
                value.SetTeamBScore(scoreB);
                lt.SetMatch(key, value);
                Assert.AreEqual(teamAID, lt.GetWinner(key));
            }
            Assert.IsTrue(lt.AllMatchesPlayed());
        }

        [TestMethod]
        public void LadderTierUnplayedMatches()
        {
            var lt = new LadderTier();
            var totalTeams = 16;
            var teamIDs = GetTeamIDs(totalTeams);
            lt.GenerateMatches(teamIDs);
            var matches = lt.GetAllMatches();
            var scoreA = new Score();
            scoreA.AddFlag();
            var scoreB = new Score();
            scoreB.AddTag();
            int i = 0;
            foreach (var match in matches)
            {
                if (i == 4)
                {
                    break;
                }
                var key = match.Key;
                var value = match.Value;
                var teamAID = match.Value.GetTeamAID();
                value.SetTeamAScore(scoreA);
                value.SetTeamBScore(scoreB);
                lt.SetMatch(key, value);
                Assert.AreEqual(teamAID, lt.GetWinner(key));
                i++;
            }
            var played = lt.GetAllUnplayedMatches();
            Assert.AreEqual(4, played.Count);
        }
    }
}
