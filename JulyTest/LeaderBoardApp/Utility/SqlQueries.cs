using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public static class SqlQueries
    {
        public static string SelectAllPlayers()
        {
            return "SELECT * FROM Players";
        }

        public static string SelectAllTeams()
        {
            return "SELECT * FROM Teams";
        }

        public static string SelectPlayersFromTeam(int teamID)
        {
            return "SELECT * FROM PlayerTeam WHERE T_ID = " + teamID + "";
        }

        public static string InsertPlayer(int P_ID, string fName, string lName, int age, string guardian, string pContact, string medical)
        {
            return string.Format("INSERT INTO Players (P_ID, FName, LName, Age, Guardian, PContact, Medical) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", P_ID, fName, lName, age, guardian, pContact, medical);
        }

        public static string UpdatePlayer(int P_ID, string fName, string lName, int age, string guardian, string pContact, string medical)
        {
            return string.Format("UPDATE Players SET FName = '{1}', LName = '{2}', Age = '{3}', Guardian = '{4}', PContact = '{5}', Medical = '{6}' Where P_ID = '{0}'", P_ID, fName, lName, age, guardian, pContact, medical);
        }

        public static string DeletePlayer(int deletePlayer)
        {
            return string.Format("DELETE FROM Players WHERE P_ID = '{0}'", deletePlayer);
        }

        public static string DeletePlayerFromTeam(int deletePlayer)
        {
            return string.Format("DELETE FROM PlayerTeam WHERE P_ID = '{0}'", deletePlayer);
        }

        public static string InsertTeam(int teamID, string teamName, string teamContact)
        {
            return string.Format("INSERT INTO Teams (T_ID, TName, TContact) VALUES ('{0}', '{1}', '{2}')", teamID, teamName, teamContact);
        }

        public static string InsertPlayerTeam(int teamID, int playerID)
        {
            return string.Format("INSERT INTO PlayerTeam (T_ID, P_ID) VALUES ('{0}', '{1}')", teamID, playerID);
        }

        public static string DeleteTeam(int teamID)
        {
            return string.Format("DELETE FROM Teams WHERE T_ID = '{0}'", teamID);
        }

        public static string DeleteTeamPlayers(int teamID)
        {
            return string.Format("DELETE FROM PlayerTeam WHERE T_ID = '{0}'", teamID);
        }

        public static string UpdateTeam(int teamID, string name, string contact)
        {
            return string.Format("UPDATE Teams SET TName = '{0}', TContact = '{1}' WHERE T_ID = '{2}'", name, contact, teamID);
        }
    }
}
