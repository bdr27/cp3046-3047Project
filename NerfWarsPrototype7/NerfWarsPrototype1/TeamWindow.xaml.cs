﻿using System.Windows;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard
{
    /// <summary>
    /// Interaction logic for TeamWindow.xaml
    /// </summary>
    public partial class TeamWindow : Window
    {
        public TeamWindow()
        {
            InitializeComponent();
        }

        public TeamWindow(string newlabel)
        {
            InitializeComponent();
            lblTeamWindowTitle.Content = newlabel;            
        }

        public void ClearText()
        {
            //Combo Box for team contact
            lblTeamWindowTitle.Content = "Create Team";
            tbCreateTeamContact.Text = "";
            tbCreateTeamName.Text = "";
            dataGridPlayerNames.Items.Clear();
        }

        internal void ShowDetails(Team team)
        {
            dataGridPlayerNames.Items.Clear();
            tbCreateTeamName.Text = team.GetTeamName();
            if (team.GetPlayerFirstName().Count > 0)
            {
                tbCreateTeamContact.Text = team.GetPlayerFirstName()[0];
                foreach (var player in team.GetPlayerFirstName())
                {
                    dataGridPlayerNames.Items.Add(player);
                }
            }
            
        }

        internal string GetTeamName()
        {
            return tbCreateTeamName.Text;
        }
    }
}
