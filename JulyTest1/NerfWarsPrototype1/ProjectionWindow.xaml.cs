using NerfWarsLeaderboard.Utility;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NerfWarsLeaderboard
{
    /// <summary>
    /// Interaction logic for Projector.xaml
    /// </summary>
    public partial class ProjectorWindow : Window
    {

        public ProjectorWindow()
        {
            InitializeComponent();
        }

        public void UpdateGameDetails(Game game)
        {
            this.ProjectorGame.UpdateGameDetails(game);
        }

        public void LoadTeams(Team teamA, Team teamB)
        {
            this.ProjectorGame.LoadTeams(teamA, teamB);
        }
    }
}
