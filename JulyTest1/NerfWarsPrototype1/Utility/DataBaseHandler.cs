using System.Collections.Generic;

namespace NerfWarsLeaderboard.Utility
{
    public interface DataBaseHandler
    {
        Dictionary<int,Player> LoadPlayers();
        void SavePlayers(List<Player> players);
        void SaveTeams(List<Team> teams); 
        Dictionary<int,Team> LoadTeams();
        Dictionary<int,Player> GetPlayers();
        Dictionary<int,Team> GetTeams();
        void UpdatePlayer(Player player);
        void InsertPlayer(Player player);
        void DeletePlayer(int playerNumber);
        void UpdateTeam(Team team);
        void InsertTeam(Team team);
        void DeleteTeam(int teamCounter);
    }
}
