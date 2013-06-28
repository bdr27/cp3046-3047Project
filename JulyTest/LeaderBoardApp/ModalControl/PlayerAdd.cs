using System.Windows;
using LeaderBoardApp.Enum;

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
