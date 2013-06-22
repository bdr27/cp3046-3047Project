using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
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

        public static void EditButton(Button btnPlayerModalEdit)
        {
            btnPlayerModalEdit.Background = editColour;
            btnPlayerModalEdit.Content = "Edit";
        }

        public static void DeleteButton(Button btnModalEditDelete)
        {
            btnModalEditDelete.Background = deleteColour;
            btnModalEditDelete.Content = "Delete";
        }
    }
}
