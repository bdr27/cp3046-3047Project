using System.Windows;
using NerfWarsLeaderboard.Utility;
using System.Windows.Media;

namespace NerfWarsLeaderboard
{
    /// <summary>
    /// Interaction logic for TeamWindow.xaml
    /// </summary>
    public partial class ModalTeam : Window
    {
        public ModalTeam()
        {
            InitializeComponent();
        }

        public ModalTeam(string newlabel)
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
            //dataGridPlayerNames.Items.Clear();
        }

        public void ShowDetails(Team team)
        {
            foreach(string player in team.GetPlayerFirstName())
            {
                lvPlayers.Items.Add(player);
            }
            //dataGridPlayerNames.Items.Clear();
           /* lvPlayers.Text = team.GetTeamName();
            if (team.GetPlayerFirstName().Count > 0)
            {
                tbCreateTeamContact.Text = team.GetPlayerFirstName()[0];
                foreach (var player in team.GetPlayerFirstName())
                {
                    //dataGridPlayerNames.Items.Add(player);
                }
            }*/
            
        }

        public string GetTeamName()
        {
            return tbCreateTeamName.Text;
        }

        public string GetContact()
        {
            return tbCreateTeamContact.Text;
        }

        public void SetAdd()
        {
            this.BorderBrush = Brushes.LightGreen;
            this.BorderThickness = new Thickness(2);
            lblTeamWindowTitle.Content = "Add Team";
        }

        public void SetEdit()
        {
            this.BorderBrush = Brushes.LightBlue;
            this.BorderThickness = new Thickness(2);
            lblTeamWindowTitle.Content = "Edit Team";
        }
    }
}
