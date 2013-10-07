﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public class Ladder
    {
        private LadderTier[] ladderTiers;
        private int teamCount;
        private int tierCount;
        private int currentTier;
        
        public Ladder(int teamCount)
        {
            this.teamCount = teamCount;
        }

        public void GenerateLadder()
        {
            currentTier = 0;
            tierCount = GetTierCount(teamCount);
            ladderTiers = new LadderTier[tierCount];
        }

        public int GetTierCount()
        {
            return tierCount;
        }

        public int GetTeamCount()
        {
            return teamCount;
        }

        private int GetTierCount(int teamCount)
        {
            var result = (Math.Log(teamCount)) / (Math.Log(2));
            if (result % 1 != 0)
            {
                result++;
            }
            return (int)result;
        }
    }
}
