using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard
{
    /// <summary>
    /// Interaction logic for GamePlay.xaml
    /// </summary>
    public partial class TabLiveMatch : UserControl
    {
        public TabLiveMatch()
        {
            InitializeComponent();
        }

        public Team GetTeamA()
        {
            return cmbTeamA.SelectedItem as Team;
        }

        public Team GetTeamB()
        {
            return cmbTeamB.SelectedItem as Team;
        }

        public int GetMin()
        {
            return Int32.Parse(TbMinutes.Text);
        }

        public int GetSec()
        {
            return Int32.Parse(TbSeconds.Text);
        }

        public void LoadTeamSelectComboBox(List<Team> teams)
        {
            foreach (var team in teams)
            {
                cmbTeamA.Items.Add(team);
                cmbTeamB.Items.Add(team);
            }
        }

        public void DisableTeamComboBoxes()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<ComboBox>(DisableComboBox), cmbTeamA);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<ComboBox>(DisableComboBox), cmbTeamB);
        }

        private void DisableComboBox(ComboBox comboBox)
        {
            comboBox.IsEnabled = false;
        }

        public void EnableTeamComboBoxes()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<ComboBox>(EnableComboBox), cmbTeamA);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<ComboBox>(EnableComboBox), cmbTeamB);
        }

        private void EnableComboBox(ComboBox comboBox)
        {
            comboBox.IsEnabled = true;
        }

        public void EnableBtnReset()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Button>(EnableButton), btnReset);
        }

        public void DisableBtnReset()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Button>(DisableButton), btnReset);
        }

        private void DisableButton(Button button)
        {
            button.IsEnabled = false;
        }

        private void EnableButton(Button button)
        {
            button.IsEnabled = true;
        }

        public void ClearTeamComboBox()
        {
            cmbTeamA.Items.Clear();
            cmbTeamB.Items.Clear();
        }
    }
}
