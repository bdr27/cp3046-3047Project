using System;

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
            Console.WriteLine(button);
        }

        #endregion
    }
}
