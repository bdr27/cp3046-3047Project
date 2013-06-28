using System.Windows;
using LeaderBoardApp.Enum;

namespace LeaderBoardApp.ModalControl
{
    public interface ModalInterface
    {
        void SetOwner(Window window);
        void ShowDialog();
        ButtonAction GetButtonAction();
    }
}
