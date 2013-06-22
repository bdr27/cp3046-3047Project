using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LeaderBoardApp.ModalControl;

namespace LeaderBoardApp.Utility
{
    public static class ModalDisplay
    {
        public static void ShowModal(ModalInterface modal, Window owner)
        {
            modal.SetOwner(owner);
            modal.ShowDialog();
        }
    }
}
