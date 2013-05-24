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

        public void SetEdit()
        {
            BorderBrush = Brushes.LightBlue;
            BorderThickness = new Thickness(2);
            btnModalTeamEdit.Content = "Edit";
            tblSelectATeam.Text = "Edit Team";
        }

        public void SetDelete()
        {
            BorderBrush = Brushes.LightCoral;
            BorderThickness = new Thickness(2);
            btnModalTeamEdit.Content = "Delete";
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
