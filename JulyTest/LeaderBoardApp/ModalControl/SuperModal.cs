using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LeaderBoardApp.Enum;

namespace LeaderBoardApp.ModalControl
{
    public class SuperModal
    {
        protected ButtonAction buttonAction;
        protected Window modalWindow;

        public SuperModal()
        {
            buttonAction = ButtonAction.NONE;
        }

        public void ShowModal()
        {
            modalWindow.ShowDialog();
        }

        public ButtonAction GetButtonAction()
        {
            return buttonAction;
        }
    }
}
