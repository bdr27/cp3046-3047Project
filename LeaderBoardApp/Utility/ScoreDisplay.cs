using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public interface ScoreDisplay
    {
        void SetTeamAFlag(int p);
        void SetTeamAScore(int p);
        void SetTeamATag(int p);
        void SetTeamBFlag(int p);
        void SetTeamBScore(int p);
        void SetTeamBTag(int p);
        void SetTeamA(GameTeam team);
        void SetTeamB(GameTeam team);
        void SetTime(int min, int sec);
    }
}
