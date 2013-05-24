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
        private ModalPlayer playerEdit;
        private Player player;
        private List<Player> currentPlayers;
        private ButtonAction buttonAction;

        public PlayerEditModel(Window window)
        {
            playerEdit = new ModalPlayer();
            playerEdit.Owner = window;
            WireHandlers();
        }

        public void Show(List<Player> currentPlayers, Player player)
        {
            this.currentPlayers = currentPlayers;
            this.player = player;
            buttonAction = ButtonAction.NONE;
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
                playerEdit.SetPlayer(player);
                playerEdit.UpdatePlayer();
                var count = currentPlayers.Where(item => item == player).Count();
                if (count < 2)
                {
                    buttonAction = ButtonAction.CONFIRM;
                    playerEdit.Close();
                }
            }
        }

        public void BtnCloseAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I Close");
            playerEdit.Close();
            buttonAction = ButtonAction.CLOSE;
        }

        public Player GetPlayer()
        {
            return player;
        }

        public object GetAction()
        {
            return buttonAction;
        }
    }
}
