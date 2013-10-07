using System.Windows;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class TeamAdd : TeamSuper, ModalInterface
    {

        public TeamAdd(FileHandler fileHandler)
            : base(fileHandler)
        {
            modalTeam.SetAdd();
        }

        #region ModalInterface Members

        public void SetOwner(Window window)
        {
            modalTeam.Owner = window;
        }

        public void ShowDialog()
        {
            modalTeam.ShowDialog();
        }

        public ButtonAction GetButtonAction()
        {
            return buttonAction;
        }

        #endregion
    }
}
