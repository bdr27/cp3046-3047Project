using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public class Player
    {
        //P_ID will mainly be used for editing purposes
        private int p_ID;
        private string fName;
        private string lName;
        private int age;
        private string guardian;
        private string pContact;
        private string medical;

        public Player(string fName, string lName, int age, string guardian, string pContact, string medical)
        {
            this.fName = fName;
            this.lName = lName;
            this.age = age;
            this.guardian = guardian;
            this.pContact = pContact;
            this.medical = medical;
        }

        public bool IsValidPlayer()
        {
            throw new NotImplementedException();
        }

        public void SetFName(string fName)
        {
            this.fName = fName;
        }

        public string GetFName()
        {
            return fName;
        }

        public void SetLName(string lName)
        {
            this.lName = lName;
        }

        public string GetLName()
        {
            return lName;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        public int GetP_ID()
        {
            return p_ID;
        }

        public int GetAge()
        {
            return age;
        }

        public void SetGuardian(string guardian)
        {
            this.guardian = guardian;
        }

        public string GetGuardian()
        {
            return guardian;
        }

        public void SetContact(string contact)
        {
            this.pContact = contact;
        }

        public string GetContact()
        {
            return pContact;
        }

        public void SetMedical(string medical)
        {
            this.medical = medical;
        }

        public string GetMedical()
        {
            return medical;
        }

        public override string ToString()
        {
            return fName + " " + lName;
        }
    }
}
