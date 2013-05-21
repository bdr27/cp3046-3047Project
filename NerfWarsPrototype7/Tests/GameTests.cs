using System.Collections.Generic;
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

            Team teamPlayTest = new Team(teamName, "47454545", playersNames);
            gameTest.LoadTeamA(teamPlayTest);
            Assert.AreEqual(teamPlayTest.GetTeamName(), gameTest.GetTeamA().GetTeamName());
            for (int i = 0; i < teamPlayTest.GetPlayerFirstName().Count; i++)
            {
                Assert.AreEqual(teamPlayTest.GetPlayerFirstName()[i], gameTest.GetTeamA().GetPlayerNames()[i]);
            }

            //Creates another list of players
            List<Player> playersNames2 = setPlayerList();
            Team secondTeam = new Team("john smith","47454545", playersNames2);

            gameTest.LoadTeamB(secondTeam);
            //Checks the name's are the same
            Assert.AreEqual(secondTeam.GetTeamName(), gameTest.GetTeamB().GetTeamName());
            //Checks all the players first names are right
            for (int i = 0; i < secondTeam.GetPlayerFirstName().Count; i++)
            {
                Assert.AreEqual(secondTeam.GetPlayerFirstName()[i], gameTest.GetTeamB().GetPlayerNames()[i]);
            }
        }

        [TestMethod]
        public void TestTimer()
        {
            List<Player> playersNames = setPlayerList();
            List<string> playerNames = setPlayerNames();
            string teamName = "Crazy 8's";
            Game gameTest = new Game();

            Team teamPlayTest = new Team(teamName,"47454545", playersNames);
            gameTest.LoadTeamB(teamPlayTest);

            int sec = 29;
            int min = 2;
            gameTest.SetMin(min);
            gameTest.SetSec(sec);

            Assert.AreEqual(sec, gameTest.GetSec());
            Assert.AreEqual(min, gameTest.GetMin());

            do
            {
                Assert.AreEqual(sec, gameTest.GetSec());
                Assert.AreEqual(min, gameTest.GetMin());
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
            Team team1 = new Team("team1","47454545", playerNames);
            Team team2 = new Team("team2","47454545", playerNames);

            Game game = new Game();
            PlayTeam teamPlayer = new PlayTeam(new List<string>(), "");
            game.LoadTeamA(team1);
            game.LoadTeamB(team2);
            int team1Tag = 30;
            for (int i = 0; i < team1Tag; i++)
            {
                game.TeamAaddTag();
            }
            Assert.AreEqual(30, game.GetTeamATag());

            int team2Tag = 45;
            for (int i = 0; i < team2Tag; i++)
            {
                game.TeamBaddTag();
            }
            Assert.AreEqual(team2Tag, game.GetTeamBTag());

            int team1Cap = 5;
            for (int i = 0; i < team1Cap; i++)
            {
                game.TeamAaddFlag();
            }
            Assert.AreEqual(team1Cap, game.GetTeamBFlag());

            int team2Cap = 10;
            for (int i = 0; i < team2Cap; i++)
            {
                game.TeamBaddFlag();
            }
            Assert.AreEqual(team2Cap, game.GetTeamBFlag());

            //Calculate total
            int team1Score = team1Tag * teamPlayer.GetTagScore() + team2Cap * teamPlayer.GetCapScore();
            int team2Score = team2Tag * teamPlayer.GetTagScore() + team2Cap * teamPlayer.GetCapScore();

            Assert.AreEqual(team1Score, game.GetTeamAScore());
            Assert.AreEqual(team2Score, game.GetTeamBScore());
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
