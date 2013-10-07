using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public class MatchResult
    {
        int matchID;
        Score teamAScore;
        Score teamBScore;
        int teamAID;
        int teamBID;

        public MatchResult()
        {
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

        public MatchResult Clone()
        {
            var mr = new MatchResult();
            mr.SetMatchID(matchID);
            mr.SetTeamAID(teamAID);
            mr.SetTeamAScore(teamAScore);
            mr.SetTeamBID(teamBID);
            mr.SetTeamBScore(teamBScore);
            return mr;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}, {2}: {3}", teamAID, teamAScore, teamBID, teamBScore);
        }
    }
}
