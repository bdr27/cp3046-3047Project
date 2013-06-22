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
    public partial class ModalSelectEdit : Window
    {
        public ModalSelectEdit()
        {
            InitializeComponent();
            StylesModal.EditWindow(this);
            StylesModal.EditButton(btnModalEdit);
            BindDictionary();
        }

        public void SetPlayerEdit()
        {
            lblSearch.Content = "Last Name";
            tblSearchAPlayerorTeam.Text = "Search For Player To Edit";
        }

        public void AddTbSearchTextChangedHandler(TextChangedEventHandler handler)
        {
            tbSearch.TextChanged += handler;
        }

        public void AddBtnModalEditHandler(RoutedEventHandler handler)
        {
            btnModalEdit.Click += handler;
        }

        public void ShowPlayers(Dictionary<int, Player> players)
        {
           var orderedPlayers =  players.OrderBy(lastName => lastName.Value.GetLName().ToLower()).ThenBy(firstName => firstName.Value.GetFName().ToLower()).ThenBy(age => age.Value.GetAge());
           cmbNames.ItemsSource = orderedPlayers;            
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
    }
}
