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
