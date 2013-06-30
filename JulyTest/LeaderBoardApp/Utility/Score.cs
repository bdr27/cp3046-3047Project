using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public class Score
    {
        private const int FLAG_SCORE = 5;
        private const int TAG_SCORE = 1;
        private int flag;
        private int tag;
        private int score;

        public Score()
        {
            flag = 0; 
            tag = 0; 
            score = 0;
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

        public void ResetScore()
        {
            tag = 0;
            flag = 0;
            UpdateScore();
        }
    }
}
