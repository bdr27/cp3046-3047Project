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
    public partial class LiveMatchTab : UserControl
    {
        public LiveMatchTab()
        {
            InitializeComponent();
        }

        public Team getTeamA()
        {
            return cmbTeamA.SelectedItem as Team;
        }

        public Team getTeamB()
        {
            return cmbTeamB.SelectedItem as Team;
        }

        public int getMin()
        {
            return Int32.Parse(TbMinutes.Text);
        }

        public int getSec()
        {
            return Int32.Parse(TbSeconds.Text);
        }

        public void loadTeamSelectComboBox(List<Team> teams)
        {
            foreach (var team in teams)
            {
                cmbTeamA.Items.Add(team);
                cmbTeamB.Items.Add(team);
            }
        }

        public void disableTeamComboBoxes()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<ComboBox>(disableComboBox), cmbTeamA);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<ComboBox>(disableComboBox), cmbTeamB);
        }

        private void disableComboBox(ComboBox comboBox)
        {
            comboBox.IsEnabled = false;
        }

        public void enableTeamComboBoxes()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<ComboBox>(enableComboBox), cmbTeamA);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<ComboBox>(enableComboBox), cmbTeamB);
        }

        private void enableComboBox(ComboBox comboBox)
        {
            comboBox.IsEnabled = true;
        }

        public void enableBtnReset()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Button>(enableButton), btnReset);
        }

        public void disableBtnReset()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Button>(disableButton), btnReset);
        }

        private void disableButton(Button button)
        {
            button.IsEnabled = false;
        }

        private void enableButton(Button button)
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
