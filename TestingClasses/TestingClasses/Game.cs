using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingClasses
{
    public class Game
    {
        private int min;
        private int sec;
        private TeamPlay team1;
        private TeamPlay team2;

        public Game()
        {
        }

        public void loadTeam1(Team team)
        {
            team1 = new TeamPlay(team.getPlayerFirstName(), team.getTeamName());
        }

        public void loadTeam2(Team team)
        {
            team2 = new TeamPlay(team.getPlayerFirstName(), team.getTeamName());
        }

        public void setMin(int min)
        {
            this.min = min;
        }

        public void setSec(int sec)
        {
            this.sec = sec;
        }

        public TeamPlay getTeam1()
        {
            return team1;
        }

        public TeamPlay getTeam2()
        {
            return team2;
        }

        public int getMin()
        {
            return min;
        }

        public int getTeam1Cap()
        {
            return team1.getCap();
        }

        public int getTeam1Tag()
        {
            return team1.getTag();
        }

        public int getTeam1Score()
        {
            return team1.getScore();
        }

        public int getTeam2Cap()
        {
            return team2.getCap();
        }

        public int getTeam2Tag()
        {
            return team2.getTag();
        }

        public int getTeam2Score()
        {
            return team2.getScore();
        }

        public void team1AddCap()
        {
            team1.addCap();
        }

        public void team2AddCap()
        {
            team2.addCap();
        }

        public void team1AddTag()
        {
            team1.addTag();
        }

        public void team2AddTag()
        {
            team2.addTag();
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
            if (team1.getScore() > team2.getScore())
            {
                winner = Winner.TEAM_1;
            }
            //Draw
            else if (team1.getScore() == team2.getScore())
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
    }
}
