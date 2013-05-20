using System.Windows;
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

        public void ShowDetails(Team team)
        {
            dataGridPlayerNames.Items.Clear();
            tbCreateTeamName.Text = team.GetTName();
            if (team.GetPlayerFName().Count > 0)
            {
                tbCreateTeamContact.Text = team.GetPlayerFName()[0];
                foreach (var player in team.GetPlayerFName())
                {
                    dataGridPlayerNames.Items.Add(player);
                }
            }
            
        }

        public string GetTeamName()
        {
            return tbCreateTeamName.Text;
        }

        public string GetContact()
        {
            return tbCreateTeamContact.Text;
        }
    }
}
