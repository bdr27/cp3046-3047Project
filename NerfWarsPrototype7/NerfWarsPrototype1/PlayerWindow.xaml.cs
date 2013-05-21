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
            tbFirstName.Text = player.GetFName();
            tbLastName.Text = player.GetLName();
            tbAge.Text = player.GetAge() + "";
            tbContact.Text = player.GetContact();
            tbGuardian.Text = player.GetGuardian();
            tbMedical.Text = player.GetMedical();
        }

        public bool ValidFields()
        {
            if (ValidName(tbFirstName.Text) && ValidName(tbLastName.Text) && ValidAge(tbAge.Text) && ValidPhone(tbContact.Text))
            {
                return true;
            }
            return false;
        }

        public void GenerateNewPlayer()
        {
            player = new Player(GetFirstName(), GetSecondName(), GetAge(), GetGuardian(), GetContact(), GetMedical());
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public void UpdatePlayer()
        {
            player.SetAge(Int32.Parse(tbAge.Text));
            player.SetContact(tbContact.Text);
            player.SetFName(tbFirstName.Text);
            player.SetGuardian(tbGuardian.Text);
            player.SetLName(tbLastName.Text);
            player.SetMedical(tbMedical.Text);
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
