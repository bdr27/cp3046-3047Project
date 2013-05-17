using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard.Model
{
    public class PlayerSelectEditModel
    {
        private ModalPlayerEditDelete playerSelectEdit;
        private List<Player> players;
        private Player player;
        private bool isEditingPlayer;

        public PlayerSelectEditModel(Window window)
        {
            playerSelectEdit = new ModalPlayerEditDelete();
            playerSelectEdit.Owner = window;
            playerSelectEdit.SetEdit();
            WireHandlers();
        }

        private void WireHandlers()
        {
            playerSelectEdit.btnPlayerModalCancel.Click += BtnPlayerModalCancel_Click;
            playerSelectEdit.btnPlayerModalEdit.Click += btnPlayerModalEdit_Click;
        }

        private void btnPlayerModalEdit_Click(object sender, RoutedEventArgs e)
        {
            var tempPlayer =  playerSelectEdit.GetPlayer();
            if (tempPlayer == null)
            {
                //Do nothing
            }
            else
            {
                player = tempPlayer as Player;
                isEditingPlayer = true;
                playerSelectEdit.Hide();
            }
        }

        private void BtnPlayerModalCancel_Click(object sender, RoutedEventArgs e)
        {
            playerSelectEdit.Hide();
        }

        public bool GetIsEditingPlayer()
        {
            return isEditingPlayer;
        }

        public void Show(List<Player> players)
        {
            isEditingPlayer = false;
            this.players = players;
            playerSelectEdit.LoadCmbPlayerNames(players);
            playerSelectEdit.ShowDialog();
        }

        public Player GetPlayer()
        {
            return player;
        }
    }
}
