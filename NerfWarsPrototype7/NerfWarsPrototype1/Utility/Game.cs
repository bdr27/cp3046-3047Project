using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Game
    {
        private bool gameStarted;
        private int min;
        private int sec;
        private TeamPlay teamA;
        private TeamPlay teamB;

        public Game()
        {
        }

        public void loadTeamA(Team team)
        {
            teamA = new TeamPlay(team.getPlayerFirstName(), team.getTeamName());
        }

        public void loadTeamB(Team team)
        {
            teamB = new TeamPlay(team.getPlayerFirstName(), team.getTeamName());
        }

        public void setMin(int min)
        {
            this.min = min;
        }

        public void setSec(int sec)
        {
            this.sec = sec;
        }

        public TeamPlay getTeamA()
        {
            return teamA;
        }

        public TeamPlay getTeamB()
        {
            return teamB;
        }

        public int getMin()
        {
            return min;
        }

        public int getTeamAFlag()
        {
            return teamA.getFlag();
        }

        public int getTeamATag()
        {
            return teamA.getTag();
        }

        public int getTeamAScore()
        {
            return teamA.getScore();
        }

        public int getTeamBFlag()
        {
            return teamB.getFlag();
        }

        public int getTeamBTag()
        {
            return teamB.getTag();
        }

        public int getTeamBScore()
        {
            return teamB.getScore();
        }

        public void teamAaddFlag()
        {
            teamA.addFlag();
        }

        public void teamBaddFlag()
        {
            teamB.addFlag();
        }

        public void teamAaddTag()
        {
            teamA.addTag();
        }

        public void teamBaddTag()
        {
            teamB.addTag();
        }

        public void teamBMinusTag()
        {
            teamB.minusTag();
        }

        public void teamAMinusTag()
        {
            teamA.minusTag();
        }

        public void teamAMinusFlag()
        {
            teamA.minusFlag();
        }

        public void teamBMinusFlag()
        {
            teamB.minusFlag();
        }

        public int getSec()
        {
            return sec;
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

        public Winner getWinner()
        {
            Winner winner;
            //Team 1 wins
            if (teamA.getScore() > teamB.getScore())
            {
                winner = Winner.TEAM_1;
            }
            //Draw
            else if (teamA.getScore() == teamB.getScore())
            {
                winner = Winner.DRAW;
            }
            //Team 2 wins
            else
            {
                winner = Winner.TEAM_2;
            }
            return winner;
        }

        public string getTime()
        {
            string minute = min.ToString();
            string second = sec.ToString();

            if(sec < 10)
            {
                second = "0" + second;
            }

            return minute + ":" + second;
        }

        internal void reset(int min, int sec)
        {
            this.min = min;
            this.sec = sec;
            teamA.resetScore();
            teamB.resetScore();
        }
    }
}
