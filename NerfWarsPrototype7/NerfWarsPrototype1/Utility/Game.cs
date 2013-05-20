namespace NerfWarsLeaderboard.Utility
{
    public class Game
    {
        private bool gameStarted;
        private int min;
        private int sec;
        private PlayerTeam teamA;
        private PlayerTeam teamB;

        public Game()
        {
        }

        public void LoadTeamA(Team team)
        {
            teamA = new PlayerTeam(team.GetPlayerFName(), team.GetTName());
        }

        public void LoadTeamB(Team team)
        {
            teamB = new PlayerTeam(team.GetPlayerFName(), team.GetTName());
        }

        public void SetMin(int min)
        {
            this.min = min;
        }

        public void SetSec(int sec)
        {
            this.sec = sec;
        }

        public PlayerTeam GetTeamA()
        {
            return teamA;
        }

        public PlayerTeam GetTeamB()
        {
            return teamB;
        }

        public int GetMin()
        {
            return min;
        }

        public int GetTeamAFlag()
        {
            return teamA.GetFlag();
        }

        public int GetTeamATag()
        {
            return teamA.GetTag();
        }

        public int GetTeamAScore()
        {
            return teamA.GetScore();
        }

        public int GetTeamBFlag()
        {
            return teamB.GetFlag();
        }

        public int GetTeamBTag()
        {
            return teamB.GetTag();
        }

        public int GetTeamBScore()
        {
            return teamB.GetScore();
        }

        public void TeamAaddFlag()
        {
            teamA.AddFlag();
        }

        public void TeamBaddFlag()
        {
            teamB.AddFlag();
        }

        public void TeamAaddTag()
        {
            teamA.AddTag();
        }

        public void TeamBaddTag()
        {
            teamB.AddTag();
        }

        public void TeamBMinusTag()
        {
            teamB.MinusTag();
        }

        public void TeamAMinusTag()
        {
            teamA.MinusTag();
        }

        public void TeamAMinusFlag()
        {
            teamA.MinusFlag();
        }

        public void TeamBMinusFlag()
        {
            teamB.MinusFlag();
        }

        public int GetSec()
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

        public Winner GetWinner()
        {
            Winner winner;
            //Team 1 wins
            if (teamA.GetScore() > teamB.GetScore())
            {
                winner = Winner.TEAM_1;
            }
            //Draw
            else if (teamA.GetScore() == teamB.GetScore())
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

        public string GetTime()
        {
            string minute = min.ToString();
            string second = sec.ToString();

            if(sec < 10)
            {
                second = "0" + second;
            }

            return minute + ":" + second;
        }

        internal void Reset(int min, int sec)
        {
            this.min = min;
            this.sec = sec;
            teamA.ResetScore();
            teamB.ResetScore();
        }
    }
}
