using NerfWarsLeaderboard.Utility;
using System.Windows;

namespace NerfWarsLeaderboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void updateProjectorGame(Game game)
        {
            ProjectorGame.UpdateGameDetails(game);
        }

        public void updateProjectorTeam(Team teamA, Team teamB)
        {
            ProjectorGame.LoadTeams(teamA, teamB);
        }
    }
}
