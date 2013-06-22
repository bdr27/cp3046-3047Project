using System;
using System.Collections.Generic;
using System.Windows;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class PlayerSelectDelete : PlayerSelect, ModalInterface
    {
        public PlayerSelectDelete(Dictionary<int, Player> players)
            : base(players)
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
                var playerID = (int)playerSelected;
                DeletePlayer(playerID);
            }
        }

        private void DeletePlayer(int playerID)
        {
            players.Remove(playerID);
            modalSelect.DisplayPlayers(players);
            if (!playersIDSelected.Contains(playerID))
            {
                playersIDSelected.Add(playerID);
            }
        }

        #region ModalInterface Members

        public void SetOwner(Window window)
        {
            modalSelect.Owner = window;
        }

        public void ShowDialog()
        {
            modalSelect.Show();
        }

        public ButtonAction GetButtonAction()
        {
            return buttonAction;
        }

        #endregion
    }
}
