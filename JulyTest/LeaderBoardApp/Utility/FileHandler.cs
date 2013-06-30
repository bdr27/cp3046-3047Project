
using System.Collections.Generic;
namespace LeaderBoardApp.Utility
{
    public interface FileHandler
    {
        #region Player
        void LoadPlayers();
        Dictionary<int, Player> GetPlayers();
        void InsertPlayer(Player newPlayer);
        void UpdatePlayer(Player editPlayer);
        void DeletePlayer(int playerID);
        int GetCurrentPlayerID();
        Player GetPlayer(int playerID);
        List<string> GetPlayersFirstName(int teamID);
        #endregion
        #region Team
        void LoadTeams();
        Dictionary<int, Team> GetTeams();
        void InsertTeam(Team team);
        void UpdateTeam(Team team);
        void DeleteTeam(int teamID);
        int GetCurrentTeamID();
        Team GetTeam(int teamID);
        #endregion
    }
}
