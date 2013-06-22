using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
