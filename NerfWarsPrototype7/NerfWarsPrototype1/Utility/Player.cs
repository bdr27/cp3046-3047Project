using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Player
    {
        string firstname;
        string lastname;

        public Player(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string getFirstName()
        {
            return firstname;
        }
    }
}
