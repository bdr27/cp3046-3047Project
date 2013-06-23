using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public class Team
    {
        private int teamID;
        private string teamName;
        private string teamContact;
        private List<int> playerIDs;

        public Team(string teamName, string teamContact, List<int> playerIDs)
        {
            this.teamName = teamName;
            this.teamContact = teamContact;
            this.playerIDs = playerIDs;
        }

        public void SetPlayerIDs(List<int> playerIDs)
        {
            this.playerIDs = playerIDs;
        }

        public void AddPlayer(int playerID)
        {
            playerIDs.Add(playerID);
        }

        public void RemovePlayer(int playerID)
        {
            playerIDs.Remove(playerID);
        }

        public List<int> GetPlayerIDs()
        {
            return playerIDs;
        }

        public void SetTeamName(string teamName)
        {
            this.teamName = teamName;
        }

        public void SetTeamContact(string teamContact)
        {
            this.teamContact = teamContact;
        }

        public string GetTeamName()
        {
            return teamName;
        }

        public string GetTeamContact()
        {
            return teamContact;
        }

        public bool IsValidTeam()
        {
            return CheckRegex.IsValidContact(teamContact) && CheckRegex.IsValidTeamName(teamName);
        }

        public List<int> ClonePlayerIDs()
        {
            var clonePlayerIDs = new List<int>();
            foreach (var playerID in playerIDs)
            {
                clonePlayerIDs.Add(playerID);
            }
            return clonePlayerIDs;
        }

        public Team Clone()
        {
            return new Team(GetTeamName(), GetTeamContact(), ClonePlayerIDs());
        }
    }
}
