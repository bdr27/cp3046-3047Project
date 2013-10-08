using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaderBoardApp.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeaderBoardAppTests
{
    [TestClass]
    public class LadderTests
    {
        [TestMethod]
        public void LadderExactTest()
        {
            for (int i = 19; i < 20; i++)
            {
                var ladder = new Ladder(getTeamIDList(i));
                ladder.GenerateLadder();
                Assert.AreEqual(LadderUtil.GetTierCount(i), ladder.GetTierCount());
            }
        }

        [TestMethod]
        public void LadderOddLowerTest()
        {
            for (int i = 1; i < 20; i++)
            {
                var number = Math.Pow(2, i);
                number = number - 1;
                var ladder = new Ladder(getTeamIDList((int)number));
                ladder.GenerateLadder();
                Assert.AreEqual(i, ladder.GetTierCount());
            }
        }

        [TestMethod]
        public void LadderOddHigherTest()
        {
            for (int i = 1; i < 20; i++)
            {
                var number = Math.Pow(2, i);
                number = number + 1;
                var ladder = new Ladder(getTeamIDList((int)number));
                ladder.GenerateLadder();
                Assert.AreEqual(i + 1, ladder.GetTierCount());
            }
        }

        private List<int> getTeamIDList(int p)
        {
            var teams = new List<int>();
            for (int i = 1; i <= p; i++)
            {
                teams.Add(i);
            }
            return teams;
        }
    }
}
