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
using System.Diagnostics;
using LeaderBoardApp.Exceptions;

namespace LeaderBoardApp.Tabs
{
    /// <summary>
    /// Interaction logic for Ladder.xaml
    /// </summary>
    public partial class LadderTab : UserControl
    {
        private Dictionary<int, MatchPlayed> matches;
        private int currentMatch;

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
            lvLadder.Items.Clear();
            lvLadder.SelectedValuePath = "Key";
            lvLadder.DisplayMemberPath = "Value";
            foreach (var match in matches)
            {
                lvLadder.Items.Add(match);
            }
        }

        public void AddLadderGenerateHandler(RoutedEventHandler handler)
        {
            btnGenerateLadder.Click += handler;
        }

        public void AddLadderDoubleClick(MouseButtonEventHandler handler)
        {
            lvLadder.MouseDoubleClick += handler;
        }

        public MatchPlayed GetTeamsSelectedTeam()
        {
            if (lvLadder.SelectedValue != null)
            {
                currentMatch = (int)lvLadder.SelectedValue;
                var game = matches[currentMatch];
                game.SetMatchID(currentMatch);
                if (game != null)
                {
                    return game;
                }
            }
            throw new NoGameSelectedException();
        }

        public void SetResult(Score scoreA, Score scoreB)
        {
            var game = matches[currentMatch];
            game.SetPlayed(true);
            game.SetTeamAScore(scoreA);
            game.SetTeamBScore(scoreB);
            LoadTeamsToList();
        }

        public object GetMatchResult()
        {
            return matches[currentMatch];
        }
    }
}
