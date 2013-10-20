using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Exceptions
{
    public class TournamentWinnerException : Exception
    {
        private int winnerID;

        public TournamentWinnerException(int winnerID)
        {
            this.winnerID = winnerID;
        }

        public int GetWinner()
        {
            return winnerID;
        }
    }
}
