using System;
using System.Diagnostics;
namespace NerfWarsLeaderboard.Utility
{
    public class Player
    {
        private static int counter = 0;
        private int p_ID;
        private string fName;
        private string lName;
        private int age;
        private string guardian;
        private string pContact;
        private string medical;

       public Player()
        {
        }

       public Player(string fName, string lName, int age, string guardian, string pContact, string medical)
       {
           // TODO: Complete member initialization
           this.p_ID = counter++;
           this.fName = fName;
           this.lName = lName;
           this.age = age;
           this.guardian = guardian;
           this.pContact = pContact;
           this.medical = medical;
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

        public override bool Equals(object obj)
        {
            Player other;
            try
            {
                if (obj != null)
                {
                    other = obj as Player;
                    if (other != null)
                    {
                        if(fName.Equals(other.GetFName()) && lName.Equals(other.GetLName()) && age == other.GetAge())
                       // if (firstName.Equals(other.GetFirstName()) && lastName.Equals(other.GetLastName()) && age == other.GetAge() && guardian.Equals(other.GetGuardian()) && contact.Equals(other.GetContact()) && medicalConditions.Equals(other.GetMedicalConditions()))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Wrong object entered
            }
            return false;
        }

        public override string ToString()
        {
            return fName + " " + lName;
        }
    }
}
