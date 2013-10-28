using LeaderBoardApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public class Ladder
    {
        private string name;
        private LadderTier[] ladderTiers;
        private int currentMatch;
        private List<int> teamIDs;
        private int teamCount;
        private int tierCount;
        private int currentTier;
        private int tournamentWinnerID = -1;
        
        public Ladder(List<int> teamIDs)
        {
            this.teamIDs = teamIDs;
            teamCount = teamIDs.Count;
            currentTier = 0;
            currentMatch = 0;
        }

        public void SetLadderName(string name)
        {
            this.name = name;
        }

        public int GetCurrentTier()
        {
            return currentTier;
        }

        public void SetTeams(List<int> teamIDs)
        {
            this.teamIDs = teamIDs;
        }

        public void SetMatch(int matchID, MatchResult matchPlayed)
        {
            ladderTiers[currentTier].SetMatch(matchID, matchPlayed);
        }

        public void GenerateLadder()
        {            
            tierCount = LadderUtil.GetTierCount(teamCount);
            ladderTiers = new LadderTier[tierCount];
            for (int i = 0; i < tierCount; i++)
            {
                ladderTiers[i] = new LadderTier();
            }
            ladderTiers[currentTier].GenerateRandomMatches(teamIDs);
        }

        public int GetCurrentTeir()
        {
            return currentTier;
        }

        public Dictionary<int, MatchResult> GetMatches()
        {
            return ladderTiers[currentTier].GetAllMatches();
        }

        public int GetTournamentWinnerID()
        {
            return tournamentWinnerID;
        }

        public void MatchPlayed(int ID, MatchResult mr)
        {
            mr.SetPlayed(true);
            ladderTiers[currentTier].SetMatch(ID, mr);
            var winnerID = mr.GetWinner();
            if (winnerID != -1)
            {
                if (currentTier + 1 != tierCount)
                {
                    ladderTiers[currentTier + 1].AddTeam(winnerID, ID);
                    if (ladderTiers[currentTier].AllMatchesPlayed())
                    {
                        var breakTeams = ladderTiers[currentTier++].GetAllBreaks();
                        AddBreakTeams(breakTeams);
                    }
                }
                else
                {
                    this.tournamentWinnerID = winnerID;
                    throw new TournamentWinnerException(winnerID);
                }
            }
            else
            {
                mr.SetPlayed(false);
            }
        }

        private void AddBreakTeams(Dictionary<int, MatchResult> breakTeams)
        {
            foreach (var mr in breakTeams)
            {
                ladderTiers[currentTier].AddTeam(mr.Value.GetWinner(), mr.Key);
            }
        }

        public int GetTierCount()
        {
            return tierCount;
        }

        public LadderTier getCurrentLadderTier()
        {
            return ladderTiers[currentTier];
        }

        public int GetTeamCount()
        {
            return teamCount;
        }

        public Dictionary<int, MatchResult> GetAllMatches()
        {
            var matches = new Dictionary<int, MatchResult>();
            var totalMatches = 0;
            for (int i = 0; i <= currentTier; i++)
            {
                foreach (var match in ladderTiers[i].GetAllMatches())
                {
                    if (!match.Value.GetDummyGame())
                    {
                        matches.Add(totalMatches++, match.Value);
                    }
                }
            }
            return matches;
        }

        public Ladder Clone()
        {
            var teams = new List<int>();
            foreach (var team in this.teamIDs)
            {
                teams.Add(team);
            }
            Ladder ladder = new Ladder(teams);

            ladder.name = name;
           ladder.currentMatch = currentMatch;
           ladder.teamCount = teamCount;
           ladder.currentTier = currentTier;
           ladder.tierCount = tierCount;
           ladder.tournamentWinnerID = tournamentWinnerID;

           ladder.ladderTiers = new LadderTier[tierCount];
           for (int i = 0; i < tierCount; i++)
           {
               ladder.ladderTiers[i] = ladderTiers[i].Clone();
           }
            
           return ladder;
        }

        public override string ToString()
        {
            return name;
        }

        public Dictionary<int, MatchResult> GetLoadMatches()
        {
            var matches = new Dictionary<int, MatchResult>();
            for(int i = 0; i < tierCount; i++)
            {
                foreach (var match in ladderTiers[i].GetAllMatches())
                {
                    matches.Add(match.Key, match.Value);
                }
            }
            return matches;
        }
    }
}
