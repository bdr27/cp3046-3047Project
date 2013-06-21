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
    /// Interaction logic for ModalPlayer.xaml
    /// </summary>
    public partial class ModalPlayer : Window
    {
        public ModalPlayer()
        {
            InitializeComponent();
        }

        public void AddBtnConfirm(RoutedEventHandler handler)
        {
            btnConfirm.Click += handler;
        }

        public void ClearText()
        {
            tbAge.Text = "";
            tbContact.Text = "";
            tbFirstName.Text = "";
            tbGuardian.Text = "";
            tbLastName.Text = "";
            tbMedical.Text = "";
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearText();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public Player GetPlayer()
        {
            throw new NotImplementedException();
        }
    }
}
