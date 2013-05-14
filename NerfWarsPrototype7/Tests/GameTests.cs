﻿using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void LoadNewTeam()
        {
            List<Player> playersNames = setPlayerList();
            string teamName = "Crazy 8's";
            Game gameTest = new Game();

            Team teamPlayTest = new Team(teamName, playersNames);
            gameTest.loadTeamA(teamPlayTest);
            Assert.AreEqual(teamPlayTest.getTeamName(), gameTest.getTeamA().getTeamName());
            for (int i = 0; i < teamPlayTest.getPlayerFirstName().Count; i++)
            {
                Assert.AreEqual(teamPlayTest.getPlayerFirstName()[i], gameTest.getTeamA().getPlayerNames()[i]);
            }

            //Creates another list of players
            List<Player> playersNames2 = setPlayerList();
            Team secondTeam = new Team("john smith", playersNames2);

            gameTest.loadTeamB(secondTeam);
            //Checks the name's are the same
            Assert.AreEqual(secondTeam.getTeamName(), gameTest.getTeamB().getTeamName());
            //Checks all the players first names are right
            for (int i = 0; i < secondTeam.getPlayerFirstName().Count; i++)
            {
                Assert.AreEqual(secondTeam.getPlayerFirstName()[i], gameTest.getTeamB().getPlayerNames()[i]);
            }
        }

        [TestMethod]
        public void TestTimer()
        {
            List<Player> playersNames = setPlayerList();
            List<string> playerNames = setPlayerNames();
            string teamName = "Crazy 8's";
            Game gameTest = new Game();

            Team teamPlayTest = new Team(teamName, playersNames);
            gameTest.loadTeamB(teamPlayTest);

            int sec = 29;
            int min = 2;
            gameTest.setMin(min);
            gameTest.setSec(sec);

            Assert.AreEqual(sec, gameTest.getSec());
            Assert.AreEqual(min, gameTest.getMin());

            do
            {
                Assert.AreEqual(sec, gameTest.getSec());
                Assert.AreEqual(min, gameTest.getMin());
                Debug.WriteLine("local Min: " + min + ", sec: " + sec);
                Debug.WriteLine("game Min: " + min + ", sec: " + sec);
                if (sec == 0)
                {
                    min--;
                    sec = 59;
                }
                else
                {
                    sec--;
                }
            }
            while ((!gameTest.CountDown()));
        }

        [TestMethod]
        private void TestWinner()
        {
            List<Player> playerNames = setPlayerList();
            Team team1 = new Team("team1", playerNames);
            Team team2 = new Team("team2", playerNames);

            Game game = new Game();
            TeamPlay teamPlayer = new TeamPlay(new List<string>(), "");
            game.loadTeamA(team1);
            game.loadTeamB(team2);
            int team1Tag = 30;
            for (int i = 0; i < team1Tag; i++)
            {
                game.teamAaddTag();
            }
            Assert.AreEqual(30, game.getTeamATag());

            int team2Tag = 45;
            for (int i = 0; i < team2Tag; i++)
            {
                game.teamBaddTag();
            }
            Assert.AreEqual(team2Tag, game.getTeamBTag());

            int team1Cap = 5;
            for (int i = 0; i < team1Cap; i++)
            {
                game.teamAaddFlag();
            }
            Assert.AreEqual(team1Cap, game.getTeamBFlag());

            int team2Cap = 10;
            for (int i = 0; i < team2Cap; i++)
            {
                game.teamBaddFlag();
            }
            Assert.AreEqual(team2Cap, game.getTeamBFlag());

            //Calculate total
            int team1Score = team1Tag * teamPlayer.getTagScore() + team2Cap * teamPlayer.getCapScore();
            int team2Score = team2Tag * teamPlayer.getTagScore() + team2Cap * teamPlayer.getCapScore();

            Assert.AreEqual(team1Score, game.getTeamAScore());
            Assert.AreEqual(team2Score, game.getTeamBScore());
        }
        private List<Player> setPlayerList()
        {
            List<Player> players = new List<Player>();
            players.Add(setPlayerDetails("John", "Smith", 5, "Allow Smith", "444", "Sick"));
            players.Add(setPlayerDetails("Mary", "Yohan", 5, "Allow Yohan", "444", "Sick"));
            players.Add(setPlayerDetails("Jill", "Bowe", 5, "Allow Bowe", "444", "Sick"));
            players.Add(setPlayerDetails("Bob", "Winter", 5, "Allow Winter", "444", "Sick"));

            return players;
        }

        private Player setPlayerDetails(string firstName, string lastName, int age, string guardian, string contact, string medicalConditions)
        {
            Player player = new Player(firstName, lastName, age, guardian, contact,medicalConditions);
            return player;
        }

        private List<string> setPlayerNames()
        {
            List<string> playerNames = new List<string>();
            playerNames.Add("John");
            playerNames.Add("Mary");
            playerNames.Add("Jill");
            playerNames.Add("Bob");

            return playerNames;
        }
    }
}