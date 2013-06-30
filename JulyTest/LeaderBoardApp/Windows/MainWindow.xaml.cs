using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Utility;
using LeaderBoardApp.Windows;

namespace LeaderBoardApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ScoreDisplay
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

        #region ScoreDisplay Members

        public void SetTeamAFlag(int p)
        {
            Dispatcher.Invoke(() => liveMatch.lblFlagA.Content = "Flag: " + p);
        }

        public void SetTeamAScore(int p)
        {
            Dispatcher.Invoke(() => liveMatch.lblScoreA.Content = "Score: " + p);
        }

        public void SetTeamATag(int p)
        {
            Dispatcher.Invoke(() => liveMatch.lblTagA.Content = "Tag: " + p);
        }

        public void SetTeamBFlag(int p)
        {
            Dispatcher.Invoke(() => liveMatch.lblFlagB.Content = "Flag: " + p);
        }

        public void SetTeamBScore(int p)
        {
            Dispatcher.Invoke(() => liveMatch.lblScoreB.Content = "Score: " + p);
        }

        public void SetTeamBTag(int p)
        {
            Dispatcher.Invoke(() => liveMatch.lblTagB.Content = "Tag: " + p);
        }

        public void SetTeamA(GameTeam team)
        {
            
        }

        public void SetTeamB(GameTeam team)
        {
            
        }

        public void SetTime(int min, int sec)
        {
            Dispatcher.Invoke(() => liveMatch.TbMinutes.Text = "" + min);
            Dispatcher.Invoke(() => liveMatch.TbSeconds.Text = "" + sec);
        }

        #endregion
    }
}
