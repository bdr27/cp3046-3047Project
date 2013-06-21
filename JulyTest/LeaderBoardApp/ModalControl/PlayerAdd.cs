using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LeaderBoardApp.Modals;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class PlayerAdd : SuperModal
    {
        private ModalPlayer playerAdd;
        private Player newPlayer;

        public PlayerAdd(Window window)
            : base()
        {
            playerAdd = new ModalPlayer();
            base.modalWindow = playerAdd;
            playerAdd.Owner = window;
            WireHandlers();
        }

        private void WireHandlers()
        {
            playerAdd.AddBtnConfirm(HandleBtnConfirm_Click);
        }

        private void HandleBtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I confirm");
            newPlayer = playerAdd.GetPlayer();

        }
    }
}
