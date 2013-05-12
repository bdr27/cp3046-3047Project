using System;
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

namespace NerfWarsPrototype1
{
    /// <summary>
    /// Interaction logic for GamePlay.xaml
    /// </summary>
    public partial class GamePlay : UserControl
    {
        public GamePlay()
        {
            InitializeComponent();
        }

        public void AddTeam1TagMinusHandler(RoutedEventHandler handler)
        {
            btnTeam1TagMinus.Click += handler;
            Console.Write("I handle minusing team 1 tags");
        }

        public void AddTeam1TagPlusHandler(RoutedEventHandler handler)
        {
            btnTeam1TagPlus.Click += handler;
            Console.Write("I handle adding team 1 tags");
        }
    }
}
