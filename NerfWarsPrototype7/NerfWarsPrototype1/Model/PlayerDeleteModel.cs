using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard.Model
{
    public class PlayerDeleteModel
    {
        private ModalPlayerEditDelete playerDelete;
        private List<Player> players;

        public PlayerDeleteModel(Window window)
        {
            playerDelete = new ModalPlayerEditDelete();
            playerDelete.Owner = window;
            playerDelete.SetDelete();
            WireHandlers();
        }

        public void Show(List<Player> players)
        {
            playerDelete.LoadCmbPlayerNames(players);
            playerDelete.ShowDialog();
        }

        private void WireHandlers()
        {
            playerDelete.btnPlayerModalCancel.Click += BtnPlayerModalCancel_Click;
            playerDelete.btnPlayerModalEdit.Click += btnPlayerModalEdit_Click;
        }

        void btnPlayerModalEdit_Click(object sender, RoutedEventArgs e)
        {
            if (playerDelete.cmbPlayerNames.SelectedItem != null)
            {
                playerDelete.Hide();
            }
        }

        private void BtnPlayerModalCancel_Click(object sender, RoutedEventArgs e)
        {
            playerDelete.Hide();
        }

        public Player GetPlayer()
        {
            return playerDelete.GetPlayer() as Player;
        }
    }
}
