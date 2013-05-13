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

        private void btnClearPlayer_Click(object sender, RoutedEventArgs e)
        {
            clearText();
        }

        public void clearText()
        {
            tbAge.Text = "";
            tbContact.Text = "";
            tbFirstName.Text = "";
            tbGuardian.Text = "";
            tbLastName.Text = "";
            tbMedical.Text = "";
        }

        internal string getFirstName()
        {
            return tbFirstName.Text;
        }

        internal string getLastName()
        {
            return tbLastName.Text;
        }

        internal int getAge()
        {
            return Int32.Parse(tbAge.Text);
        }

        internal string getGuardian()
        {
            return tbGuardian.Text;
        }

        internal string getContact()
        {
            return tbContact.Text;
        }

        internal string getMedicalConditions()
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

        internal void loadText(Player player)
        {
            tbFirstName.Text = player.getFirstName();
            tbLastName.Text = player.getLastName();
            tbAge.Text = player.getAge() + "";
            tbContact.Text = player.getContact();
            tbGuardian.Text = player.getGuardian();
        }
    }
}
