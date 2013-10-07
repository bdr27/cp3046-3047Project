using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public class Game
    {
        private int min;
        private int sec;
        private Score teamAScore;
        private Score teamBScore;

        public Game()
        {
            NewGame();
        }

        public void NewGame()
        {
            min = 0;
            sec = 0;
            teamAScore = new Score();
            teamBScore = new Score();
        }

        public int GetTeamAFlag()
        {
            return teamAScore.GetFlag();
        }

        public int GetTeamATag()
        {
            return teamAScore.GetTag();
        }

        public int GetTeamAScore()
        {
            return teamAScore.GetScore();
        }

        public int GetTeamBFlag()
        {
            return teamBScore.GetFlag();
        }

        public int GetTeamBTag()
        {
            return teamBScore.GetTag();
        }

        public int GetTeamBScore()
        {
            return teamBScore.GetScore();
        }

        public void TeamAaddFlag()
        {
            teamAScore.AddFlag();
        }

        public void TeamBaddFlag()
        {
            teamBScore.AddFlag();
        }

        public void TeamAaddTag()
        {
            teamAScore.AddTag();
        }

        public void TeamBaddTag()
        {
            teamBScore.AddTag();
        }

        public void TeamBMinusTag()
        {
            teamBScore.MinusTag();
        }

        public void TeamAMinusTag()
        {
            teamAScore.MinusTag();
        }

        public void TeamAMinusFlag()
        {
            teamAScore.MinusFlag();
        }

        public void TeamBMinusFlag()
        {
            teamBScore.MinusFlag();
        }

        public void SetMin(int min)
        {
            this.min = min;
        }

        public void SetSec(int sec)
        {
            this.sec = sec;
        }

        public int GetSec()
        {
            return sec;
        }

        public int GetMin()
        {
            return min;
        }

        public bool CountDown()
        {
            bool timerFinished = false;
            if (sec == 0 && min != 0)
            {
                sec = 59;
                min -= 1;
            }
            else if (sec == 0 && min == 0)
            {
                timerFinished = true;
            }
            else
            {
                sec -= 1;
            }
            return timerFinished;
        }

        public MatchResult GetMatchResult(int teamAID, int teamBID)
        {
            var mr = new MatchResult();
            mr.SetTeamAID(teamAID);
            mr.SetTeamBID(teamBID);
            mr.SetTeamAScore(teamAScore);
            mr.SetTeamBScore(teamBScore);
            return mr;
        }
    }
}
