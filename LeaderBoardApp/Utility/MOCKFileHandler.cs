using System;
using System.Collections.Generic;

namespace LeaderBoardApp.Utility
{
    public class MOCKFileHandler : FileHandler
    {
        private int playerCounter;
        private int teamCounter;
        private int matchCounter;
        private Dictionary<int, Player> players;
        private Dictionary<int, Team> teams;
        private Dictionary<int, MatchResult> matchResults;

        public MOCKFileHandler()
        {
            //Default to 1 so that players without ID set will be 0
            playerCounter = 1;
            teamCounter = 1;
            matchCounter = 1;
            players = new Dictionary<int, Player>();
            teams = new Dictionary<int, Team>();
            matchResults = new Dictionary<int, MatchResult>();
        }
        #region FileHandler Members

        public void LoadPlayers()
        {
            Console.WriteLine("Loading players");

            players.Add(playerCounter++, new Player("john", "smith", 24, "", "40404040", ""));
            players.Add(playerCounter++, new Player("Jill", "smith", 12, "", "40404034", ""));
            players.Add(playerCounter++, new Player("Geroge", "Lucas", 25, "Marie", "5556565", "I like starwars"));
            foreach (var player in players)
            {
                player.Value.SetP_ID(player.Key);
                Console.WriteLine("\t" + player.Value.Details());
            }
        }

        public Dictionary<int, Player> GetPlayers()
        {
            return players;
        }

        public void InsertPlayer(Player newPlayer)
        {
            players.Add(playerCounter++, newPlayer);
        }

        public void UpdatePlayer(Player editPlayer)
        {
            players[editPlayer.GetP_ID()] = editPlayer;
        }

        public void DeletePlayer(int deletePlayer)
        {
            players.Remove(deletePlayer);
            var editedTeams = new Dictionary<int, Team>();
            foreach (var team in teams)
            {
                var teamValue = team.Value;
                if (teamValue.GetPlayerIDs().Contains(deletePlayer))
                {
                    teamValue.RemovePlayer(deletePlayer);
                    editedTeams.Add(team.Key, teamValue);
                }
            }
            foreach (var editedTeam in editedTeams)
            {
                teams[editedTeam.Key] = editedTeam.Value;
            }
        }

        public int GetCurrentPlayerID()
        {
            return playerCounter;
        }

        public Player GetPlayer(int playerID)
        {
            return players[playerID];
        }

        public List<string> GetPlayersFirstName(int teamID)
        {
            var team = teams[teamID];
            var playerNames = new List<string>();
            foreach (var playerID in team.GetPlayerIDs())
            {
                var player = players[playerID];
                playerNames.Add(player.GetFName());
            }
            return playerNames;
        }

        public void LoadTeams()
        {
            teams.Add(teamCounter++, new Team("WildCats", "6565656", new List<int> { 1 }));
            teams.Add(teamCounter++, new Team("Wildcats", "5454545", new List<int> { 2 }));
            teams.Add(teamCounter++, new Team("BobCats", "43434343", new List<int> { 3 }));
        }

        public Dictionary<int, Team> GetTeams()
        {
            foreach (var team in teams)
            {
                team.Value.SetTeamID(team.Key);
            }
            return teams;
        }

        public void InsertTeam(Team team)
        {
            teams.Add(teamCounter++, team.Clone());
        }

        public void UpdateTeam(Team team)
        {
            teams[team.GetTeamID()] = team;
        }

        public void DeleteTeam(int teamID)
        {
            teams.Remove(teamID);
        }

        public void DeleteTeamPlayer(int teamID, int playerID)
        {
            teams[teamID].RemovePlayer(playerID);
        }

        public int GetCurrentTeamID()
        {
            return teamCounter;
        }

        public Team GetTeam(int teamID)
        {
            return teams[teamID];
        }

        public Dictionary<int, MatchResult> GetMatchResults()
        {
            return matchResults;
        }

        public void AddMatchResult(MatchResult match)
        {
            var matchResult = match.Clone();
            matchResult.SetTeamBID(matchCounter);
            matchResults.Add(matchCounter++, matchResult);            
        }

        #endregion
    }
}
