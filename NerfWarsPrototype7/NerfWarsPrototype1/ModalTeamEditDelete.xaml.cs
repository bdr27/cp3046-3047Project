using System.Windows;
using System.Windows.Media;

namespace NerfWarsLeaderboard
{
    /// <summary>
    /// Interaction logic for EditTeamModal.xaml
    /// </summary>
    public partial class ModalTeamEditDelete : Window
    {
        public ModalTeamEditDelete()
        {
            InitializeComponent();

        }

        public ModalTeamEditDelete(string newTextBlock, string newButtonContent)
        {
            InitializeComponent();
            tblSelectATeam.Text = newTextBlock;
            btnModalTeamEdit.Content = newButtonContent;
            btnModalTeamEdit.Background = Brushes.LightCoral;
        }

        private void btnModalTeamEdit_Click(object sender, RoutedEventArgs e)
        {
            if (btnModalTeamEdit.Content.ToString() == "Edit")
            {
                TeamWindow dialogue = new TeamWindow("Edit Team");
                Close();
                dialogue.Show();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("DEBUG - stub for delete");
            }
        }
    }
}
