using System.Collections.Generic;
using System.Windows.Controls;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.Tabs
{
    /// <summary>
    /// Interaction logic for TabLiveMatch.xaml
    /// </summary>
    public partial class LiveMatch : UserControl
    {
        public LiveMatch()
        {
            InitializeComponent();
            HelpComboDisplay(cmbTeamA);
            HelpComboDisplay(cmbTeamB);
        }

        private void HelpComboDisplay(ComboBox cmb)
        {
            cmb.SelectedValuePath = "Key";
            cmb.DisplayMemberPath = "Value";
        }

        public void LoadTeamComboBox(Dictionary<int, Team> teams)
        {
            cmbTeamA.ItemsSource = teams;
            cmbTeamB.ItemsSource = teams;
        }
    }
}
