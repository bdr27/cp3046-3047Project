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
    public class PlayerAdd : PlayerSuper, ModalInterface
    {
        public PlayerAdd()
        {
            modalPlayer.SetAdd();
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
    }
}
