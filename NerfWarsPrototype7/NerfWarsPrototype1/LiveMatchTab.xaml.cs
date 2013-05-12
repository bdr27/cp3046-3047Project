using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Utility;

namespace NerfWarsPrototype1
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
    }
}
