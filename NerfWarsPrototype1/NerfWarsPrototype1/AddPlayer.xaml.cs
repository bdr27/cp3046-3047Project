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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NerfWarsPrototype1
{
    /// <summary>
    /// Interaction logic for AddPlayer.xaml
    /// </summary>
    public partial class AddPlayer : UserControl
    {
        public int pageBefore;

        public AddPlayer()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.tBAge.Text = "";
            this.tBContact.Text = "";
            this.tBFirstName.Text = "";
            this.tBSurename.Text = "";
        }
    }
}
