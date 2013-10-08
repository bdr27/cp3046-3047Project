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

        public void GenerateLadder()
        {            
            tierCount = LadderUtil.GetTierCount(teamCount);
            ladderTiers = new LadderTier[tierCount];
            ladderTiers[currentTier] = new LadderTier();
            ladderTiers[currentTier].GenerateMatches(teamIDs);
        }

        public void GetNextMatch()
        {
            if (ladderTiers[currentTier].IsNextMatch(currentMatch))
            {
                //var match = ladderTiers[currentTier].GetNextMatch(currentMatch++);
            }            
        }

        public Dictionary<int, MatchResult> GetMatches()
        {
            return ladderTiers[currentTier].GetAllMatches();
        }

        public void MatchPlayed(int ID, MatchResult mr)
        {
            mr.SetPlayed(true);
            ladderTiers[currentTier].SetMatch(ID, mr);

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
