using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var teamEdit = new TeamEdit(fileHandler, teamID);
                teams[teamID].SetTeamID(teamID);
                teamEdit.SetTeam(teams[teamID]);
                teamEdit.ShowTeam();
                ModalDisplay.ShowModal(teamEdit, modalSelect);
                if (teamEdit.GetButtonAction().Equals(ButtonAction.CONFIRM))
                {
                    teams[teamID] = teamEdit.GetTeam();
                    if (!editedTeamsID.Contains(teamID))
                    {
                        editedTeamsID.Add(teamID);
                    }
                    modalSelect.DisplayTeams(teams);
                }
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
