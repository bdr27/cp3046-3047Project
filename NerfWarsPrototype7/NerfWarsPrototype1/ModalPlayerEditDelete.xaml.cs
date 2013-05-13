using System.Windows;
using System.Windows.Media;

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

        private void btnPlayerModalEdit_Click(object sender, RoutedEventArgs e)
        {
            if (btnPlayerModalEdit.Content.ToString() == "Edit")
            {
                PlayerWindow dialogue = new PlayerWindow("Edit Player");
                Close();
                dialogue.Show();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("DEBUG - stub for deleting a player");
            }
            
        }

    }
}
