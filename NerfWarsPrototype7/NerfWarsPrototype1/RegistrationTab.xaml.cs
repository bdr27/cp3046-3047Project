using System.Windows;
using System.Windows.Controls;

namespace NerfWarsLeaderboard
{
    /// <summary>
    /// Interaction logic for RegistrationMenu.xaml
    /// </summary>
    public partial class RegistrationTab : UserControl
    {
        const string DELETE = "Delete";

        public RegistrationTab()
        {
            InitializeComponent();
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            PlayerWindow dialogue = new PlayerWindow();
            dialogue.Show();
        }

        private void btnAddTeam_Click(object sender, RoutedEventArgs e)
        {
            TeamWindow dialogue = new TeamWindow();
            dialogue.Show();
        }

        private void btnEditTeam_Click(object sender, RoutedEventArgs e)
        {
            ModalTeamEditDelete dialogue = new ModalTeamEditDelete();
            dialogue.Show();
        }

        private void btnEditPlayer_Click(object sender, RoutedEventArgs e)
        {
            ModalPlayerEditDelete dialogue = new ModalPlayerEditDelete();
            dialogue.Show();
        }

        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            ModalPlayerEditDelete dialogue = new ModalPlayerEditDelete("Search for a player to delete", DELETE);
            dialogue.Show();
        }

        private void btnDeleteTeam_Click(object sender, RoutedEventArgs e)
        {
            ModalTeamEditDelete dialogue = new ModalTeamEditDelete("Select a team to delete", DELETE);
            dialogue.Show();
        }
    }
}
