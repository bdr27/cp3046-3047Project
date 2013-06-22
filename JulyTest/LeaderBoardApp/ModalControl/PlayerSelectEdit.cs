using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Modals;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class PlayerSelectEdit : ModalInterface
    {
        private ModalSelect playerSelectEdit;
        private ButtonAction buttonAction;
        private Dictionary<int, Player> players;
        private List<int> playersIDEdited;

        public PlayerSelectEdit(Dictionary<int, Player> players)
        {
            this.players = players;
            playersIDEdited = new List<int>();
            playerSelectEdit = new ModalSelect();
            buttonAction = ButtonAction.NONE;
            playerSelectEdit.SetPlayerEdit();
            WireHandlers();
        }

        public List<int> GetPlayersIDEdited()
        {
            return playersIDEdited;
        }

        #region ModalInterface Members

        public void SetOwner(Window window)
        {
            playerSelectEdit.Owner = window;
        }

        public void ShowDialog()
        {
            playerSelectEdit.ShowDialog();
        }

        public ButtonAction GetButtonAction()
        {
            return buttonAction;
        }

        #endregion

        private void WireHandlers()
        {
            playerSelectEdit.DisplayPlayers(players);
            playerSelectEdit.AddTbSearchTextChangedHandler(HandleSearch_TextChanged);
            playerSelectEdit.AddBtnModalEditHandler(HandlerEditButton_Click);
        }

        private void HandlerEditButton_Click(object sender, RoutedEventArgs e)
        {
            var playerSelected = playerSelectEdit.GetSelectedPlayer();
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
            ModalDisplay.ShowModal(playerEdit, playerSelectEdit);
            if (playerEdit.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                players[playerID] = playerEdit.GetPlayer();
                players[playerID].SetP_ID(playerID);
                if (!playersIDEdited.Contains(playerID))
                {
                    playersIDEdited.Add(playerID);
                }
                playerSelectEdit.DisplayPlayers(players);
            }
        }

        private void HandleSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var lastName = playerSelectEdit.GetSearch();
            var displayPlayers = players;
            if (lastName != "")
            {
                displayPlayers = LINQQueries.SearchLastName(players, lastName);
            }
            playerSelectEdit.DisplayPlayers(displayPlayers);
        }
    }
}
