using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.Modals
{
    /// <summary>
    /// Interaction logic for ModalTeam.xaml
    /// </summary>
    public partial class ModalTeam : Window
    {
        public ModalTeam()
        {
            InitializeComponent();
            BindDictionary();
        }

        public void SetAdd()
        {
            StylesModal.AddWindow(this);
            lblTeamWindowTitle.Content = "Add Team";
        }

        public void SetEdit()
        {
            StylesModal.EditWindow(this);
            lblTeamWindowTitle.Content = "Edit Team";
        }

        public void AddBtnAddPlayerHander(RoutedEventHandler handler)
        {
            btnTeamCreateNewPlayer.Click += handler;
        }

        public void AddBtnAddExistingPlayerHandler(RoutedEventHandler handler)
        {
            btnTeamAddExistingPlayer.Click += handler;
        }

        public void AddBtnConfirmHandler(RoutedEventHandler handler)
        {
            btnTeamConfirm.Click += handler;
        }

        public void AddBtnClearHandler(RoutedEventHandler handler)
        {
            btnTeamClear.Click += handler;
        }

        private void btnTeamClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public string GetTeamContact()
        {
            return tbCreateTeamContact.Text;
        }

        public string GetTeamName()
        {
            return tbCreateTeamName.Text;
        }

        public void ShowPlayers(Dictionary<int, Player> teamPlayers)
        {
            var orderedTeamPlayers = LINQQueries.OrderPlayers(teamPlayers);
            lvPlayers.ItemsSource = orderedTeamPlayers;
        }

        private void BindDictionary()
        {
            lvPlayers.SelectedValuePath = "Key";
            lvPlayers.DisplayMemberPath = "Value";
        }

        public void DisplayError()
        {
            CheckTeamName();
            CheckTeamContact();
            DisplayErrorMessage();
        }

        private void CheckTeamName()
        {
            if (CheckRegex.IsValidTeamName(GetTeamName()))
            {
                SetTextBoxValid(tbCreateTeamName);
            }
            else
            {
                SetTextBoxError(tbCreateTeamName);
            }
        }        

        private void CheckTeamContact()
        {
            if (CheckRegex.IsValidContact(GetTeamContact()))
            {
                SetTextBoxValid(tbCreateTeamContact);
            }
            else
            {
                SetTextBoxError(tbCreateTeamContact);
            }
        }

        private void SetTextBoxError(TextBox error)
        {
            error.Background = Brushes.Red;
        }

        private void SetTextBoxValid(TextBox valid)
        {
            valid.Background = Brushes.White;
        }

        private void DisplayErrorMessage()
        {
            tblError.Visibility = Visibility.Visible;
        }

        public void ClearValue()
        {
            SetTextBoxValid(tbCreateTeamContact);
            SetTextBoxValid(tbCreateTeamName);
            tbCreateTeamName.Text = "";
            tbCreateTeamContact.Text = "";
        }
    }
}
