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

namespace LeaderBoardApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow mainWindow;
        ProjectionWindow projectionWindow;

        public App()
            : base()
        {
            mainWindow = new MainWindow();
            projectionWindow = new ProjectionWindow();
            WireRegistraionTab();

            projectionWindow.Show();
            mainWindow.Show();
        }

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
            Debug.WriteLine("I add players");
            var addPlayer = new PlayerAdd(mainWindow);
            addPlayer.ShowModal();
        }

        private void HandleNewTeam_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I add teams");
        }

        private void HandleEditPlayer_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I edit players");
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
