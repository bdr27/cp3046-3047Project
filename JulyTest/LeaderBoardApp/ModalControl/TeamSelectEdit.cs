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
    public class TeamSelectEdit : TeamSelect, ModalInterface
    {
        public TeamSelectEdit(Dictionary<int, Team> teams)
            : base (teams)
        {
            modalSelect.SetTeamEdit();
            WireHandlers();
        }

        private void WireHandlers()
        {
            modalSelect.AddBtnModalEditHandler(HandleEditButton_Click);
        }

        private void HandleEditButton_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        #region ModalInterface Members

        public void SetOwner(Window window)
        {
            modalSelect.Owner = window;
        }

        public void ShowDialog()
        {
            modalSelect.ShowDialog();
        }

        public ButtonAction GetButtonAction()
        {
            return buttonAction;
        }

        #endregion
    }
}
