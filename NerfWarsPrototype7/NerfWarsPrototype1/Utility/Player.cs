using System;
using System.Diagnostics;
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

       public Player()
        {
        }

       public Player(string firstName, string lastName, int age, string guardian, string contact, string medicalConditions)
       {
           // TODO: Complete member initialization
           this.firstName = firstName;
           this.lastName = lastName;
           this.age = age;
           this.guardian = guardian;
           this.contact = contact;
           this.medicalConditions = medicalConditions;
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
                        if (firstName.Equals(other.getFirstName()) && lastName.Equals(other.getLastName()) && age == other.getAge() && guardian.Equals(other.getGuardian()) && contact.Equals(other.getContact()) && medicalConditions.Equals(other.getMedicalConditions()))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Wrong object entered
            }
            return false;
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
