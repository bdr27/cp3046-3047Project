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
    public class TeamEditModel
    {
        private ModalTeamEditDelete teamEditModal;
        private List<Team> teams;
        private ButtonAction buttonAction;

        public TeamEditModel(Window window)
        {
            teamEditModal = new ModalTeamEditDelete();
            teamEditModal.Owner = window;
            WireHandlers();
        }

        public void Show()
        {
            buttonAction = ButtonAction.NONE;
            teamEditModal.UpdateCombo(teams);
            teamEditModal.ShowDialog();
        }

        private void WireHandlers()
        {
            teamEditModal.btnModalTeamEdit.Click += BtnModalTeamEdit_Click;
            teamEditModal.btnEditTeamCancel.Click += BtnEditTeamCancel_Click;
        }

        private void BtnModalTeamEdit_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I Edit stuff");
            buttonAction = ButtonAction.CONFIRM;
            teamEditModal.Hide();
        }

        private void BtnEditTeamCancel_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I cancel and close the window");
            buttonAction = ButtonAction.CLOSE;
            teamEditModal.Hide();
        }
        public void UpdateTeams(List<Team> teams)
        {
            this.teams = teams;
        }

        public ButtonAction GetButtonAction()
        {
            return buttonAction;
        }

        public Team GetTeam()
        {
            return teamEditModal.GetTeam();
        }
    }
}
