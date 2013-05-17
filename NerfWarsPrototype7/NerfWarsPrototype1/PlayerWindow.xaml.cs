using System;
using System.Windows;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard
{
    /// <summary>
    /// Interaction logic for CreatePlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        public PlayerWindow()
        {
            InitializeComponent();
        }

        public PlayerWindow(string newLabel)
        {
            InitializeComponent();
            lblPlayerWindowTitle.Content = newLabel;
        }

        private void BtnClearPlayer_Click(object sender, RoutedEventArgs e)
        {
            ClearText();
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

        internal string GetFirstName()
        {
            return tbFirstName.Text;
        }

        internal string GetLastName()
        {
            return tbLastName.Text;
        }

        internal int GetAge()
        {
            return Int32.Parse(tbAge.Text);
        }

        internal string GetGuardian()
        {
            return tbGuardian.Text;
        }

        internal string GetContact()
        {
            return tbContact.Text;
        }

        internal string GetMedicalConditions()
        {
            return tbMedical.Text;
        }

        internal void TitleChangeToAdd()
        {
            lblPlayerWindowTitle.Content = "Create Player";
        }

        internal void TitleChangeToEdit()
        {
            lblPlayerWindowTitle.Content = "Edit Player";
        }

        internal void LoadText(Player player)
        {
            tbFirstName.Text = player.GetFirstName();
            tbLastName.Text = player.GetLastName();
            tbAge.Text = player.GetAge() + "";
            tbContact.Text = player.GetContact();
            tbGuardian.Text = player.GetGuardian();
        }
    }
}
