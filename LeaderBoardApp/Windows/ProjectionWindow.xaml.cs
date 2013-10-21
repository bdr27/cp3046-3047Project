using System.Windows;

namespace LeaderBoardApp.Windows
{
    /// <summary>
    /// Interaction logic for ProjectionWindow.xaml
    /// </summary>
    public partial class ProjectionWindow : Window
    {
        public ProjectionWindow()
        {
            InitializeComponent();
        }

        public void ChangeDisplay(Enum.ProjectorState projectorState)
        {
            ProjectorUpdate.Action(projectorState, projectorLiveMatch, projectorLadder, projectorStandby);
        }

        public void SetStandByMessage(string message)
        {
            projectorStandby.lblStandBy.Text = message;
        }

        public void ResetScoreBoard(int min, int sec)
        {
            projectorLiveMatch.ResetScoreBoard(min, sec);
        }

        public bool IsWindowVisible()
        {
            return this.IsVisible;
        }
    }
}
