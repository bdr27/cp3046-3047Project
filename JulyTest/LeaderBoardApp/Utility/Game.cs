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
        private int teamAID;
        private int teamBID;
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
    }
}
