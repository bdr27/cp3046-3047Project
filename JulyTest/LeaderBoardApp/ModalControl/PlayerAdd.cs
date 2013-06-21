using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Modals;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    //TODO change it to an interface
    public class PlayerAdd : ModalInterface
    {
        private ButtonAction buttonAction;
        private ModalPlayer playerAdd;
        private Player newPlayer;

        public PlayerAdd()
        {
            playerAdd = new ModalPlayer();
            buttonAction = ButtonAction.NONE;
            WireHandlers();
        }
        public Player GetPlayer()
        {
            return newPlayer;
        }

        #region ModalInterface Members

        public void ShowDialog()
        {
            playerAdd.ShowDialog();
        }

        public void SetOwner(Window mainWindow)
        {
            playerAdd.Owner = mainWindow;
        }

        public Enum.ButtonAction GetButtonAction()
        {
            return buttonAction;
        }

        #endregion

        private void WireHandlers()
        {
            playerAdd.AddBtnConfirm(HandleBtnConfirm_Click);
        }

        private void HandleBtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I confirm");
            if (playerAdd.IsValidPlayer())
            {
                newPlayer = playerAdd.GetPlayer();
                playerAdd.Close();
            }
            else
            {
                playerAdd.DisplayError();
            }
        }
    }
}
