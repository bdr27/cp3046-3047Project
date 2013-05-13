using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//[assembly: InternalsVisibleTo("Testing")]

namespace TestingClasses
{
    public class TeamPlay
    {
        private const int CAP_SCORE = 5;
        private const int TAG_SCORE = 1;
        private string teamName;
        private List<string> playerNames;
        private int cap;
        private int tag;
        private int score;

        public TeamPlay(List<string> playerNames, string teamName)
        {
            this.playerNames = playerNames;
            this.teamName = teamName;
            cap = 0;
            tag = 0;
        }

        public int getCapScore()
        {
            return CAP_SCORE;
        }

        public int getTagScore()
        {
            return CAP_SCORE;
        }

        public List<string> getPlayerNames()
        {
            return playerNames;
        }

        public string getTeamName()
        {
            return teamName;
        }

        public int getCap()
        {
            return cap;
        }

        public int getTag()
        {
            return tag;
        }

        public int getScore()
        {
            return score;
        }

        public void addCap()
        {
            cap++;
            updateScore();
        }

        public void addTag()
        {
            tag++;
            updateScore();
        }

        public void minusCap()
        {
            cap--;
            updateScore();
        }

        public void minusTag()
        {
            tag--;
            updateScore();
        }

        private void updateScore()
        {
            score = tag * TAG_SCORE + cap * CAP_SCORE;
        }
    }
}
