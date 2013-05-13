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
            tbCreateTeamContact.Text = "";
            tbCreateTeamName.Text = "";
            dataGridPlayerNames.Items.Clear();
        }

        internal void ShowDetails(Team team)
        {
            dataGridPlayerNames.Items.Clear();
            tbCreateTeamName.Text = team.getTeamName();
            if (team.getPlayerFirstName().Count > 0)
            {
                tbCreateTeamContact.Text = team.getPlayerFirstName()[0];
                foreach (var player in team.getPlayerFirstName())
                {
                    dataGridPlayerNames.Items.Add(player);
                }
            }
            
        }

        internal string getTeamName()
        {
            return tbCreateTeamName.Text;
        }
    }
}
