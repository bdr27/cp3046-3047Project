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
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.Modals
{
    /// <summary>
    /// Interaction logic for ModalLoadLadder.xaml
    /// </summary>
    public partial class ModalLoadLadder : Window
    {
        private Enum.ButtonAction btn;
        private Dictionary<int, Ladder> currentLadder;

        public ModalLoadLadder()
        {
            InitializeComponent();
            cmbLadder.SelectedValuePath = "Key";
            cmbLadder.DisplayMemberPath = "Value";
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

        public Enum.ButtonAction GetButtonAction()
        {
            return btn;
        }

        public void SetLadders(Dictionary<int, Utility.Ladder> dic)
        {
            this.currentLadder = dic;
            cmbLadder.Items.Clear();
            cmbLadder.ItemsSource = dic;
            cmbLadder.SelectedIndex = 0;
        }

        public int GetLadderID()
        {
            if (cmbLadder.SelectedValue != null)
            {
                var id = (int)cmbLadder.SelectedValue;
                return id;
            }
            return -1;
        }
    }
}
