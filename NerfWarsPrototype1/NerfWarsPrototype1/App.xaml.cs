using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NerfWarsPrototype1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private bool timerStarted = false;
        private MainWindow mainWindow;
        private ProjectorWindow projectorWindow;
        private Timer gameTimer;
        private string gameTime = "5:00";

        public App()
            : base()
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
            projectorWindow = new ProjectorWindow();
            projectorWindow.Show();
            wireHandlers();

            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Elapsed += gameTimer_Elapsed;
            Console.WriteLine(mainWindow.regMenu.Visibility.ToString());
        }
        void wireHandlers()
        {
            mainWindow.regMenu.btnAddPlayer.Click += btnAddPlayer_Click;
            mainWindow.regAddPlayer.btnDone.Click += btnDone_Click;
            mainWindow.regMenu.btnAddTeam.Click += btnAddTeam_Click;
            mainWindow.regAddTeam.btnDone.Click += btnDoneAddTeam_Click;
            mainWindow.regAddTeam.btnAddPlayer.Click += btnAddPlayerTeam_Click;
            mainWindow.playGame.btnStartStop.Click += btnStartStop_Click;
            mainWindow.playGame.btnReset.Click += btnReset_Click;
            mainWindow.playGame.AddTeam1TagMinusHandler(team1TagMinusHandler);
            mainWindow.playGame.AddTeam1TagPlusHandler(team1TagPlusHandler);
        }

        private void team1TagPlusHandler(object sender, RoutedEventArgs e)
        {
            Debug.Write("I add team 1 :P");
        }

        private void team1TagMinusHandler(object sender, RoutedEventArgs e)
        {
            Debug.Write("I take team 1 :P");
        }

        void btnReset_Click(object sender, RoutedEventArgs e)
        {
            gameTime = "5:00";
            mainWindow.playGame.lblTime.Text = gameTime;
            projectorWindow.lblTime.Text = gameTime;
            mainWindow.playGame.btnReset.IsEnabled = false;
        }

        void gameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Debug.Write("I am a timer tick");
            string[] time = gameTime.Split(':');
            int min = Int32.Parse(time[0]);
            int sec = Int32.Parse(time[1]);

            if (sec == 0 && min != 0)
            {
                sec = 59;
                min -= 1;
            }
            else if (min == 0 && sec == 0)
            {
                gameTimer.Stop();
            }
            else
            {
                sec -= 1;
            }
            if (sec < 10)
            {
                gameTime = min + ":0" + sec;
            }
            else
            {
                gameTime = min + ":" + sec;
            }

            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<TextBlock>(setTimeValue), mainWindow.playGame.lblTime);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<TextBlock>(setTimeValue), projectorWindow.lblTime);
        }

        private void setTimeValue(TextBlock time)
        {
            time.Text = gameTime;
        }

        void btnStartStop_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("You clicked start stop");
            if (timerStarted)
            {
                gameTimer.Stop();
                mainWindow.playGame.btnReset.IsEnabled = true;
                mainWindow.playGame.btnStartStop.Content = "Start";
                timerStarted = false;
            }
            else
            {
                gameTimer.Start();
                mainWindow.playGame.btnReset.IsEnabled = false;
                mainWindow.playGame.btnStartStop.Content = "Stop";
                timerStarted = true;
            }
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
