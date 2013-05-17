using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard
{
    /// <summary>
    /// Interaction logic for EditDeletePlayerModal.xaml
    /// </summary>
    public partial class ModalPlayerEditDelete : Window
    {
        public ModalPlayerEditDelete()
        {
            InitializeComponent();
        }

        public ModalPlayerEditDelete(string newTextblock, string newButtonContent)
        {
            InitializeComponent();
            tblSearchAPlayer.Text = newTextblock;
            btnPlayerModalEdit.Content = newButtonContent;
            btnPlayerModalEdit.Background = Brushes.LightCoral;
        }
        public void SetEdit()
        {
            tblSearchAPlayer.Text = "Search for a player to edit";
            btnPlayerModalEdit.Content = "Edit";
        }

        public void SetDelete()
        {
            tblSearchAPlayer.Text = "Search for a player to delete";
            btnPlayerModalEdit.Content = "Delete";
        }

        public void FillComboBox(List<Player> players)
        {
            cmbPlayerNames.Items.Clear();
            foreach (var player in players)
            {
                //Add if not in the list
                if (!cmbPlayerNames.Items.Contains(player))
                {
                    cmbPlayerNames.Items.Add(player);
                }
            }
        }

        internal Player GetPlayer()
        {
            return cmbPlayerNames.SelectedItem as Player;
        }
    }
}
