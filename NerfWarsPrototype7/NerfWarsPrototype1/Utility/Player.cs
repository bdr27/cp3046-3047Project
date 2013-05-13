namespace NerfWarsLeaderboard.Utility
{
    public class Player
    {
        private string firstName;
        private string lastName;
        private int age;
        private string guardian;
        private string contact;
        private string medicalConditions;

      /*  public Player(string firstname, string lastname)
        {
            this.firstName = firstname;
            this.lastName = lastname;
        }*/
     
        public Player()
        {
        }

        public void setFirstName(string firstname)
        {
            this.firstName = firstname;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public void setLastname(string lastName)
        {
            this.lastName = lastName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public void setAge(int age)
        {
            this.age = age;
        }

        public int getAge()
        {
            return age;
        }

        public void setGuardian(string guardian)
        {
            this.guardian = guardian;
        }

        public string getGuardian()
        {
            return guardian;
        }

        public void setContact(string contact)
        {
            this.contact = contact;
        }

        public string getContact()
        {
            return contact;
        }

        public void setMedicalConditions(string medicalConditions)
        {
            this.medicalConditions = medicalConditions;
        }

        public string getMedicalConditions()
        {
            return medicalConditions;
        }
    }
}
