using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard.Model
{
    public class SelectTeamModel
    {
        private ModalTeamEditDelete playerEdit;
        private ButtonAction buttonAction;
        private List<Team> teams;
        private Team teamRemove;
        private CurrentAction currentAction;

        public SelectTeamModel(Window mainWindow)
        {
            buttonAction = ButtonAction.NONE;
            playerEdit = new ModalTeamEditDelete();
            playerEdit.Owner = mainWindow;
            wireButtonHandlers();
        }

        private void wireButtonHandlers()
        {
            playerEdit.btnModalTeamEdit.Click += btnModalTeamEdit_Click;
            playerEdit.btnEditTeamCancel.Click += btnEditTeamCancel_Click;
        }

        void btnEditTeamCancel_Click(object sender, RoutedEventArgs e)
        {
            buttonAction = ButtonAction.CLEAR;
            playerEdit.Hide();
        }

        private void btnModalTeamEdit_Click(object sender, RoutedEventArgs e)
        {
            buttonAction = ButtonAction.EDIT;
            teamRemove = playerEdit.GetTeam();
            playerEdit.Hide();
        }

        public Team getRemovedTeam()
        {
            return teamRemove;
        }

        public void updateTeams(List<Team> teams)
        {
            this.teams = teams;
        }

        internal void show()
        {
            playerEdit.UpdateCombo(teams);
            playerEdit.ShowDialog();
        }

        internal ButtonAction getButtonAction()
        {
            return buttonAction;
        }
    }
}
