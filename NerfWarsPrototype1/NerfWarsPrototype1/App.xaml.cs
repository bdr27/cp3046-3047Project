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

        public App()
            : base()
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
            mainWindow.regMenu.btnAddPlayer.Click += btnAddPlayer_Click;
            mainWindow.regAddPlayer.btnDone.Click += btnDone_Click;
            mainWindow.regMenu.btnAddTeam.Click += btnAddTeam_Click;
            
            Console.WriteLine(mainWindow.regMenu.Visibility.ToString());
        }

        void btnAddTeam_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.regMenu.Visibility = Visibility.Hidden;
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.regAddPlayer.Visibility = Visibility.Hidden;
            if (mainWindow.regAddPlayer.pageBefore == 0)
            {
                mainWindow.regMenu.Visibility = Visibility.Visible;
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
