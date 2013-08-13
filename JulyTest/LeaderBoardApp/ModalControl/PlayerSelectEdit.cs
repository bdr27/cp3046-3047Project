using System.Collections.Generic;
using System.Windows;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class PlayerSelectEdit : PlayerSelect, ModalInterface
    {
        public PlayerSelectEdit(FileHandler fileHandler)
            : base(fileHandler)
        {
            modalSelect.SetPlayerEdit();
            WireHandlers();
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

        private void WireHandlers()
        {
            modalSelect.AddBtnModalEditHandler(HandlerEditButton_Click);
        }

        private void HandlerEditButton_Click(object sender, RoutedEventArgs e)
        {
            var playerSelected = modalSelect.GetSelectedPlayer();
            if (playerSelected != null)
            {
                var playerID = (int)playerSelected;
                ShowEditDialog(playerID);
            }
        }

        private void ShowEditDialog(int playerID)
        {
            var playerEdit = new PlayerEdit();
            playerEdit.SetPlayerDetails(players[playerID]);
            ModalDisplay.ShowModal(playerEdit, modalSelect);
            if (playerEdit.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                players[playerID] = playerEdit.GetPlayer();
                players[playerID].SetP_ID(playerID);
                fileHandler.UpdatePlayer(players[playerID]);
     /*           if (!playersIDSelected.Contains(playerID))
                {
                    playersIDSelected.Add(playerID);
                }*/
                modalSelect.DisplayPlayers(players);
            }
        }        
    }
}
