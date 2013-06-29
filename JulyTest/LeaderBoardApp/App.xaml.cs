using System;
using System.Diagnostics;
using System.Windows;
using LeaderBoardApp.AppLog;
using LeaderBoardApp.Enum;
using LeaderBoardApp.ModalControl;
using LeaderBoardApp.Utility;
using LeaderBoardApp.Windows;

namespace LeaderBoardApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow mainWindow;
        ProjectionWindow projectionWindow;
        FileHandler fileHandler;
        AL log;
        ProjectorState projectorState;

        public App()
            : base()
        {
            log = new ConsoleAL();
            mainWindow = new MainWindow();
            projectionWindow = new ProjectionWindow();
            projectorState = ProjectorState.STAND_BY;

            log.StartLog();
            LoadFileHandler();
            WireHandlers();
            projectionWindow.Show();
            mainWindow.Show();
        }

        private void LoadFileHandler()
        {
            fileHandler = new MOCKFileHandler();
            fileHandler.LoadPlayers();
            fileHandler.LoadTeams();
        }

        private void WireHandlers()
        {
            WireTabSelection();
            WireSideMenu();
            WireRegistraionTab();
        }

        

        #region MainWindowTabSelection

        private void WireTabSelection()
        {
            mainWindow.AddTabControl(HandleTab_SelectionChange);
        }
        
        private void HandleTab_SelectionChange(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedTab = mainWindow.GetSelectedTab();
            var liveMatch = mainWindow.liveMatch;
            switch (selectedTab)
            {
                case SelectedTab.LIVE_MATCH:
                    liveMatch.LoadTeamComboBox(fileHandler.GetTeams());
                    break;
            }
        }
        #endregion

        #region SideMenuSelection

        private void WireSideMenu()
        {
            mainWindow.AddSideMenuControlLiveMatch(HandleSideMenuControlLiveMatch_Click);
            mainWindow.AddSideMenuControlLadder(HandleSideMenuControlLadder_Click);
            mainWindow.AddSideMenuControlStandBy(HandleSideMenuControlStandBy_Click);
        }

        private void HandleSideMenuControlStandBy_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress(sender.ToString());
            projectorState = ProjectorState.STAND_BY;
            mainWindow.ChangeDisplay(projectorState);
            projectionWindow.ChangeDisplay(projectorState);
        }

        private void HandleSideMenuControlLadder_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress(sender.ToString());
            projectorState = ProjectorState.LADDER;
            mainWindow.ChangeDisplay(projectorState);
            projectionWindow.ChangeDisplay(projectorState);
        }

        private void HandleSideMenuControlLiveMatch_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress(sender.ToString());
            projectorState = ProjectorState.LIVE_MATCH;
            mainWindow.ChangeDisplay(projectorState);
            projectionWindow.ChangeDisplay(projectorState);
        }
        #endregion

        #region RegistraionTab

        private void WireRegistraionTab()
        {
            var regMenu = mainWindow.regMenu;
            regMenu.AddNewPlayerHandler(HandleNewPlayer_Click);
            regMenu.AddNewTeamHandler(HandleNewTeam_Click);
            regMenu.AddEditPlayerHandler(HandleEditPlayer_Click);
            regMenu.AddEditTeamHandler(HandleEditTeam_Click);
            regMenu.AddDeletePlayerHandler(HandleDeletePlayer_Click);
            regMenu.AddDeleteTeamHandler(HandleDeleteTeam_Click);
        }

        private void HandleNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress(sender.ToString());
            var addPlayer = new PlayerAdd();
            ModalDisplay.ShowModal(addPlayer, mainWindow);
            if (addPlayer.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                var newPlayer = addPlayer.GetPlayer();
                fileHandler.InsertPlayer(newPlayer);
                Debug.WriteLine(newPlayer.Details());
            }            
        }

        private void HandleNewTeam_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress(sender.ToString());
            var addTeam = new TeamAdd(fileHandler);
            ModalDisplay.ShowModal(addTeam, mainWindow);
            if (addTeam.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                var newTeam = addTeam.GetTeam();
                fileHandler.InsertTeam(newTeam);
            }
        }

        private void HandleEditPlayer_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress(sender.ToString());
            var players = fileHandler.GetPlayers();
            var editPlayers = new PlayerSelectEdit(players);
            ModalDisplay.ShowModal(editPlayers, mainWindow);            
            foreach (var playerID in editPlayers.GetPlayersIDSelected())
            {
                fileHandler.UpdatePlayer(players[playerID]);
            }
        }

        private void HandleEditTeam_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress(sender.ToString());
            var teams = fileHandler.GetTeams();
            var players = fileHandler.GetPlayers();
            var editTeams = new TeamSelectEdit(fileHandler);
            ModalDisplay.ShowModal(editTeams, mainWindow);            
            foreach (var teamID in editTeams.GetEditedTeamsID())
            {
                teams[teamID].SetTeamID(teamID);
                fileHandler.UpdateTeam(teams[teamID]);
            }
        }

        private void HandleDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress(sender.ToString());
            var deletePlayers = new PlayerSelectDelete(fileHandler.GetPlayers());
            ModalDisplay.ShowModal(deletePlayers, mainWindow);
            var playersToDelete = deletePlayers.GetPlayersIDSelected();
            var oldPlayers = fileHandler.GetPlayers();
            foreach (var playerID in playersToDelete)
            {
                fileHandler.DeletePlayer(playerID);
            }
        }

        private void HandleDeleteTeam_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress(sender.ToString());
            var oldTeam = fileHandler.GetTeams();
            var deleteTeams = new TeamSelectDelete(fileHandler);
            ModalDisplay.ShowModal(deleteTeams, mainWindow);
            var teamsToDelete = deleteTeams.GetDeletedTeams();
            foreach (var teamID in teamsToDelete)
            {
                fileHandler.DeleteTeam(teamID);
            }
        }

        #endregion

        #region LiveMatchTab

        #endregion
    }
}
