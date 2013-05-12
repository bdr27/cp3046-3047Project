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

namespace NerfWarsPrototype1
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
