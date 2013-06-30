using System.Collections.Generic;
using System.Windows.Controls;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ProjectorDisplay
{
    /// <summary>
    /// Interaction logic for ProjectorDisplay.xaml
    /// </summary>
    public partial class ProjectorGame : UserControl, ScoreDisplay
    {
        public ProjectorGame()
        {
            InitializeComponent();
        }

        public void SetTeamA(GameTeam teamA)
        {
            lblTeamAName.Content = teamA.teamName;
            var playerNameLabels = new List<Label>();
            playerNameLabels.Add(lblTeamAPlayer1);
            playerNameLabels.Add(lblTeamAPlayer2);
            playerNameLabels.Add(lblTeamAPlayer3);
            playerNameLabels.Add(lblTeamAPlayer4);
            playerNameLabels.Add(lblTeamAPlayer5);
            SetPlayerNames(playerNameLabels, teamA.teamPlayers);
        }

        public void SetTeamB(GameTeam teamB)
        {
            lblTeamBName.Content = teamB.teamName;
            var playerNameLabels = new List<Label>();
            playerNameLabels.Add(lblTeamBPlayer1);
            playerNameLabels.Add(lblTeamBPlayer2);
            playerNameLabels.Add(lblTeamBPlayer3);
            playerNameLabels.Add(lblTeamBPlayer4);
            playerNameLabels.Add(lblTeamBPlayer5);
            SetPlayerNames(playerNameLabels, teamB.teamPlayers);
        }

        private void SetPlayerNames(List<Label> playerNameLabels, List<string> playerNames)
        {
            for (int i = 0; i < playerNameLabels.Count; i++)
            {
                if (i < playerNames.Count)
                {
                    playerNameLabels[i].Content = playerNames[i];
                }
                else
                {
                    playerNameLabels[i].Content = "";
                }
            }
        }

        public void SetTeamAFlag(int p)
        {
            Dispatcher.Invoke(() => lblTeamAFlagCount.Content = "Flag: " + p);
        }

        public void SetTeamAScore(int p)
        {
            Dispatcher.Invoke(() => lblTeamAScoreProjector.Content = "" + p);
        }

        public void SetTeamATag(int p)
        {
            Dispatcher.Invoke(() => lblTeamATagCount.Content = "Tag: " + p);
        }

        public void SetTeamBFlag(int p)
        {
            Dispatcher.Invoke(() => lblTeamBFlagCount.Content = "Flag: " + p);
        }

        public void SetTeamBScore(int p)
        {
            Dispatcher.Invoke(() => lblTeamBScoreProjector.Content = "" + p);
        }

        public void SetTeamBTag(int p)
        {
            Dispatcher.Invoke(() => lblTeamBTagCount.Content = "Tag: " + p);
        }

        public void SetTime(int min, int sec)
        {
            var strSec = "" + sec;
            if (sec < 10)
            {
                strSec = "0" + strSec;
            }
            Dispatcher.Invoke(() => lblTimeProjector.Content = min + ":" + strSec);
        }
    }
}
