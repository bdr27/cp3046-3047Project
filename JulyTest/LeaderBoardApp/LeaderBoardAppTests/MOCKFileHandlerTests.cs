using System;
using System.Collections.Generic;
using LeaderBoardApp.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeaderBoardAppTests
{
    [TestClass]
    public class MOCKFileHandlerTests
    {
        [TestMethod]
        public void MOCKFileHandlerLoadPlayers()
        {
            var testHandler = new MOCKFileHandler();
            testHandler.LoadPlayers();
            var testHandlerPlayers = testHandler.GetPlayers();
            foreach(var item in TestPlayers())
            {
                Assert.AreEqual(item.Value.Details(), testHandlerPlayers[item.Key].Details());
            }
        }

        private Dictionary<int, Player> TestPlayers()
        {
            var players = new Dictionary<int, Player>();
            int playerCounter = 1;
            players.Add(playerCounter++, new Player("john", "smith", 24, "", "40404040", ""));
            players.Add(playerCounter++, new Player("Jill", "smith", 12, "", "40404034", ""));
            players.Add(playerCounter++, new Player("Geroge", "Lucas", 25, "Marie", "5556565", "I like starwars"));
            foreach (var player in players)
            {
                player.Value.SetP_ID(player.Key);
            }
            return players;
        }

        [TestMethod]
        public void MOCKFileHandlerAddPlayer()
        {
            var testHandler = new MOCKFileHandler();
            testHandler.LoadPlayers();
            var testHandlerPlayers = testHandler.GetPlayers();
            var testPlayers = TestPlayers();

            var newPlayer = new Player("Bob", "Dude", 12, "Mummy", "5552189", "Can't run");
            testHandler.InsertPlayer(newPlayer);
            testPlayers.Add(testPlayers.Count+1, newPlayer);
            foreach (var item in testPlayers)
            {
                Assert.AreEqual(item.Value.Details(), testHandlerPlayers[item.Key].Details());
            }
        }

        [TestMethod]
        public void MOCKFileHandlerEditPlayer()
        {
            var testHandler = new MOCKFileHandler();
            testHandler.LoadPlayers();
            var testHandlerPlayers = testHandler.GetPlayers();
            var testPlayers = TestPlayers();
            var editPlayer = new Player("bob", "smith", 10, "someone", "4545454", "Sickly");
            var playerEdited = 0;
            editPlayer.SetP_ID(playerEdited);
            testPlayers[playerEdited] = editPlayer;
            testHandler.UpdatePlayer(editPlayer);

            foreach (var item in testPlayers)
            {
                Assert.AreEqual(item.Value.Details(), testHandlerPlayers[item.Key].Details());
            }
        }

        [TestMethod]
        public void MOCKFileHandlerDeletePlayer()
        {
            var testHandler = new MOCKFileHandler();
            testHandler.LoadPlayers();
            var testHandlerPlayers = testHandler.GetPlayers();
            var testPlayers = TestPlayers();
            var DeletePlayer = new Player("john", "smith", 24, "", "40404040", "");
            var playerDeleted = 0;
            DeletePlayer.SetP_ID(playerDeleted);
            testPlayers.Remove(playerDeleted);
            testHandler.DeletePlayer(DeletePlayer.GetP_ID());

            foreach (var item in testPlayers)
            {
                Assert.AreEqual(item.Value.Details(), testHandlerPlayers[item.Key].Details());
            }
        }
    }
}
