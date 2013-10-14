using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public class MatchPlayed
    {
        private static Dictionary<int, Team> teams;
        private int matchID;
        private int tierID;
        private Score teamAScore;
        private Score teamBScore;
        private int teamAID;
        private int teamBID;
        private bool played;
        private bool dummyGame;

        public MatchPlayed()
        {
            played = false;
        }

        public static void SetTeams(Dictionary<int,Team> tempTeams)
        {
            teams = tempTeams;
        }

        public void SetTierID(int tierID)
        {
            this.tierID = tierID;
        }

        public int GetTierID()
        {
            return tierID;
        }

        public string GetTeamAName()
        {
            return teams[teamAID].GetTeamName();
        }

        public string GetTeamBName()
        {
            return teams[teamBID].GetTeamName();
        }

        public void SetDummyGame(bool dummyGame)
        {
            this.dummyGame = dummyGame;
            played = true;
        }

        public bool GetDummyGame()
        {
            return dummyGame;
        }

        public bool GetPlayed()
        {
            return played;
        }

        public void SetPlayed(bool played)
        {
            this.played = played;
        }

        public void SetMatchID(int matchID)
        {
            this.matchID = matchID;
        }

       public void SetTeamAID(int id)
        {
            this.teamAID = id;
        }

        public void SetTeamBID(int id)
        {
            this.teamBID = id;
        }

        public void SetTeamAScore(Score score)
        {
            teamAScore = score;
        }

        public void SetTeamBScore(Score score)
        {
            teamBScore = score;
        }

        public MatchPlayed Clone()
        {
            var mr = new MatchPlayed();
            mr.SetMatchID(matchID);
            mr.SetTeamAID(teamAID);
            mr.SetTeamAScore(teamAScore);
            mr.SetTeamBID(teamBID);
            mr.SetTeamBScore(teamBScore);
            mr.SetPlayed(played);
            return mr;
        }

        public int GetWinner()
        {
            if (dummyGame)
            {
                return teamAID;
            }
            //Draw
            var winner = -1;
            if (teamAScore.GetScore() > teamBScore.GetScore())
            {
                winner = teamAID;
            }
            else if (teamBScore.GetScore() > teamAScore.GetScore()) 
            {
                winner = teamBID;
            }
            return winner;
        }

        public int GetTeamAID()
        {
            return teamAID;
        }

        public int GetTeamBID()
        {
            return teamBID;
        }

        public Score GetTeamAScore()
        {
            return teamAScore;
        }

        public Score GetTeamBScore()
        {
            return teamBScore;
        }

        public override string ToString()
        {
            var message = string.Format("{0} vs {1}", GetTeamName(teamAID), GetTeamName(teamBID));
            if (played)
            {
                message += string.Format(" {0}: {1}", teamAScore.GetScore(), teamBScore.GetScore());
            }
            return message;
        }

        private string GetTeamName(int teamID)
        {
            return teams[teamID].GetTeamName();
        }
    }
}
