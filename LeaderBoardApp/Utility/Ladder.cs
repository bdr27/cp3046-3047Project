using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public class Ladder
    {
        private LadderTier[] ladderTiers;
        private int currentMatch;
        private List<int> teamIDs;
        private int teamCount;
        private int tierCount;
        private int currentTier;
        
        public Ladder(List<int> teamIDs)
        {
            this.teamIDs = teamIDs;
            teamCount = teamIDs.Count;
            currentTier = 0;
            currentMatch = 0;
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

        public void MatchPlayed(int ID, MatchResult mr)
        {
            mr.SetPlayed(true);
            ladderTiers[currentTier].SetMatch(ID, mr);
            var winnerID = mr.GetWinner();
            if (winnerID != -1)
            {
                ladderTiers[currentTier + 1].AddTeam(winnerID, ID);
                if (ladderTiers[currentTier].AllMatchesPlayed())
                {
                    currentTier++;
                }
            }
            else
            {
                mr.SetPlayed(false);
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
    }
}
