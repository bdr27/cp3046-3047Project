using System.Collections.Generic;

namespace NerfWarsLeaderboard.Utility
{
    public interface DataBaseHandler
    {
        List<Player> loadPlayers();
        void savePlayers(List<Player> players);
        void saveTeams(List<Team> teams); 
        List<Team> loadTeams();
        void updatePlayer(Player player);
        void insertPlayer(Player player);
        void deletePlayer(Player player);
        void updateTeam(Team team);
        void insertTeam(Team team);
        void deleteTeam(Team team);
    }
}
