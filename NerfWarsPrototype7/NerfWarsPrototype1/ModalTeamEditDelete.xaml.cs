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
    /// Interaction logic for EditTeamModal.xaml
    /// </summary>
    public partial class ModalTeamEditDelete : Window
    {
        public ModalTeamEditDelete()
        {
            InitializeComponent();

        }

        public ModalTeamEditDelete(string newTextBlock, string newButtonContent)
        {
            InitializeComponent();
            tblSelectATeam.Text = newTextBlock;
            btnModalTeamEdit.Content = newButtonContent;
            btnModalTeamEdit.Background = Brushes.LightCoral;
        }

        private void btnModalTeamEdit_Click(object sender, RoutedEventArgs e)
        {
            if (btnModalTeamEdit.Content.ToString() == "Edit")
            {
                TeamWindow dialogue = new TeamWindow("Edit Team");
                Close();
                dialogue.Show();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("DEBUG - stub for delete");
            }
        }
    }
}
