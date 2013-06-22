using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class PlayerEdit : PlayerSuper, ModalInterface
    {
        public PlayerEdit()
        {
            modalPlayer.SetEdit();   
        }

        #region ModalInterface Members

        public void SetOwner(Window window)
        {
            modalPlayer.Owner = window;
        }

        public void ShowDialog()
        {
            modalPlayer.ShowDialog();
        }

        public ButtonAction GetButtonAction()
        {
            return buttonAction;
        }

        #endregion

        public void SetPlayerDetails(Player editingPlayer)
        {
            modalPlayer.SetPlayerDetails(editingPlayer);
        }
    }
}
