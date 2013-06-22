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
            //This needs to be changed at a later date
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
    }
}
