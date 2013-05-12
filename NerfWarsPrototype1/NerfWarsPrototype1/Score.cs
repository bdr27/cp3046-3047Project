using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerfWarsPrototype1
{
    public class Score
    {
        private int cap;
        private int tag;

        public Score()
        {
            cap = 0;
            tag = 0;
        }

        public int getCap()
        {
            return cap;
        }

        public int getTag()
        {
            return tag;
        }

        public void increaseTag()
        {
            tag++;
        }

        public void increaseCap()
        {
            cap++;
        }

        public void decreaseTag()
        {
            tag--;
        }

        public void decreaseCap()
        {
            cap--;
        }
    }
}
