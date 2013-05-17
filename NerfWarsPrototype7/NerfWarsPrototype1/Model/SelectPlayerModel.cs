using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard.Model
{
    /// <summary>
    /// 
    /// Really need to use inheritence
    /// </summary>
    public class SelectPlayerModel
    {
        private ModalPlayerEditDelete playerEdit;
        private ButtonAction buttonAction;
        private List<Player> players;
        private CurrentAction currentAction;

        public SelectPlayerModel(Window mainWindow)
        {
            buttonAction = ButtonAction.NONE;
            playerEdit = new ModalPlayerEditDelete();
            playerEdit.Owner = mainWindow;
            wireButtonHandlers();
        }

        private void wireButtonHandlers()
        {
            playerEdit.btnPlayerModalEdit.Click += btnPlayerModalEdit_Click;
            playerEdit.btnPlayerModalCancel.Click += btnPlayerModalCancel_Click;
        }

        void btnPlayerModalCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            buttonAction = ButtonAction.CLOSE;
            playerEdit.Hide();
        }

        private void btnPlayerModalEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            buttonAction = ButtonAction.EDIT;
            playerEdit.Hide();
        }

        public ButtonAction getButtonAction()
        {
            return buttonAction;
        }

        public void showWindow(List<Player> players, CurrentAction currentAction)
        {
            this.currentAction = currentAction;
            switch (currentAction)
            {
                case CurrentAction.EDIT:
                    buttonAction = ButtonAction.NONE;
                    playerEdit.SetEdit();
                    break;
                case CurrentAction.DELETE:
                    playerEdit.SetDelete();
                    break;
            }
            
            this.players = players;
            playerEdit.FillComboBox(this.players);
            playerEdit.ShowDialog();
        }

        internal Player getPlayer()
        {
            return playerEdit.GetPlayer();
        }

        public List<Player> getPlayers()
        {
            return players;
        }

        public List<Player> deletePlayer(Player player)
        {
            players.Remove(player);
            return players;
        }

        internal void setToNothing()
        {
            buttonAction = ButtonAction.NONE;
        }
    }
}
