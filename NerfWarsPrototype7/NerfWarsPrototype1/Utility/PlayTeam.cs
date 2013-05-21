using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NerfWarsTests")]

namespace NerfWarsLeaderboard.Utility
{
    public class PlayTeam
    {
        private const int FLAG_SCORE = 5;
        private const int TAG_SCORE = 1;
        private string teamName;
        private List<string> playerNames;
        private int flag;
        private int tag;
        private int score;

        public PlayTeam(List<string> playerNames, string teamName)
        {
            this.playerNames = playerNames;
            this.teamName = teamName;
            flag = 0;
            tag = 0;
        }

        public int GetCapScore()
        {
            return FLAG_SCORE;
        }

        public int GetTagScore()
        {
            return FLAG_SCORE;
        }

        public List<string> GetPlayerNames()
        {
            return playerNames;
        }

        public string GetTeamName()
        {
            return teamName;
        }

        public int GetFlag()
        {
            return flag;
        }

        public int GetTag()
        {
            return tag;
        }

        public int GetScore()
        {
            return score;
        }

        public void AddFlag()
        {
            flag++;
            UpdateScore();
        }

        public void AddTag()
        {
            tag++;
            UpdateScore();
        }

        public void MinusFlag()
        {
            if (flag > 0)
            {
                flag--;
                UpdateScore();
            }            
        }

        public void MinusTag()
        {
            if (tag > 0)
            {
                tag--;
                UpdateScore();
            }            
        }

        private void UpdateScore()
        {
            score = tag * TAG_SCORE + flag * FLAG_SCORE;
        }

        internal void ResetScore()
        {
            tag = 0;
            flag = 0;
            UpdateScore();
        }
    }
}
