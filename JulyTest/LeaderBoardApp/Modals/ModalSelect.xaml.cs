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
using System.Windows.Shapes;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.Modals
{
    /// <summary>
    /// Interaction logic for ModalSelectEdit.xaml
    /// </summary>
    public partial class ModalSelect : Window
    {
        public ModalSelect()
        {
            InitializeComponent();   
            BindDictionary();
        }

        public void SetPlayerEdit()
        {
            lblSearch.Content = "Last Name";
            tblSearchAPlayerorTeam.Text = "Search For Player To Edit";
            StylesModal.EditWindow(this);
            StylesModal.EditButton(btnModalEditDelete);
        }

        public void SetPlayerDelete()
        {
            lblSearch.Content = "Last Name";
            tblSearchAPlayerorTeam.Text = "Search For Player To Delete";
            StylesModal.DeleteWindow(this);
            StylesModal.DeleteButton(btnModalEditDelete);
        }

        public void SetTeamEdit()
        {
            lblSearch.Content = "Team Name";
            tblSearchAPlayerorTeam.Text = "Search For Team To Edit";
            StylesModal.EditWindow(this);
            StylesModal.EditButton(btnModalEditDelete);
        }


        public void SetTeamDelete()
        {
            lblSearch.Content = "Team Name";
            tblSearchAPlayerorTeam.Text = "Search For Team To Delete";
            StylesModal.DeleteWindow(this);
            StylesModal.DeleteButton(btnModalEditDelete);
        }

        public void SetAddPlayer()
        {
            lblSearch.Content = "Last Name";
            tblSearchAPlayerorTeam.Text = "Search For Player To Add";
            StylesModal.AddWindow(this);
            StylesModal.AddButton(btnModalEditDelete);
        }

        public void AddTbSearchTextChangedHandler(TextChangedEventHandler handler)
        {
            tbSearch.TextChanged += handler;
        }

        public void AddBtnModalEditHandler(RoutedEventHandler handler)
        {
            btnModalEditDelete.Click += handler;
        }

        public void AddCmbNamesHandler(SelectionChangedEventHandler handler)
        {
            cmbNames.SelectionChanged += handler;
        }

        public void DisplayPlayers(Dictionary<int, Player> players)
        {
            var orderedPlayers = LINQQueries.OrderPlayers(players);//players.OrderBy(lastName => lastName.Value.GetLName().ToLower()).ThenBy(firstName => firstName.Value.GetFName().ToLower()).ThenBy(age => age.Value.GetAge());
            cmbNames.ItemsSource = orderedPlayers;
            cmbNames.SelectedIndex = 0;
        }

        public void DisplayTeams(Dictionary<int, Team> teams)
        {
            var orderedTeams = LINQQueries.OrderTeams(teams);
            cmbNames.ItemsSource = orderedTeams;
            cmbNames.SelectedIndex = 0;
        }

        public object GetSelectedPlayer()
        {
            return cmbNames.SelectedValue;
        }

        public string GetSearch()
        {
            return tbSearch.Text.Trim().ToLower();
        }

        private void BindDictionary()
        {
            cmbNames.SelectedValuePath = "Key";
            cmbNames.DisplayMemberPath = "Value";
        }

        private void btnPlayerModalDone_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void ShowBox()
        {
            //TODO show dropdown
        }


        public int GetSelectedItem()
        {
            throw new NotImplementedException();
        }
    }
}
