﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace LeaderBoardApp.Utility
{
    public class SqliteFileHandler : FileHandler
    {
        private int playerCounter;
        private int teamCounter;
        private int ladderCounter;
        private int matchCounter;
        private int currentLadder;
        private Dictionary<int, Ladder> ladders;
        private Dictionary<int, Player> players;
        private Dictionary<int, Team> teams;
        private Dictionary<int, MatchResult> matchResults;
        private SQLiteConnection dbConnection;

        public SqliteFileHandler()
        {
            dbConnection = new SQLiteConnection("Data Source=NerfWarsDB.sqlite;Version=3;");
            dbConnection.Open();
            players = new Dictionary<int, Player>();
            teams = new Dictionary<int, Team>();
            matchResults = new Dictionary<int, MatchResult>();
            ladders = new Dictionary<int, Ladder>();
            playerCounter = 0;
            teamCounter = 0;
            matchCounter = 1;
            currentLadder = 1;
            ladderCounter = 1;
        }

        #region FileHandler Members

        public void LoadPlayers()
        {
            var playerSelect = SqlQueries.SelectAllPlayers();
            var command = new SQLiteCommand(playerSelect, dbConnection);
            var reader = command.ExecuteReader();
            var playerID = 1;
            while (reader.Read())
            {
                playerID = Int32.Parse(reader["P_ID"].ToString());
                players.Add(playerID, new Player(reader["FName"].ToString(), reader["LName"].ToString(), Int32.Parse(reader["Age"].ToString()), reader["Guardian"].ToString(), reader["PContact"].ToString(), reader["Medical"].ToString()));
                players[playerID].SetP_ID(playerID);
            }
            playerCounter = ++playerID;
        }

        public Dictionary<int, Player> GetPlayers()
        {
            return players;
        }

        public void InsertPlayer(Player newPlayer)
        {
            newPlayer.SetP_ID(playerCounter);
            players.Add(playerCounter++, newPlayer);
            var insertPlayer = SqlQueries.InsertPlayer(newPlayer.GetP_ID(), newPlayer.GetFName(), newPlayer.GetLName(), newPlayer.GetAge(), newPlayer.GetGuardian(), newPlayer.GetContact(), newPlayer.GetMedical());
            var insertPlayerCommand = new SQLiteCommand(insertPlayer, dbConnection);
            insertPlayerCommand.ExecuteNonQuery();
        }

        public void UpdatePlayer(Player editPlayer)
        {
            players[editPlayer.GetP_ID()] = editPlayer;
            var updatePlayer = SqlQueries.UpdatePlayer(editPlayer.GetP_ID(), editPlayer.GetFName(), editPlayer.GetLName(), editPlayer.GetAge(), editPlayer.GetGuardian(), editPlayer.GetContact(), editPlayer.GetMedical());
            var updatePlayerCommand = new SQLiteCommand(updatePlayer, dbConnection);
            updatePlayerCommand.ExecuteNonQuery();
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
            var queries = new List<string>();
            queries.Add(SqlQueries.DeletePlayer(deletePlayer));
            queries.Add(SqlQueries.DeletePlayerFromTeam(deletePlayer));
            foreach (var query in queries)
            {
                var command = new SQLiteCommand(query, dbConnection);
                command.ExecuteNonQuery();
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
            var teamSelect = SqlQueries.SelectAllTeams();
            var command = new SQLiteCommand(teamSelect, dbConnection);
            var reader = command.ExecuteReader();
            var teamID = 1;
            while (reader.Read())
            {
                teamID = Int32.Parse(reader["T_ID"].ToString());
                var playerIDs = new List<int>();
                var playerFind = SqlQueries.SelectPlayersFromTeam(teamID);
                var commandPlayerFind = new SQLiteCommand(playerFind, dbConnection);
                var playerReader = commandPlayerFind.ExecuteReader();
                while (playerReader.Read())
                {
                    playerIDs.Add(Int32.Parse(playerReader["P_ID"].ToString()));
                }
          
                teams.Add(teamID, new Team(reader["TName"].ToString(), reader["TContact"].ToString(), playerIDs));
                teams[teamID].SetTeamID(teamID);
            }
            teamCounter = ++teamID;
        }

        public Dictionary<int, Team> GetTeams()
        {
            return teams;
        }

        public void InsertTeam(Team team)
        {
            var teamID = teamCounter++;
            team.SetTeamID(teamID);
            teams.Add(teamID, team.Clone());
            var queries = new List<string>();
            queries.Add(SqlQueries.InsertTeam(teamID, team.GetTeamName(), team.GetTeamContact()));
            foreach (var playerID in team.GetPlayerIDs())
            {
                queries.Add(SqlQueries.InsertPlayerTeam(teamID, playerID));
            }
            foreach (var query in queries)
            {
                var command = new SQLiteCommand(query, dbConnection);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateTeam(Team team)
        {
            var teamID = team.GetTeamID();
            teams[teamID] = team;
            var queries = new List<string>();            
            queries.Add(SqlQueries.DeleteTeamPlayers(teamID));
            foreach (var playerID in team.GetPlayerIDs())
            {
                queries.Add(SqlQueries.InsertPlayerTeam(teamID, playerID));
            }
            queries.Add(SqlQueries.UpdateTeam(teamID, team.GetTeamName(), team.GetTeamContact()));
            foreach (var query in queries)
            {
                var command = new SQLiteCommand(query, dbConnection);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTeam(int teamID)
        {
            var queries = new List<string>();
            queries.Add(SqlQueries.DeleteTeam(teamID));
            queries.Add(SqlQueries.DeleteTeamPlayers(teamID));
            foreach (var query in queries)
            {
                var command = new SQLiteCommand(query, dbConnection);
                command.ExecuteNonQuery();
            }
            teams.Remove(teamID);
        }

        public void DeleteTeamPlayer(int teamID, int playerID)
        {
            
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
            try
            {
                ladders[currentLadder].MatchPlayed(matchResult.GetMatchID(), matchResult);
                //Sql here
            }
            catch (Exception e)
            {
            }
        }

        public void LoadLadders()
        {
        }

        public void SaveLadder(Ladder ladder)
        {
            ladders.Add(++currentLadder, ladder.Clone());

            //sql here
            var lq = ladders[currentLadder];
            //var queries = new List<string>();
            //queries.Add(SqlQueries.InsertLadder(currentLadder, lq.GetName(), lq.GetCurrrentMatch, lq.));
            //foreach (var query in queries)
            //{
              //  var command = new SQLiteCommand(query, dbConnection);
                //command.ExecuteNonQuery();
            //}
            ladderCounter++;
        }

        public Ladder GetLadder(int ladderID)
        {
            return ladders[ladderID];
        }

        public Dictionary<int, Ladder> GetLadders()
        {
            return ladders;
        }

        #endregion
    }
}
