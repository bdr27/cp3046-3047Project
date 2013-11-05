
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
        void DeleteTeamPlayer(int teamID, int playerID);
        int GetCurrentTeamID();
        Team GetTeam(int teamID);
        #endregion
        #region Results
        Dictionary<int, MatchResult> GetMatchResults();
        void AddMatchResult(MatchResult match);
        #endregion
        #region Ladder
        void LoadLadders();
        void SaveLadder(Ladder ladder);
        Ladder GetLadder(int ladderID);
        Dictionary<int, Ladder> GetLadders();
        #endregion

    }
}
