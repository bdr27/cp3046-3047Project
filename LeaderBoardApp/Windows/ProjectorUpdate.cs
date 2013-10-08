using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using LeaderBoardApp.Enum;

namespace LeaderBoardApp.Windows
{
    public static class ProjectorUpdate
    {
        public static void Action(ProjectorState state, UserControl liveMatch, UserControl ladder, UserControl standBy)
        {
            liveMatch.Visibility = Visibility.Hidden;
            ladder.Visibility = Visibility.Hidden;
            standBy.Visibility = Visibility.Hidden;

            switch (state)
            {
                case ProjectorState.LADDER:
                    ladder.Visibility = Visibility.Visible;
                    break;
                case ProjectorState.LIVE_MATCH:
                    liveMatch.Visibility = Visibility.Visible;
                    break;
                case ProjectorState.STAND_BY:
                    standBy.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
