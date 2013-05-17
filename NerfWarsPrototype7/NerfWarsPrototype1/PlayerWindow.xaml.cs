using System;
using System.Windows;
using NerfWarsLeaderboard.Utility;
using System.Text.RegularExpressions;

namespace NerfWarsLeaderboard
{
    /// <summary>
    /// Interaction logic for CreatePlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        private Player player;
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

        public void SetEdit()
        {
            lblPlayerWindowTitle.Content = "Edit Player";
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

        public void TitleChangeToAdd()
        {
            lblPlayerWindowTitle.Content = "Create Player";
        }

        public void TitleChangeToEdit()
        {
            lblPlayerWindowTitle.Content = "Edit Player";
        }

        public void LoadText(Player player)
        {
            tbFirstName.Text = player.GetFirstName();
            tbLastName.Text = player.GetLastName();
            tbAge.Text = player.GetAge() + "";
            tbContact.Text = player.GetContact();
            tbGuardian.Text = player.GetGuardian();
        }

        public bool ValidFields()
        {
            if (ValidName(tbFirstName.Text) && ValidName(tbLastName.Text) && ValidAge(tbAge.Text) && ValidPhone(tbContact.Text))
            {
                player = new Player(GetFirstName(), GetSecondName(), GetAge(), GetGuardian(), GetContact(), GetMedical());
                return true;
            }
            return false;
        }

        private string GetMedical()
        {
            return tbMedical.Text;
        }

        private string GetContact()
        {
            return tbContact.Text;
        }

        private string GetGuardian()
        {
            return tbGuardian.Text;
        }

        private int GetAge()
        {
            return Int32.Parse(tbAge.Text);
        }

        private string GetSecondName()
        {
            return tbLastName.Text;
        }

        private string GetFirstName()
        {
            return tbFirstName.Text;
        }

        public Player GetPlayer()
        {
            return player;
        }

        private bool ValidPhone(string phone)
        {
            if (Regex.Match(phone, @"^[0-9]{1,15}$").Success)
            {
                return true;
            }
            return false;
        }

        private bool ValidAge(string age)
        {
            if (Regex.Match(age, @"^([0-9]|[1-9][0-9])$").Success)
            {
                return true;
            }
            return false;
        }

        private bool ValidName(string name)
        {
            if (Regex.Match(name, @"^[a-zA-Z]{1,100}$").Success)
            {
                return true;
            }
            return false;
        }
    }
}
