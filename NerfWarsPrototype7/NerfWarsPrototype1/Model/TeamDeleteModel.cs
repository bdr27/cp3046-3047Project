using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard.Model
{
    public class TeamDeleteModel
    {
        private ModalTeamEditDelete teamDeleteModel;
        private List<Team> teams;
        private ButtonAction buttonAction;

        public TeamDeleteModel(Window window)
        {
            teamDeleteModel = new ModalTeamEditDelete();
            teamDeleteModel.Owner = window;
            WireHandlers();

        }

        public void UpdateTeams(List<Team> teams)
        {
            this.teams = teams;
        }
        public void Show()
        {
            teamDeleteModel.SetDelete();
            buttonAction = ButtonAction.NONE;
            teamDeleteModel.UpdateCombo(teams);
            teamDeleteModel.ShowDialog();
        }

        private void WireHandlers()
        {
            teamDeleteModel.btnEditTeamCancel.Click += btnEditTeamCancel_Click;
            teamDeleteModel.btnModalTeamEdit.Click += btnModalTeamEdit_Click;
        }

        private void btnModalTeamEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            buttonAction = ButtonAction.CONFIRM;
            Debug.WriteLine("I Delete the team");
            teamDeleteModel.Hide();
        }

        private void btnEditTeamCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            buttonAction = ButtonAction.NONE;
            Debug.WriteLine("I Close the window");
            teamDeleteModel.Hide();
        }

        public Team GetTeam()
        {
            return teamDeleteModel.GetTeam();
        }

        public ButtonAction GetButtonAction()
        {
            return buttonAction;
        }
    }
}
