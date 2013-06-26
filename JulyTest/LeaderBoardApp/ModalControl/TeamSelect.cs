using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Modals;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class TeamSelect
    {
        protected ModalSelect modalSelect;
        protected ButtonAction buttonAction;
        protected Dictionary<int, Team> teams;
        protected Dictionary<int, Player> players;
        protected List<int> editedTeamsID;
        protected FileHandler fileHandler;

        public TeamSelect(FileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
            teams = fileHandler.GetTeams();
            editedTeamsID = new List<int>();
            modalSelect = new ModalSelect();
            buttonAction = ButtonAction.NONE;
            WireCommonHandlers();
            modalSelect.DisplayTeams(teams);
        }

        public Dictionary<int, Team> GetTeams()
        {
            return teams;
        }

        public Dictionary<int, Player> GetPlayers()
        {
            return players;
        }

        public List<int> GetEditedTeamsID()
        {
            return editedTeamsID;
        }

        private void WireCommonHandlers()
        {
            modalSelect.AddTbSearchTextChangedHandler(HandleSearch_TextChanged);
        }

        private void HandleSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var teamName = modalSelect.GetSearch();
            var displayTeams = teams;
            if (teamName != "")
            {
                displayTeams = LINQQueries.SearchTeamName(teams, teamName);
            }
            modalSelect.DisplayTeams(displayTeams);
        }
    }
}
