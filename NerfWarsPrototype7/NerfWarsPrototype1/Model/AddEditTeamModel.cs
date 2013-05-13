using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard.Model
{
    public class AddEditTeamModel
    {
        private TeamWindow playerTeam;
        private ButtonAction buttonAction;
        private List<Player> players;
        private Team team;

        public AddEditTeamModel(Window mainWindow)
        {
            playerTeam = new TeamWindow();
            playerTeam.Owner = mainWindow;
            wireButtonHandlers();
        }        

        private void wireButtonHandlers()
        {
            playerTeam.btnTeamAddExistingPlayer.Click += btnTeamAddExistingPlayer_Click;
            playerTeam.btnTeamClear.Click += btnTeamClear_Click;
            playerTeam.btnTeamCreateNewPlayer.Click += btnTeamCreateNewPlayer_Click;
            playerTeam.btnTeamDone.Click += btnTeamDone_Click;
        }

        private void btnTeamDone_Click(object sender, RoutedEventArgs e)
        {
            buttonAction = ButtonAction.CONFIRM;
        }

        private void btnTeamCreateNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            buttonAction = ButtonAction.CREATE;
            playerTeam.Hide();
        }

        private void btnTeamClear_Click(object sender, RoutedEventArgs e)
        {
            buttonAction = ButtonAction.CLEAR;
        }

        private void btnTeamAddExistingPlayer_Click(object sender, RoutedEventArgs e)
        {
            buttonAction = ButtonAction.ADD;
        }

        public ButtonAction getButtonAction()
        {
            return buttonAction;
        }

        internal void addPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        internal void showWindow(CurrentAction currentAction)
        {
            switch (currentAction)
            {
                case CurrentAction.ADD:
                    break;
            }
            playerTeam.ShowDialog();
        }
    }
}
