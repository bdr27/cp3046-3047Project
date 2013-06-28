using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace LeaderBoardApp.Modals
{
    public static class StylesModal
    {
        private static SolidColorBrush addColour = Brushes.LightGreen;
        private static SolidColorBrush editColour = Brushes.LightBlue;
        private static SolidColorBrush deleteColour = Brushes.LightCoral;

        public static void AddWindow(Window addWindow)
        {
            addWindow.BorderBrush = addColour;
            addWindow.BorderThickness = new Thickness(2);
        }

        public static void EditWindow(Window editWindow)
        {
            editWindow.BorderBrush = editColour;
            editWindow.BorderThickness = new Thickness(2);
        }

        public static void DeleteWindow(Window deleteWindow)
        {
            deleteWindow.BorderBrush = deleteColour;
            deleteWindow.BorderThickness = new Thickness(2);
        }

        public static void EditButton(Button btnModalEditDelete)
        {
            btnModalEditDelete.Background = editColour;
            btnModalEditDelete.Content = "Edit";
        }

        public static void DeleteButton(Button btnModalEditDelete)
        {
            btnModalEditDelete.Background = deleteColour;
            btnModalEditDelete.Content = "Delete";
        }

        public static void AddButton(Button btnModalEditDelete)
        {
            btnModalEditDelete.Content = "Add";
        }
    }
}
