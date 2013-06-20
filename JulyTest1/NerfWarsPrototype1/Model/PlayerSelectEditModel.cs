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
        private Dictionary<int, Player> players;
        private Player player;
        private ButtonAction buttonAction;
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
                buttonAction = ButtonAction.CONFIRM;
                player = tempPlayer as Player;
                isEditingPlayer = true;
                playerSelectEdit.Hide();
            }
        }

        private void BtnPlayerModalCancel_Click(object sender, RoutedEventArgs e)
        {
            buttonAction = ButtonAction.NONE;
            playerSelectEdit.Hide();
        }

        public bool GetIsEditingPlayer()
        {
            return isEditingPlayer;
        }

        public void Show(Dictionary<int, Player> players)
        {
            buttonAction = ButtonAction.NONE;
            isEditingPlayer = false;
            this.players = players;
            playerSelectEdit.LoadCmbPlayerNames(players);
            playerSelectEdit.ShowDialog();
        }

        public Player GetPlayer()
        {
            return player;
        }

        public ButtonAction GetButtonAction()
        {
            return buttonAction;
        }
    }
}
