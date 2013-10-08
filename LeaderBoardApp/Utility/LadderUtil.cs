using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public static class LadderUtil
    {
        public static int GetTierCount(int teamCount)
        {
            var result = 1.0;
            if (teamCount > 1)
            {
                result = (Math.Log(teamCount)) / (Math.Log(2));
                if (result % 1 != 0)
                {
                    result++;
                }
            }
            return (int)result;
        }

        public static bool IsPower2(int teamCount)
        {
            if (teamCount > 1)
            {
                var result = (Math.Log(teamCount)) / (Math.Log(2));
                if (result % 1 == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<int> CloneIntList(List<int> il)
        {
            var clone = new List<int>();
            foreach (int i in il)
            {
                clone.Add(i);
            }
            return clone;
        }
    }
}
