using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Windows;

namespace LeaderBoardApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddTabControl(SelectionChangedEventHandler handler)
        {
            MainWindowTabControl.SelectionChanged += handler;
        }

        public void AddSideMenuControlLiveMatch(RoutedEventHandler handler)
        {
            projectorController.AddBtnLiveMatchHandler(handler);
        }

        public void AddSideMenuControlLadder(RoutedEventHandler handler)
        {
            projectorController.AddBtnLadderHandler(handler);
        }

        public void AddSideMenuControlStandBy(RoutedEventHandler handler)
        {
            projectorController.AddBtnStandByHandler(handler);
        }

        public SelectedTab GetSelectedTab()
        {
            var selectedTab = (SelectedTab) MainWindowTabControl.SelectedIndex;
            Debug.WriteLine(selectedTab);
            return selectedTab;
        }

        public void ChangeDisplay(ProjectorState projectorState)
        {
            ProjectorUpdate.Action(projectorState, projectorLiveMatch, projectorLadder, projectorStandby);
        }
    }
}
