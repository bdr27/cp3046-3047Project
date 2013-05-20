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
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamAScore), lblTeamAScoreProjector);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamBScore), lblTeamBScoreProjector);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamATag), lblTeamATagCount);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamAFlag), lblTeamAFlagCount);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamBTag), lblTeamBTagCount);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamBFlag), lblTeamBFlagCount);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTimer), lblTimeProjector);
        }

        public void LoadTeams(Team teamA, Team teamB)
        {
            this.teamA = teamA;
            this.teamB = teamB;
            teamACount = 0;
            teamBCount = 0;
            teamAName = teamA.GetPlayerFName();
            teamBName = teamB.GetPlayerFName();

            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamAName), lblTeamAProjector);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamBName), lblTeamBProjector);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamAplayername), lblTeamAPlayer1);
            teamACount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamAplayername), lblTeamAPlayer2);
            teamACount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamAplayername), lblTeamAPlayer3);
            teamACount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamAplayername), lblTeamAPlayer4);
            teamACount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamAplayername), lblTeamAPlayer5);

            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamBplayername), lblTeamBPlayer1);
            teamBCount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamBplayername), lblTeamBPlayer2);
            teamBCount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamBplayername), lblTeamBPlayer3);
            teamBCount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamBplayername), lblTeamBPlayer4);
            teamBCount++;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamBplayername), lblTeamBPlayer5);
        }

        private void SetTeamBplayername(Label label)
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

        private void SetTeamAplayername(Label label)
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

        private void SetTeamAName(Label label)
        {
            label.Content = teamA.GetTName();
        }

        private void SetTeamBName(Label label)
        {
            label.Content = teamB.GetTName();
        }

        private void SetTimer(Label label)
        {
            string time = game.GetMin() + ":";
            int min = game.GetSec();
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

        private void SetTeamBFlag(Label label)
        {
            label.Content = "Flag: " + game.GetTeamBFlag();
        }

        private void SetTeamBTag(Label label)
        {
            label.Content = "Tag: " + game.GetTeamBTag();
        }

        private void SetTeamAFlag(Label label)
        {
            label.Content = "Flag: " + game.GetTeamAFlag();
        }

        private void SetTeamATag(Label label)
        {
            label.Content = "Tag: " + game.GetTeamATag();
        }

        private void SetTeamBScore(Label label)
        {
            label.Content = "" + game.GetTeamBScore();
        }

        private void SetTeamAScore(Label label)
        {
            label.Content = "" + game.GetTeamAScore();
        }
    }
}
