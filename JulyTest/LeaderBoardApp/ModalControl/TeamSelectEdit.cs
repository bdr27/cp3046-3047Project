using System.Collections.Generic;
using System.Windows;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class TeamSelectEdit : TeamSelect, ModalInterface
    {
        public TeamSelectEdit(FileHandler fileHandler)
            : base(fileHandler)
        {
            modalSelect.SetTeamEdit();
            WireHandlers();
        }

        private void WireHandlers()
        {
            modalSelect.AddBtnModalEditHandler(HandleEditButton_Click);
        }

        private void HandleEditButton_Click(object sender, RoutedEventArgs e)
        {
            var tempTeamID =  modalSelect.GetSelectedPlayer();
            if(tempTeamID != null)
            {
                var teamID = (int) tempTeamID;
                ShowEditDialog(teamID);
            }
        }

        private void ShowEditDialog(int teamID)
        {
            var teamEdit = new TeamEdit(fileHandler);
            var team = fileHandler.GetTeam(teamID);
            teamEdit.SetTeam(team);
            var playerIDs = team.GetPlayerIDs();
            var teamPlayers = new Dictionary<int, Player>();
            foreach (var playerID in playerIDs)
            {
                teamPlayers.Add(playerID, fileHandler.GetPlayers()[playerID]);
            }
            teamEdit.SetPlayers(teamPlayers);
            teamEdit.ShowTeam();
            ModalDisplay.ShowModal(teamEdit, modalSelect);
            if (teamEdit.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                var newTeam = teamEdit.GetTeam();
                newTeam.SetTeamID(teamID);
                fileHandler.UpdateTeam(newTeam);
                modalSelect.DisplayTeams(fileHandler.GetTeams());
            }
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
