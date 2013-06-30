using System;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.AppLog
{
    public class ConsoleAL : AL
    {
      
        #region AL Members

        public void StartLog()
        {
            Console.WriteLine("Start Time>>> " + DateTime.Now); 
        }

        public void ButtonPress(string button)
        {
            Console.WriteLine("Button>>> " + button);
        }

        public void TabSelect(string tab)
        {
            Console.WriteLine("TAB SELECTED: " + tab.ToUpper());
        }

        public void TeamAID(int teamID)
        {
            Console.WriteLine("Team A ID>>> " + teamID);
        }
        public void TeamBID(int teamID)
        {
            Console.WriteLine("Team B ID>>> " + teamID);
        }

        public void GameTeam(GameTeam gameTeam, string teamID)
        {
            Console.Write("Game Team " + teamID + ">>> ID:" + gameTeam.ID + ", Team Name: " + gameTeam.teamName + ", Team Contact: " + gameTeam.teamContact + ", Players: ");
            foreach (var player in gameTeam.teamPlayers)
            {
                Console.Write(player + " ");
            }
            Console.WriteLine();
        }
        #endregion
    }
}
