using LeaderBoardApp.Enum;
using LeaderBoardApp.Modals;
using LeaderBoardApp.Utility;
using System.Diagnostics;
using System.Windows;

namespace LeaderBoardApp.ModalControl
{
    public class PlayerSelectView : PlayerSelect, ModalInterface
    {
        public PlayerSelectView(FileHandler fileHandler)
            :base (fileHandler)
        {
            modalSelect.SetPlayerView();
            WireHandlers();
        }

        private void WireHandlers()
        {
            modalSelect.AddBtnModalEditHandler(HandleBtnModalView_Click);
        }

        private void HandleBtnModalView_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("VIEW IT");
            modalSelect.Hide();
            var playerView = new PlayerView(fileHandler);
            playerView.SetPlayerDetails((int)modalSelect.GetSelectedPlayer());
            ModalDisplay.ShowModal(playerView, modalSelect);
            modalSelect.Show();
        }

        #region ModalInterface
        
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
