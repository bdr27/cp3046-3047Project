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
    public class AddEditPlayerModel
    {
        private PlayerWindow playerAdd;
        private ButtonAction buttonAction;
        private Player player;

        public AddEditPlayerModel(Window mainWindow)
        {
            playerAdd = new PlayerWindow();
            playerAdd.Owner = mainWindow;
            wireButtonHandlers();
        }

        public void showWindow(CurrentAction currentAction, Player player)
        {
            buttonAction = ButtonAction.NONE;
            switch (currentAction)
            {
                case CurrentAction.ADD:
                    playerAdd.TitleChangeToAdd();
                    playerAdd.clearText();
                    break;
                case CurrentAction.EDIT:
                    playerAdd.TitleChangeToEdit();
                    playerAdd.loadText(player);
                    break;
            }            
            playerAdd.ShowDialog();
        }

        private void wireButtonHandlers()
        {
            playerAdd.btnCloseAddPlayer.Click += btnCloseAddPlayer_Click;
            playerAdd.btnConfirm.Click += btnConfirm_Click;
        }

        void btnConfirm_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            bool validName = false;
            try
            {
                this.player = new Player(playerAdd.getFirstName(), playerAdd.getLastName(), playerAdd.getAge(), playerAdd.getGuardian(), playerAdd.getContact(), playerAdd.getMedicalConditions());
                validName = true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            if (validName)
            {
                buttonAction = ButtonAction.CONFIRM;
                playerAdd.Hide();                
            }
            
        }

        void btnCloseAddPlayer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            buttonAction = ButtonAction.CLOSE;
            playerAdd.Hide();
        }

        public ButtonAction getButtonAction()
        {
            return buttonAction;
        }

        public Player getPlayer()
        {
            return player;
        }


        internal void showWindow(CurrentAction currentAction)
        {
            buttonAction = ButtonAction.NONE;
            switch (currentAction)
            {
                case CurrentAction.ADD:
                    playerAdd.TitleChangeToAdd();
                    playerAdd.clearText();
                    break;
            }
            playerAdd.ShowDialog();
        }

        internal void setToNothing()
        {
            buttonAction = ButtonAction.NONE;
        }
    }
}
