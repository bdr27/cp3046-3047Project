using System;
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
            matches = new Dictionary<int, MatchResult>();
            currentTeams = new List<int>();
        }

        public Dictionary<int, MatchResult> GetAllMatches()
        {
            var tm = new Dictionary<int, MatchResult>();
            foreach (var match in matches)
            {
                if (!match.Value.GetDummyGame())
                {
                    tm.Add(match.Key, match.Value.Clone());
                }
           }
            return tm;
        }

        public Dictionary<int, MatchResult> GetAllBreaks()
        {
            var tm = new Dictionary<int, MatchResult>();
            foreach (var match in matches)
            {
                if (match.Value.GetDummyGame())
                {
                    tm.Add(match.Key, match.Value.Clone());
                }
            }
            return tm;
        }

        public int GetAmountMatches()
        {
            return matches.Count;
        }

        public Dictionary<int, MatchResult> GetAllUnplayedMatches()
        {
            var tm = new Dictionary<int, MatchResult>();
            foreach (var match in matches)
            {
                if (!match.Value.GetPlayed())
                {
                    tm.Add(match.Key, match.Value);
                }
            }
            return tm;
        }

        public void GenerateRandomMatches(List<int> teamIDs)
        {
            var cloneTeamIDs = LadderUtil.CloneIntList(teamIDs);            
            var totalTeams = cloneTeamIDs.Count;
            var totalMatches = 0;
            var nextTier = LadderUtil.GetTierCount(totalTeams);
            totalMatches = (int)(totalTeams - Math.Pow(2, nextTier - 1));
            
            for (int i = 0; i < totalMatches; i++)
            {
                var teamAID = GetRandomTeam(cloneTeamIDs);
                var teamBID = GetRandomTeam(cloneTeamIDs);
                currentTeams.Add(teamAID);
                currentTeams.Add(teamBID);
               
                var match = new MatchResult();
                match.SetTeamAID(teamAID);
                match.SetTeamBID(teamBID);
                match.SetMatchID(i);
                matches.Add(i, match);
            }

            var tierMatches = Math.Pow(2, nextTier - 1);
            for (int i = totalMatches; i < tierMatches; i++)
            {
                var teamAId = GetRandomTeam(cloneTeamIDs);
                currentTeams.Add(teamAId);
                var match = new MatchResult();
                match.SetTeamAID(teamAId);
                match.SetDummyGame(true);
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

        public void AddTeam(int winnerID, int matchID)
        {
            var nextRound = matchID / 2;
            if (!matches.ContainsKey(nextRound))
            {
                matches.Add(nextRound, new MatchResult());
                matches[nextRound].SetMatchID(nextRound);
            }
            if (IsOdd(matchID))
            {
                matches[nextRound].SetTeamBID(winnerID);
            }
            else
            {
                matches[nextRound].SetTeamAID(winnerID);
            }
        }

        public List<int> GetPlayingTeamIDs()
        {
            var playingTeamIDs = new List<int>();
            foreach (var match in matches.Values)
            {
                playingTeamIDs.Add(match.GetTeamAID());
                playingTeamIDs.Add(match.GetTeamBID());
            }
            return playingTeamIDs;
        }

        public int GetTotalTeams()
        {
            return currentTeams.Count;
        }

        public LadderTier Clone()
        {
            var clone = new LadderTier();
            var ts = new List<int>();

            foreach (var team in currentTeams)
            {
                ts.Add(team);
            }
            clone.currentTeams = ts;

            var mr = new Dictionary<int, MatchResult>();

            foreach (var match in matches)
            {
                mr.Add(match.Key, match.Value.Clone());
            }

            return clone;
        }
    }
}
