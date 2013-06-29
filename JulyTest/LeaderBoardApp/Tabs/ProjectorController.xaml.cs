using System.Windows;
using System.Windows.Controls;

namespace LeaderBoardApp.Tabs
{
    /// <summary>
    /// Interaction logic for ProjectorController.xaml
    /// </summary>
    public partial class ProjectorController : UserControl
    {
        public ProjectorController()
        {
            InitializeComponent();
        }

        public void AddBtnLiveMatchHandler(RoutedEventHandler handler)
        {
            btnLiveMatch.Click += handler;
        }

        public void AddBtnLadderHandler(RoutedEventHandler handler)
        {
            btnLadder.Click += handler;
        }

        public void AddBtnStandByHandler(RoutedEventHandler handler)
        {
            btnStandby.Click += handler;
        }
    }
}
