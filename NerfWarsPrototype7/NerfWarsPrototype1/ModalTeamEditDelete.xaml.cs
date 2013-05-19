using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using NerfWarsLeaderboard.Utility;

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

        public void UpdateCombo(List<Team> teams)
        {
            cmbTeamName.Items.Clear();
            foreach (var team in teams)
            {
                cmbTeamName.Items.Add(team);
            }
        }

        public Team GetTeam()
        {
            return cmbTeamName.SelectedItem as Team;
        }
    }
}
