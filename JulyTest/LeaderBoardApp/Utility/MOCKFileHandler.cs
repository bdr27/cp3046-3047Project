﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public class MOCKFileHandler : FileHandler
    {
        private int counter;
        private Dictionary<int, Player> players;

        public MOCKFileHandler()
        {
            //Default to 1 so that players without ID set will be 0
            counter = 1;
            players = new Dictionary<int, Player>();
        }
        #region FileHandler Members

        public void LoadPlayers()
        {
            Console.WriteLine("Loading players");

            players.Add(counter++, new Player("john", "smith", 24, "", "40404040", ""));
            players.Add(counter++, new Player("Jill", "smith", 12, "", "40404034", ""));
            players.Add(counter++, new Player("Geroge", "Lucas", 25, "Marie", "5556565", "I like starwars"));
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
            players.Add(counter++, newPlayer);
        }

        public void UpdatePlayer(Player editPlayer)
        {
            players[editPlayer.GetP_ID()] = editPlayer;
        }

        public void DeletePlayer(Player deletePlayer)
        {
            players.Remove(deletePlayer.GetP_ID());
        }

        #endregion
    }
}
