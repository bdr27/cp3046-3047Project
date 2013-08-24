using System.Collections.Generic;
using System.Windows;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class TeamSelectDelete : TeamSelect, ModalInterface
    {
        private List<int> deletedTeams;

        public TeamSelectDelete(FileHandler fileHandler)
            : base(fileHandler)
        {
            deletedTeams = new List<int>();
            modalSelect.SetTeamDelete();
            WireHandlers();
        }

        private void WireHandlers()
        {
            modalSelect.AddBtnModalEditHandler(HandlerBtnModalDelete_Click);
        }

        public List<int> GetDeletedTeams()
        {
            return deletedTeams;
        }

        private void HandlerBtnModalDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var teamSelected = modalSelect.GetSelectedPlayer();
            if (teamSelected != null)
            {
                var result = MessageBox.Show("Are you sure you want to Delete?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var teamID = (int)teamSelected;
                    DeleteTeam(teamID);
                }
            }
        }

        private void DeleteTeam(int teamID)
        {
            teams.Remove(teamID);
            fileHandler.DeleteTeam(teamID);
            modalSelect.DisplayTeams(teams);
 /*           if (!deletedTeams.Contains(teamID))
            {
                deletedTeams.Add(teamID);
            }
   */     }


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
