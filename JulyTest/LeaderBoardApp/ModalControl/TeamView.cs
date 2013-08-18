using LeaderBoardApp.Enum;
using LeaderBoardApp.Modals;
using LeaderBoardApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LeaderBoardApp.ModalControl
{
    class TeamView : ModalInterface
    {
        private FileHandler fileHandler;
        private ModalTeamView teamView;
        private int teamID;
        private Team team;
        private Dictionary<int, Player> players;
        

        public TeamView(FileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
            teamView = new ModalTeamView();
            WireHandlers();
        }

        public void SetTeamDetail(int teamID)
        {
            this.teamID = teamID;
            team = fileHandler.GetTeam(teamID);
            teamView.SetTeam(team);
            var playerIDs = team.GetPlayerIDs();
            players = new Dictionary<int, Player>();
            foreach(var ID in playerIDs)
            {
                players.Add(ID, fileHandler.GetPlayer(ID));
            }
            teamView.ShowPlayers(players);
        }

        private void WireHandlers()
        {
            teamView.AddBtnViewHandler(HandleBtnView_Click);
        }

        private void HandleBtnView_Click(object sender, RoutedEventArgs e)
        {
            var teamEdit = new TeamEdit(fileHandler);
            teamEdit.SetTeam(team);
            teamEdit.SetPlayers(players);
            teamEdit.ShowTeam();           
            teamView.Hide();
            ModalDisplay.ShowModal(teamEdit, teamView);
            team = teamEdit.GetTeam();
            team.SetTeamID(teamID);
            fileHandler.UpdateTeam(team);
            SetTeamDetail(teamID);
            teamView.ShowDialog();
        }

        public void SetOwner(Window window)
        {
            teamView.Owner = window;
        }

        public void ShowDialog()
        {
            teamView.ShowDialog();
        }

        public ButtonAction GetButtonAction()
        {
            return ButtonAction.NONE;
        }
    }
}
