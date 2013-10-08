﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public class LadderTier
    {
        private Dictionary<int, MatchResult> matches;
        private List<int> currentTeams;

        public LadderTier()
        {
        }

        public Dictionary<int, MatchResult> GetMatches()
        {
            var tm = new Dictionary<int, MatchResult>();
            foreach (var match in matches)
            {
                tm.Add(match.Key, match.Value.Clone());
            }
            return tm;
        }

        public void GenerateMatches(List<int> teamIDs)
        {
            var cloneTeamIDs = LadderUtil.CloneIntList(teamIDs);
            matches = new Dictionary<int, MatchResult>();
            var totalTeams = cloneTeamIDs.Count;
            var totalMatches = 0;
            var nextTier = LadderUtil.GetTierCount(totalTeams);
            totalMatches = (int)(totalTeams - Math.Pow(2, nextTier - 1));
            currentTeams = new List<int>();
            
            for (int i = 0; i < totalMatches; i++)
            {
                var teamAID = GetRandomTeam(cloneTeamIDs);
                var teamBID = GetRandomTeam(cloneTeamIDs);
                currentTeams.Add(teamAID);
                currentTeams.Add(teamBID);
               
                var match = new MatchResult();
                match.SetTeamAID(teamAID);
                match.SetTeamBID(teamBID);
                matches.Add(i, match);
            }
        }

        private int GetRandomTeam(List<int> teamIDs)
        {
            var r = new Random();
            var i = r.Next(teamIDs.Count);
            var teamID = teamIDs[i];
            teamIDs.RemoveAt(i);
            return teamID;
        }

        public bool AllMatchesPlayed()
        {
            var allPlayed = true;
            foreach (var match in matches.Values)
            {
                if (!match.GetPlayed())
                {
                    allPlayed = false;
                    break;
                }
            }
            return allPlayed;
        }

        private static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        public bool IsNextMatch(int currentMatch)
        {
            return currentMatch == matches.Count ? true : false;
        }

        public int GetWinner(int number)
        {
            return matches[number].GetWinner();
        }

        public void SetMatch(int ID, MatchResult mr)
        {
            mr.SetPlayed(true);
            matches[ID] = mr.Clone();
        }
    }
}
