using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NerfWarsPrototype1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow mainWindow;
        private ProjectorWindow projectorWindow;
        public App()
            : base()
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
            projectorWindow = new ProjectorWindow();
            projectorWindow.Show();
        
            mainWindow.regMenu.btnAddPlayer.Click += btnAddPlayer_Click;
            mainWindow.regAddPlayer.btnDone.Click += btnDone_Click;
            mainWindow.regMenu.btnAddTeam.Click += btnAddTeam_Click;
            mainWindow.regAddTeam.btnDone.Click += btnDoneAddTeam_Click;
            mainWindow.regAddTeam.btnAddPlayer.Click += btnAddPlayerTeam_Click;
            
            Console.WriteLine(mainWindow.regMenu.Visibility.ToString());
        }

        private void btnAddPlayerTeam_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.regAddTeam.Visibility = Visibility.Hidden;
            mainWindow.regAddPlayer.Visibility = Visibility.Visible;
            //0 is home page
            mainWindow.regAddPlayer.pageBefore = 1;
        }

        private void btnDoneAddTeam_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.regAddTeam.Visibility = Visibility.Hidden;
            mainWindow.regMenu.Visibility = Visibility.Visible;
        }

        private void btnAddTeam_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.regMenu.Visibility = Visibility.Hidden;
            mainWindow.regAddTeam.Visibility = Visibility.Visible;
            mainWindow.regAddPlayer.pageBefore = 1;
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.regAddPlayer.Visibility = Visibility.Hidden;
            if (mainWindow.regAddPlayer.pageBefore == 0)
            {
                mainWindow.regMenu.Visibility = Visibility.Visible;
            }
            else
            {
                mainWindow.regAddTeam.Visibility = Visibility.Visible;
            }
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.regMenu.Visibility = Visibility.Hidden;
            mainWindow.regAddPlayer.Visibility = Visibility.Visible;
            //0 is home page
            mainWindow.regAddPlayer.pageBefore = 0;
        }
    }
}
