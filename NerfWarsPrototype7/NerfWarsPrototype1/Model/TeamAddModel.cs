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
    //    private ButtonAction buttonAction;
    //    private Team team;

        public TeamAddModel(Window window)
        {
            addTeam = new TeamWindow();
            addTeam.Owner = window;
            WireHandlers();
        }

        public void Show()
        {
            addTeam.ShowDialog();
        }

        private void WireHandlers()
        {
            addTeam.btnTeamAddExistingPlayer.Click += BtnTeamAddExistingPlayer_Click;
            addTeam.btnTeamClear.Click += BtnTeamClear_Click;
            addTeam.btnTeamCreateNewPlayer.Click += BtnTeamCreateNewPlayer_Click;
            addTeam.btnTeamDone.Click += BtnTeamDone_Click;
        }

        void BtnTeamDone_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I close");
            addTeam.Hide();
        }

        void BtnTeamCreateNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I create a new player");
        }

        void BtnTeamClear_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I clear the team stuff");
        }

        void BtnTeamAddExistingPlayer_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I add existing players");
        }

        internal string GetPlayer()
        {
            throw new NotImplementedException();
        }
    }
}
