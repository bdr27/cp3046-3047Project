using NerfWarsLeaderboard.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NerfWarsLeaderboard.Model
{
    public class PlayerAddModel
    {
        private PlayerWindow playerAdd;
        private Player player;
        private List<Player> currentPlayers;

        public PlayerAddModel(Window window)
        {
            playerAdd = new PlayerWindow();
            playerAdd.Owner = window;
            WireHandlers();
        }

        public void Show(List<Player> currentPlayers)
        {
            this.currentPlayers = currentPlayers;
            playerAdd.ClearText();
            playerAdd.ShowDialog();
        }
        private void WireHandlers()
        {
            playerAdd.btnCloseAddPlayer.Click += BtnCloseAddPlayer_Click;
            playerAdd.btnConfirm.Click += btnConfirm_Click;
        }

        void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (playerAdd.ValidFields())
            {
                player = playerAdd.GetPlayer();
                if (currentPlayers.Contains(player))
                {
                    Debug.WriteLine("Display an error");
                }
                else
                {
                    playerAdd.Hide();
                }
                Debug.WriteLine("Valid fields");
            }            
        }

        void BtnCloseAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I Close");

            playerAdd.Hide();
        }

        public Player GetPlayer()
        {
            return player;
        }
    }
}
