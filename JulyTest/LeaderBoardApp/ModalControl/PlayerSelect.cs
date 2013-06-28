using System.Collections.Generic;
using System.Windows.Controls;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Modals;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class PlayerSelect
    {
        protected ModalSelect modalSelect;
        protected ButtonAction buttonAction;
        protected Dictionary<int, Player> players;
        protected List<int> playersIDSelected;

        public PlayerSelect(Dictionary<int, Player> players)
        {
            this.players = players;
            playersIDSelected = new List<int>();
            modalSelect = new ModalSelect();
            buttonAction = ButtonAction.NONE;
            WireCommonHandlers();
            modalSelect.DisplayPlayers(players);
        }

        public List<int> GetPlayersIDSelected()
        {
            return playersIDSelected;
        }

        public void WireCommonHandlers()
        {
            modalSelect.AddTbSearchTextChangedHandler(HandleSearch_TextChanged);
        }

        private void HandleSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var lastName = modalSelect.GetSearch();
            var displayPlayers = players;
            if (lastName != "")
            {
                displayPlayers = LINQQueries.SearchLastName(players, lastName);
            }
            modalSelect.DisplayPlayers(displayPlayers);
            modalSelect.ShowBox();
        }
    }
}
