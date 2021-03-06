﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.Modals
{
    /// <summary>
    /// Interaction logic for ModalPlayer.xaml
    /// </summary>
    public partial class ModalPlayer : Window
    {
        private Player player;

        public ModalPlayer()
        {
            InitializeComponent();
        }

        public void AddBtnDone(RoutedEventHandler handler)
        {
            btnDone.Click += handler;
        }

        public void SetAdd()
        {
            StylesModal.AddWindow(this);
            lblPlayerWindowTitle.Content = "Add Player";
        }

        public void SetEdit()
        {
            StylesModal.EditWindow(this);
            lblPlayerWindowTitle.Content = "Edit Player";
        }

        public Player GetPlayer()
        {
            return player;
        }

        public void DisplayError()
        {
            tbInputError.Visibility = Visibility.Visible;
            if (!CheckRegex.IsValidAge(GetAge()))
            {
                SetTextBoxError(tbAge);
            }
            else
            {
                SetTextBoxCorrect(tbAge);
            }
            if (!CheckRegex.IsValidName(GetFirstName()))
            {
                SetTextBoxError(tbFirstName);
            }
            else
            {
                SetTextBoxCorrect(tbFirstName);
            }
            if(!CheckRegex.IsValidName(GetLastName()))
            {
                SetTextBoxError(tbLastName);
            }
            else
            {
                SetTextBoxCorrect(tbLastName);
            }
            if (!CheckRegex.IsValidContact(GetContact()))
            {
                SetTextBoxError(tbContact);
            }
            else
            {
                SetTextBoxCorrect(tbContact);
            }
        }

        public bool IsValidPlayer()
        {
            if (CheckRegex.IsValidAge(GetAge()))
            {
                int age = Int32.Parse(GetAge());
                player = new Player(GetFirstName(), GetLastName(), age, GetGuardian(), GetContact(), GetMedical());
                if (player.IsValidPlayer())
                {
                    return true;
                }
            }
            return false;
        }

        private void SetTextBoxError(TextBox tb)
        {
            tb.Background = Brushes.Red;
        }

        private void SetTextBoxCorrect(TextBox tb)
        {
            tb.Background = Brushes.White;
        }

        private void ClearText()
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

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private string GetAge()
        {
            return tbAge.Text.Trim();
        }

        private string GetContact()
        {
            return tbContact.Text.Trim();
        }

        private string GetFirstName()
        {
            return tbFirstName.Text.Trim();
        }

        private string GetGuardian()
        {
            return tbGuardian.Text.Trim();
        }

        private string GetLastName()
        {
            return tbLastName.Text.Trim();
        }

        private string GetMedical()
        {
            return tbMedical.Text;
        }

        public void SetPlayerDetails(Player editingPlayer)
        {
            tbAge.Text = editingPlayer.GetAge().ToString();
            tbContact.Text = editingPlayer.GetContact();
            tbFirstName.Text = editingPlayer.GetFName();
            tbGuardian.Text = editingPlayer.GetGuardian();
            tbLastName.Text = editingPlayer.GetLName();
            tbMedical.Text = editingPlayer.GetMedical();
        }
    }
}
