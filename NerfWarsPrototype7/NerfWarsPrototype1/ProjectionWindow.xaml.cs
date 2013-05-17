using NerfWarsLeaderboard.Utility;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NerfWarsLeaderboard
{
    /// <summary>
    /// Interaction logic for Projector.xaml
    /// </summary>
    public partial class ProjectorWindow : Window
    {
        private Game game;
        private Team teamA;
        private Team teamB;
        private List<string> teamAName;
        private List<string> teamBName;
        private int teamACount;
        private int teamBCount;

        public ProjectorWindow()
        {
            InitializeComponent();
        }

        public void UpdateGameDetails(Game game)
        {
            this.game = game;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamAScore), lblTeamAScoreProjector);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamBScore), lblTeamBScoreProjector);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamATag), lblTeamATagCount);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamAFlag), lblTeamAFlagCount);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamBTag), lblTeamBTagCount);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamBFlag), lblTeamBFlagCount);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTimer), lblTimeProjector);
        }

        public void loadTeams(Team teamA, Team teamB)
        {
            this.teamA = teamA;
            this.teamB = teamB;
            teamACount = 0;
            teamBCount = 0;
            teamAName = teamA.getPlayerFirstName();
            teamBName = teamB.getPlayerFirstName();

            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamAName), lblTeamAProjector);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamBName), lblTeamBProjector);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamAplayername), lblTeamAPlayer1);
            teamACount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamAplayername), lblTeamAPlayer2);
            teamACount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamAplayername), lblTeamAPlayer3);
            teamACount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamAplayername), lblTeamAPlayer4);
            teamACount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamAplayername), lblTeamAPlayer5);

            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamBplayername), lblTeamBPlayer1);
            teamBCount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamBplayername), lblTeamBPlayer2);
            teamBCount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamBplayername), lblTeamBPlayer3);
            teamBCount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamBplayername), lblTeamBPlayer4);
            teamBCount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamBplayername), lblTeamBPlayer5);
        }

        private void setTeamBplayername(Label label)
        {
            if (teamBName.Count > teamBCount)
            {
                label.Content = teamBName[teamBCount];
            }
            else
            {
                label.Content = "";
            }
        }

        private void setTeamAplayername(Label label)
        {
            if (teamAName.Count > teamACount)
            {
                label.Content = teamAName[teamACount];
            }
            else
            {
                label.Content = "";
            }
        }

        private void setTeamAName(Label label)
        {
            label.Content = teamA.getTeamName();
        }

        private void setTeamBName(Label label)
        {
            label.Content = teamB.getTeamName();
        }

        private void setTimer(Label label)
        {
            string time = game.getMin() + ":";
            int min = game.getSec();
            if (min < 10)
            {
                time = time + "0" + min;
            }
            else
            {
                time += min;
            }
            label.Content = time;
        }

        private void setTeamBFlag(Label label)
        {
            label.Content = "Flag: " + game.getTeamBFlag();
        }

        private void setTeamBTag(Label label)
        {
            label.Content = "Tag: " + game.getTeamBTag();
        }

        private void setTeamAFlag(Label label)
        {
            label.Content = "Flag: " + game.getTeamAFlag();
        }

        private void setTeamATag(Label label)
        {
            label.Content = "Tag: " + game.getTeamATag();
        }

        private void setTeamBScore(Label label)
        {
            label.Content = "" + game.getTeamBScore();
        }

        private void setTeamAScore(Label label)
        {
            label.Content = "" + game.getTeamAScore();
        }
    }
}
