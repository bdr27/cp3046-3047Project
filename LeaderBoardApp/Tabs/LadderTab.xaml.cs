using LeaderBoardApp.Utility;
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

namespace LeaderBoardApp.Tabs
{
    /// <summary>
    /// Interaction logic for Ladder.xaml
    /// </summary>
    public partial class LadderTab : UserControl
    {
        private Dictionary<int, MatchPlayed> matches;

        public LadderTab()
        {
            InitializeComponent();
        }
        public void SetMatches(Dictionary<int, MatchPlayed> matches)
        {
            this.matches = matches;
            LoadTeamsToList();
        }

        private void LoadTeamsToList()
        {
            lvLadder.SelectedValuePath = "Key";
            lvLadder.DisplayMemberPath = "Value";
            lvLadder.ItemsSource = matches;
        }

        public void AddLadderGenerateHandler(RoutedEventHandler handler)
        {
            btnGenerateLadder.Click += handler;
        }
    }
}
