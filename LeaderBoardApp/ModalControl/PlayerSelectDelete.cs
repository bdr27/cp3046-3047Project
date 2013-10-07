using System.Collections.Generic;
using System.Windows;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class PlayerSelectDelete : PlayerSelect, ModalInterface
    {
        public PlayerSelectDelete(FileHandler fileHandler)
            : base(fileHandler)
        {
            modalSelect.SetPlayerDelete();
            WireHandlers();
        }

        private void WireHandlers()
        {
            modalSelect.AddBtnModalEditHandler(HandleButtonDelete_Click);
        }

        private void HandleButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var playerSelected = modalSelect.GetSelectedPlayer();
            if (playerSelected != null)
            {
                 var result = MessageBox.Show("Are you sure you want to Delete?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                 if (result == MessageBoxResult.Yes)
                 {
                     var playerID = (int)playerSelected;
                     DeletePlayer(playerID);
                 }
            }
        }

        private void DeletePlayer(int playerID)
        {
            players.Remove(playerID);
            fileHandler.DeletePlayer(playerID);
            modalSelect.DisplayPlayers(players);
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
