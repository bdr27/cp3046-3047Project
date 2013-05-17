using System.Collections.Generic;

namespace NerfWarsLeaderboard.Utility
{
    public interface DataBaseHandler
    {
        List<Player> LoadPlayers();
        void SavePlayers(List<Player> players);
        void SaveTeams(List<Team> teams); 
        List<Team> LoadTeams();
        List<Player> GetPlayers();
        List<Team> GetTeam();
        void UpdatePlayer(Player player);
        void InsertPlayer(Player player);
        void DeletePlayer(Player player);
        void UpdateTeam(Team team);
        void InsertTeam(Team team);
        void DeleteTeam(Team team);
    }
}
