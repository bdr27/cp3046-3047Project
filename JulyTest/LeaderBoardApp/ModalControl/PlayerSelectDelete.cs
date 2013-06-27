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
            if (!playersIDSelected.Contains(playerID))
            {
                playersIDSelected.Add(playerID);
            } 
            players.Remove(playerID);
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
