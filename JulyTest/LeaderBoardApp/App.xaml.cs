using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LeaderBoardApp.Windows;
using LeaderBoardApp.ModalControl;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Utility;

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

        private void DisplayModal(ModalInterface modal)
        {
            modal.SetOwner(mainWindow);
            modal.ShowDialog();
        }

        private void HandleNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            var addPlayer = new PlayerAdd();
            DisplayModal(addPlayer);
            if (addPlayer.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                var newPlayer = addPlayer.GetPlayer();
                fileHandler.InsertPlayer(newPlayer);
                Debug.WriteLine(newPlayer.Details());
            }            
        }

        private void HandleNewTeam_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I add teams");
        }

        private void HandleEditPlayer_Click(object sender, RoutedEventArgs e)
        {
            var editPlayers = new PlayerEdit(fileHandler.GetPlayers());
            DisplayModal(editPlayers);
        }

        private void HandleEditTeam_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I edit teams");
        }

        private void HandleDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I delete players");
        }

        private void HandleDeleteTeam_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I delete teams");
        }

        #endregion
    }
}
