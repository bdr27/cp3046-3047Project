using System.Collections.Generic;

namespace NerfWarsLeaderboard.Utility
{
    public interface DataBaseHandler
    {
        public List<Player> loadPlayers();
        public void savePlayers(List<Player> players);
        public void saveTeams(List<Team> teams); 
        public List<Team> loadTeams();
        public void updatePlayer(Player player);
        public void insertPlayer(Player player);
        public void deletePlayer(Player player);
        public void updateTeam(Team team);
        public void insertTeam(Team team);
        public void deleteTeam(Team team);
    }
}
