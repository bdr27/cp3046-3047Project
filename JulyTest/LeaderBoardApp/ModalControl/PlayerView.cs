using LeaderBoardApp.Enum;
using LeaderBoardApp.Modals;
using LeaderBoardApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LeaderBoardApp.ModalControl
{
    class PlayerView : ModalInterface
    {
        ModalPlayerView playerView;
        ButtonAction buttonAction;
        FileHandler fileHandler;
        private Player player;
        private int playerID;

        public PlayerView(FileHandler fileHandler)
        {
            playerView = new ModalPlayerView();
            buttonAction = ButtonAction.NONE;
            this.fileHandler = fileHandler;
            WireHandlers();
        }


        public void SetPlayerDetails(int playerID)
        {
            var tempPlayer = fileHandler.GetPlayer(playerID);
            player = tempPlayer.Clone();
            this.playerID = playerID;
            playerView.SetPlayerDetails(player);
        }

        private void WireHandlers()
        {
            playerView.AddBtnEditHandler(HandlerBtnEdit_Click);
        }

        private void HandlerBtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var playerEdit = new PlayerEdit();
            playerEdit.SetPlayerDetails(player);
            playerView.Hide();
            ModalDisplay.ShowModal(playerEdit, playerView);
            if (playerEdit.GetButtonAction().Equals(ButtonAction.DONE))
            {
                player = playerEdit.GetPlayer();
                player.SetP_ID(playerID);
                fileHandler.UpdatePlayer(player);
                playerView.SetPlayerDetails(player);
            }
            playerView.Show();
        }

        #region ModalInterface
        
        public void SetOwner(Window window)
        {
            playerView.Owner = window;
        }

        public void ShowDialog()
        {
            playerView.ShowDialog();
        }

        public ButtonAction GetButtonAction()
        {
            return buttonAction;
        }
        #endregion

    }
}
