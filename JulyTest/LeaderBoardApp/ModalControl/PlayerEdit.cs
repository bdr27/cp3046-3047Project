using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Modals;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class PlayerEdit : ModalInterface
    {
        ModalSelectEdit playerSelectEdit;
        ButtonAction buttonAction;
        Dictionary<int, Player> players;
        public PlayerEdit(Dictionary<int, Player> players)
        {
            this.players = players;
            playerSelectEdit = new ModalSelectEdit();
            buttonAction = ButtonAction.NONE;
            playerSelectEdit.SetPlayerEdit();
            WireHandlers();
        }

        #region ModalInterface Members

        public void SetOwner(Window mainWindow)
        {
            playerSelectEdit.Owner = mainWindow;
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
            playerSelectEdit.ShowPlayers(players);
            playerSelectEdit.AddTbSearchTextChangedHandler(FindPlayerLastNames);
           // throw new NotImplementedException();
        }

        private void FindPlayerLastNames(object sender, TextChangedEventArgs e)
        {
            var searchLastName = playerSelectEdit.GetSearch();
            if (searchLastName != "")
            {
                var searchPlayers = new Dictionary<int, Player>();
                var queryResults = from Player in players where Player.Value.GetLName().ToLower().StartsWith(searchLastName) select Player;
                //This needs to be changed at a later date
                foreach (var player in queryResults)
                {
                    searchPlayers.Add(player.Key, player.Value);
                }
                playerSelectEdit.ShowPlayers(searchPlayers);
            }
            else
            {
                playerSelectEdit.ShowPlayers(players);
            }
        }
    }
}
