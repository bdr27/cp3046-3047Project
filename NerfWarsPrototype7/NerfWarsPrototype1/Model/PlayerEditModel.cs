using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard.Model
{
    public class PlayerEditModel
    {
        private PlayerWindow playerEdit;
        private Player oldPlayer;
        private Player newPlayer;
        private List<Player> currentPlayers;

        public PlayerEditModel(Window window)
        {
            playerEdit = new PlayerWindow();
            playerEdit.Owner = window;
            WireHandlers();
        }

        public void Show(List<Player> currentPlayers, Player player)
        {
            this.currentPlayers = currentPlayers;
            this.oldPlayer = player;
            playerEdit.LoadText(player);
            playerEdit.SetEdit();
            playerEdit.ShowDialog();
        }
        private void WireHandlers()
        {
            playerEdit.btnCloseAddPlayer.Click += BtnCloseAddPlayer_Click;
            playerEdit.btnConfirm.Click += btnConfirm_Click;
        }

        public void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (playerEdit.ValidFields())
            {
                newPlayer = playerEdit.GetPlayer();
                if (currentPlayers.Contains(newPlayer))
                {
                    Debug.WriteLine("Display an error");
                }
                else
                {
                    playerEdit.Close();
                }
                Debug.WriteLine("Valid fields");
            }            
        }

        public void BtnCloseAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I Close");

            playerEdit.Close();
        }

        public Player GetPlayer()
        {
            return player;
        }
    }
}
