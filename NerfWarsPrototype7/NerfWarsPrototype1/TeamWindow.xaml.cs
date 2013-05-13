using System.Windows;

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
    }
}
