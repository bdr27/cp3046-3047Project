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

        public void SetFirstName(string firstname)
        {
            this.firstName = firstname;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public void SetLastname(string lastName)
        {
            this.lastName = lastName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public void SetAge(int age)
        {
            this.age = age;
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
            this.contact = contact;
        }

        public string GetContact()
        {
            return contact;
        }

        public void SetMedicalConditions(string medicalConditions)
        {
            this.medicalConditions = medicalConditions;
        }

        public string GetMedicalConditions()
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
                        if (firstName.Equals(other.GetFirstName()) && lastName.Equals(other.GetLastName()) && age == other.GetAge() && guardian.Equals(other.GetGuardian()) && contact.Equals(other.GetContact()) && medicalConditions.Equals(other.GetMedicalConditions()))
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
            return firstName + " " + lastName;
        }
    }
}
