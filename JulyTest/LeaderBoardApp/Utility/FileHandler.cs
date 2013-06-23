
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
        void DeletePlayer(Player deletePlayer);
        int GetCurrentPlayerID();
        Player GetPlayer(int playerID);
        #endregion
        #region Team
        void LoadTeams();
        Dictionary<int, Team> GetTeams();
        void InsertTeam(Team team);
        void UpdateTeam(Team team);
        void DeleteTeam(Team team);
        int GetCurrentTeamID();
        Team GetTeam(int teamID);
        #endregion
    }
}
