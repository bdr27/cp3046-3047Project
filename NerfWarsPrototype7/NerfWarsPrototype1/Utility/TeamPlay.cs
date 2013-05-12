using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//[assembly: InternalsVisibleTo("Testing")]

namespace Utility
{
    public class TeamPlay
    {
        private const int FLAG_SCORE = 5;
        private const int TAG_SCORE = 1;
        private string teamName;
        private List<string> playerNames;
        private int flag;
        private int tag;
        private int score;

        public TeamPlay(List<string> playerNames, string teamName)
        {
            this.playerNames = playerNames;
            this.teamName = teamName;
            flag = 0;
            tag = 0;
        }

        public int getCapScore()
        {
            return FLAG_SCORE;
        }

        public int getTagScore()
        {
            return FLAG_SCORE;
        }

        public List<string> getPlayerNames()
        {
            return playerNames;
        }

        public string getTeamName()
        {
            return teamName;
        }

        public int getFlag()
        {
            return flag;
        }

        public int getTag()
        {
            return tag;
        }

        public int getScore()
        {
            return score;
        }

        public void addFlag()
        {
            flag++;
            updateScore();
        }

        public void addTag()
        {
            tag++;
            updateScore();
        }

        public void minusFlag()
        {
            if (flag > 0)
            {
                flag--;
                updateScore();
            }            
        }

        public void minusTag()
        {
            if (tag > 0)
            {
                tag--;
                updateScore();
            }            
        }

        private void updateScore()
        {
            score = tag * TAG_SCORE + flag * FLAG_SCORE;
        }

        internal void resetScore()
        {
            tag = 0;
            flag = 0;
            updateScore();
        }
    }
}
