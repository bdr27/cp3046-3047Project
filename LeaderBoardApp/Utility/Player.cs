
namespace LeaderBoardApp.Utility
{
    /// <summary>
    /// Player class contains the information for each player. 
    /// By Default a Player will not have a p_ID. This will be used for editing and possibly in game and team purposes.
    /// IMPORTANT
    /// Error checking for age being an int is not done in this class Must be checked before input
    /// </summary>
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
            if (CheckRegex.IsValidName(fName) && CheckRegex.IsValidName(lName) && CheckRegex.IsValidContact(pContact))
            {
                return true;
            }
            return false;
        }

        public string Details()
        {
            return string.Format("fname: {0}, lname: {1}, age: {2}, guardian: {3}, contact: {4}, medical: {5}, ID: {6}",
                fName, lName, age, guardian, pContact, medical, p_ID);
        }

        public Player Clone()
        {
            return new Player(fName, lName, age, guardian, pContact, medical);
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

        public void SetP_ID(int p_ID)
        {
            this.p_ID = p_ID;
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
