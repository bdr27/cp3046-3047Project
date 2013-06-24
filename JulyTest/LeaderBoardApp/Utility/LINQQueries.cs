using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public static class LINQQueries
    {
        public static Dictionary<int, Player> SearchLastName(Dictionary<int, Player> players, string lastName)
        {
            var searchPlayers = new Dictionary<int, Player>();
            var queryResults = from Player in players where Player.Value.GetLName().ToLower().StartsWith(lastName) select Player;
            //It seems we need to loop through the results for searching players
            foreach (var player in queryResults)
            {
                searchPlayers.Add(player.Key, player.Value);
            }
            return searchPlayers;
        }

        public static IOrderedEnumerable<KeyValuePair<int, Player>> OrderPlayers(Dictionary<int, Player> players)
        {
            return players.OrderBy(lastName => lastName.Value.GetLName().ToLower()).ThenBy(firstName => firstName.Value.GetFName().ToLower()).ThenBy(age => age.Value.GetAge());
        }

        public static IOrderedEnumerable<KeyValuePair<int, Team>> OrderTeams(Dictionary<int, Team> teams)
        {
            return teams.OrderBy(teamName => teamName.Value.GetTeamName().ToLower());
        }

        public static Dictionary<int, Team> SearchTeamName(Dictionary<int, Team> teams, string teamName)
        {
            var searchTeams = new Dictionary<int, Team>();
            var queryResults = from Team in teams where Team.Value.GetTeamName().ToLower().Contains(teamName.ToLower()) select Team;
            foreach (var team in queryResults)
            {
                searchTeams.Add(team.Key, team.Value);
            }
            return searchTeams;
        }
    }
}
