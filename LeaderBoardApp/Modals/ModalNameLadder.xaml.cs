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

namespace LeaderBoardApp.Modals
{
    /// <summary>
    /// Interaction logic for ModalNameLadder.xaml
    /// </summary>
    public partial class ModalNameLadder : Window
    {
        Enum.ButtonAction btn;

        public ModalNameLadder()
        {
            InitializeComponent();
        }

        public Enum.ButtonAction GetButtonAction()
        {
            return btn;
        }

        private void BtnDone_Click(object sender, RoutedEventArgs e)
        {
            btn = Enum.ButtonAction.DONE;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            btn = Enum.ButtonAction.NONE;
            Close();
        }

        public string GetName()
        {
            return tbLadderName.Text;
        }
    }
}
