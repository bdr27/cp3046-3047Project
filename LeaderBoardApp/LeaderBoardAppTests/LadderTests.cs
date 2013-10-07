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
        public void LadderTierTest()
        {
            for (int i = 1; i < 20; i++)
            {
                var ladder = new Ladder((int)Math.Pow(2, i));
                ladder.GenerateLadder();
                Assert.AreEqual(i, ladder.GetTierCount());
            }
            for (int i = 1; i < 20; i++)
            {
                var number = Math.Pow(2, i);
                number = number - i;
                var ladder = new Ladder((int)Math.Pow(2, i));
                ladder.GenerateLadder();
                Assert.AreEqual(i, ladder.GetTierCount());
            }
        }
    }
}
