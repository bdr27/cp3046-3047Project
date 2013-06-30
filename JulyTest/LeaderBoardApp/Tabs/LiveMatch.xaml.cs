using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.Tabs
{
    /// <summary>
    /// Interaction logic for TabLiveMatch.xaml
    /// </summary>
    public partial class LiveMatch : UserControl
    {
        IOrderedEnumerable<KeyValuePair<int, Team>> orderedTeams;
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
            orderedTeams = LINQQueries.OrderTeams(teams);
            cmbTeamA.ItemsSource = orderedTeams;
            cmbTeamB.ItemsSource = orderedTeams;
            cmbTeamA.SelectedIndex = 0;
            cmbTeamB.SelectedIndex = 0;
        }

        public void AddTeamAFlagPlusHandler(RoutedEventHandler handler)
        {
            btnFlagPlusA.Click += handler;
        }

        public void AddTeamAFlagMinusHandler(RoutedEventHandler handler)
        {
            btnFlagMinusA.Click += handler;
        }

        public void AddTeamATagPlusHandler(RoutedEventHandler handler)
        {
            btnTagPlusA.Click += handler;
        }

        public void AddTeamATagMinusHandler(RoutedEventHandler handler)
        {
            btnTagMinusA.Click += handler;
        }

        public void AddTeamBFlagPlusHandler(RoutedEventHandler handler)
        {
            btnFlagPlusB.Click += handler;
        }

        public void AddTeamBFlagMinusHandler(RoutedEventHandler handler)
        {
            btnFlagMinusB.Click += handler;
        }

        public void AddTeamBTagPlusHandler(RoutedEventHandler handler)
        {
            btnTagPlusB.Click += handler;
        }

        public void AddTeamBTagMinusHandler(RoutedEventHandler handler)
        {
            btnTagMinusB.Click += handler;
        }

        public void AddStartPauseHandler(RoutedEventHandler handler)
        {
            btnStartPause.Click += handler;
        }

        public void AddResetHandler(RoutedEventHandler handler)
        {
            btnReset.Click += handler;
        }

        public void AddEndGameHandler(RoutedEventHandler handler)
        {
            btnEndMatch.Click += handler;
        }

        public void MatchInProgress()
        {
            ButtonEnable(btnEndMatch);
            ButtonEnable(btnFlagMinusA);
            ButtonEnable(btnFlagMinusB);
            ButtonEnable(btnFlagPlusA);
            ButtonEnable(btnFlagPlusB);
            ButtonEnable(btnReset);
            ButtonEnable(btnTagMinusA);
            ButtonEnable(btnTagMinusB);
            ButtonEnable(btnTagPlusA);
            ButtonEnable(btnTagPlusB);
            ComboBoxDisable(cmbTeamA);
            ComboBoxDisable(cmbTeamB);
        }

        private void ButtonEnable(Button button)
        {
            button.IsEnabled = true;
        }

        private void ComboBoxDisable(ComboBox comboBox)
        {
            comboBox.IsEnabled = false;
        }

        public void NoMatchInProgress()
        {
            ButtonDisable(btnEndMatch);
            ButtonDisable(btnFlagMinusA);
            ButtonDisable(btnFlagMinusB);
            ButtonDisable(btnFlagPlusA);
            ButtonDisable(btnFlagPlusB);
            ButtonDisable(btnReset);
            ButtonDisable(btnTagMinusA);
            ButtonDisable(btnTagMinusB);
            ButtonDisable(btnTagPlusA);
            ButtonDisable(btnTagPlusB);
            ComboBoxEnable(cmbTeamA);
            ComboBoxEnable(cmbTeamB);
        }

        private void ButtonDisable(Button button)
        {
            button.IsEnabled = false;
        }

        private void ComboBoxEnable(ComboBox comboBox)
        {
            comboBox.IsEnabled = true;
        }

        public int GetTeamA()
        {
            var team = (int) cmbTeamA.SelectedValue;
            return team;
          //  return team.GetTeamID();
        }

        public int GetTeamB()
        {
            var team = (int)cmbTeamB.SelectedValue;
            return team;
        }
    }
}
