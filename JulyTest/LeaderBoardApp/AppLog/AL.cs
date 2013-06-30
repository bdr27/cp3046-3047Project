
using LeaderBoardApp.Utility;
namespace LeaderBoardApp.AppLog
{
    public interface AL
    {
        void StartLog();
        void ButtonPress(string button);
        void TabSelect(string tab);
        void TeamAID(int team);
        void TeamBID(int team);
        void GameTeam(GameTeam gameTeam, string teamID);
    }
}
