using System;
using LeaderBoardApp.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeaderBoardAppTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void PlayerToString()
        {
            Player player = new Player("John", "Smith", 15, "Julie", "47761676", "");
            Assert.AreEqual("John Smith", player.ToString());
        }

        [TestMethod]
        public void PlayerValuesAreValid()
        {
            Player player = new Player("John", "Smith", 15, "Julie", "47761676", "");
            Assert.IsTrue(player.IsValidPlayer());
        }
    }
}
