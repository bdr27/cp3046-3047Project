using System.Windows;

namespace NerfWarsLeaderboard
{
    /// <summary>
    /// Interaction logic for CreatePlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        public PlayerWindow()
        {
            InitializeComponent();
        }

        public PlayerWindow(string newLabel)
        {
            InitializeComponent();
            lblPlayerWindowTitle.Content = newLabel;
        }
    }
}
