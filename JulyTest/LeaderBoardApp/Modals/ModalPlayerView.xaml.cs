using LeaderBoardApp.Utility;
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

namespace LeaderBoardApp.Modals
{
    /// <summary>
    /// Interaction logic for ModalPlayerView.xaml
    /// </summary>
    public partial class ModalPlayerView : Window
    {
        public ModalPlayerView()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void SetPlayerDetails(Player player)
        {
            lblAge.Content = player.GetAge();
            lblContact.Content = player.GetContact();
            lblFirstName.Content = player.GetFName();
            lblGuardian.Content = player.GetGuardian();
            lblLastName.Content = player.GetLName();
            txtBlMedical.Text = player.GetMedical();
        }

        public void AddBtnEditHandler(RoutedEventHandler handler)
        {
            btnEdit.Click += handler;
        }
    }
}
