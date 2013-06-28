using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using LeaderBoardApp.Enum;

namespace LeaderBoardApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddTabControl(SelectionChangedEventHandler handler)
        {
            MainWindowTabControl.SelectionChanged += handler;
        }

        public SelectedTab GetSelectedTab()
        {
            var selectedTab = (SelectedTab) MainWindowTabControl.SelectedIndex;
            Debug.WriteLine(selectedTab);
            return selectedTab;
        }
    }
}
