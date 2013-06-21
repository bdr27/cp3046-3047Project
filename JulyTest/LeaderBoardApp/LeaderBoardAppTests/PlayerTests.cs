using System;
using LeaderBoardApp.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeaderBoardAppTests
{
    [TestClass]
    public class PlayerTests
    {
        #region Details Tests
        [TestMethod]
        public void PlayerDetails()
        {
            string fName = "John";
            string lName = "Smith";
            int age = 15;
            string guardian = "Julie";
            string pContact = "40404040";
            string medical = "sickish";

            Player player = new Player(fName, lName, age, guardian, pContact, medical);
            Assert.AreEqual(string.Format("fname: {0}, lname: {1}, age: {2}, guardian: {3}, contact: {4} medical: {5}",
                fName, lName, age, guardian, pContact, medical), player.Details());
        }
        #endregion

        #region IsValidPlayer Tests
        [TestMethod]
        public void PlayerValuesAreValid()
        {
            Player player = new Player("John", "Smith", 15, "Julie", "47761676", "");
            Assert.IsTrue(player.IsValidPlayer());
        }

        [TestMethod]
        public void PlayerValuesAreInvalidFirstName()
        {
            Player player = new Player("J0hn", "Smith", 15, "Julie", "47761676", "");
            Assert.IsFalse(player.IsValidPlayer());
        }

        [TestMethod]
        public void PlayerValuesAreInvalidLastName()
        {
            Player player = new Player("John", "Sm1th", 15, "Julie", "47761676", "");
            Assert.IsFalse(player.IsValidPlayer());
        }

        [TestMethod]
        public void PlayerValuesAreValidNoContact()
        {
            Player player = new Player("John", "Smith", 15, "", "47761676", "");
            Assert.IsTrue(player.IsValidPlayer());
        }

        [TestMethod]
        public void PlayerValuesAreInvalidNumber()
        {
            Player player = new Player("John", "Sm1th", 15, "Julie", "477t1676", "");
            Assert.IsFalse(player.IsValidPlayer());
        }
        #endregion
        
        #region ToString Tests
        [TestMethod]
        public void PlayerToString()
        {
            Player player = new Player("John", "Smith", 15, "Julie", "47761676", "");
            Assert.AreEqual("John Smith", player.ToString());
        }
        #endregion

    }
}
