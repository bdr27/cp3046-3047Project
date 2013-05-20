using NerfWarsLeaderboard.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NerfWarsLeaderboard.Model
{
    public class TeamAddModel
    {
        private TeamWindow addTeam;
        private ButtonAction buttonAction;
        private Team team;

        public TeamAddModel(Window window)
        {
            addTeam = new TeamWindow();
            addTeam.Owner = window;
            WireHandlers();
        }

        public void Show()
        {
            buttonAction = ButtonAction.NONE;
            addTeam.ShowDetails(team);
            addTeam.ShowDialog();
        }

        private void WireHandlers()
        {
            addTeam.btnTeamAddExistingPlayer.Click += BtnTeamAddExistingPlayer_Click;
            addTeam.btnTeamClear.Click += BtnTeamClear_Click;
            addTeam.btnTeamCreateNewPlayer.Click += BtnTeamCreateNewPlayer_Click;
            addTeam.btnTeamDone.Click += BtnTeamDone_Click;
        }

        private void BtnTeamDone_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I close");
            buttonAction = ButtonAction.CLOSE;
            ButtonClick();
        }

        private void BtnTeamCreateNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I create a new player");
            buttonAction = ButtonAction.ADD;
            ButtonClick();
        }

        private void BtnTeamClear_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I clear the team stuff");
        }

        private void BtnTeamAddExistingPlayer_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I add existing players");
            buttonAction = ButtonAction.EXISTING;
            ButtonClick();
        }

        private void ButtonClick()
        {
            SetTeamDetails();
            addTeam.Hide();
        }

        private void SetTeamDetails()
        {
            team.SetTName(addTeam.GetTeamName());
            team.SetTContact(addTeam.GetContact());
        }

        public ButtonAction GetButtonAction()
        {
            return buttonAction;
        }

        public Team GetTeam()
        {
            return team;
        }

        public void AddPlayer(Player player)
        {
            team.AddTeamPlayer(player);
        }

        public void SetTeam(Team team)
        {
            this.team = team;
        }
    }
}
