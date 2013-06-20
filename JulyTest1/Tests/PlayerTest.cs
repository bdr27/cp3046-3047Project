using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NerfWarsLeaderboard.Utility;

namespace Tests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void PlayersAreEqual()
        {
            string firstname = "John";
            string lastname = "Smith";
            int age = 4;
            string guardian = "Bob Joe";
            string contact = "444";
            string medicalCondition = "None";
            Player player1 = new Player(firstname, lastname, age, guardian, contact, medicalCondition);
            Player player2 = new Player(firstname, lastname, age, guardian, contact, medicalCondition);

            Assert.AreEqual(player1, player2);
            Assert.AreNotEqual(player1, "something");
        }
    }
}
