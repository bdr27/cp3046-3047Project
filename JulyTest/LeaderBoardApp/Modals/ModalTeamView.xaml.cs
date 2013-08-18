using LeaderBoardApp.Utility;
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

namespace LeaderBoardApp.Modals
{
    /// <summary>
    /// Interaction logic for ModalTeamView.xaml
    /// </summary>
    public partial class ModalTeamView : Window
    {
        public ModalTeamView()
        {
            InitializeComponent();
            BindDictionary();
        }

        public void SetTeam(Team team)
        {
            lblTeamContact.Content = team.GetTeamContact();
            lblTeamName.Content = team.GetTeamName();
        }

        public void ShowPlayers(Dictionary<int, Player> teamPlayers)
        {
            var orderedTeamPlayers = LINQQueries.OrderPlayers(teamPlayers);
            lvPlayers.ItemsSource = orderedTeamPlayers;
        }

        public void AddBtnViewHandler(RoutedEventHandler handler)
        {
            btnTeamEdit.Click += handler;
        }

        private void BindDictionary()
        {
            lvPlayers.SelectedValuePath = "Key";
            lvPlayers.DisplayMemberPath = "Value";
        }

        private void btnTeamDone_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
