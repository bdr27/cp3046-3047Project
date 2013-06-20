﻿using System;
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

namespace LeaderBoardApp.Tabs
{
    /// <summary>
    /// Interaction logic for TabRegistration.xaml
    /// </summary>
    public partial class Registration : UserControl
    {
        public Registration()
        {
            InitializeComponent();
        }

        public void AddNewPlayerHandler(RoutedEventHandler handler)
        {
            btnAddPlayer.Click += handler;
        }

        public void AddEditPlayerHandler(RoutedEventHandler handler)
        {
            btnEditPlayer.Click += handler;
        }

        public void AddDeletePlayerHandler(RoutedEventHandler handler)
        {
            btnDeletePlayer.Click += handler;
        }

        public void AddNewTeamHandler(RoutedEventHandler handler)
        {
            btnAddTeam.Click += handler;
        }

        public void AddEditTeamHandler(RoutedEventHandler handler)
        {
            btnEditTeam.Click += handler;
        }

        public void AddDeleteTeamHandler(RoutedEventHandler handler)
        {
            btnDeleteTeam.Click += handler;
        }
    }
}
