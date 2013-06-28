using System.Diagnostics;
using System.Windows;
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

        public App()
            : base()
        {
            mainWindow = new MainWindow();
            projectionWindow = new ProjectionWindow();

            LoadFileHandler();
            WireRegistraionTab();
            WireMainWindow();

            projectionWindow.Show();
            mainWindow.Show();
        }

        private void LoadFileHandler()
        {
            fileHandler = new MOCKFileHandler();
            fileHandler.LoadPlayers();
        }        

        #region MainWindowTabSelection
        private void WireMainWindow()
        {
            mainWindow.AddTabControl(HandleTab_SelectionChange);
        }

        private void HandleTab_SelectionChange(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedTab = mainWindow.GetSelectedTab();
            switch (selectedTab)
            {
                case SelectedTab.LIVE_MATCH:
                    //LoadUp Combo Boxes
                    break;
            }
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
    }
}
