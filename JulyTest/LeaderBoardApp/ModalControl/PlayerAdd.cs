using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LeaderBoardApp.Modals;

namespace LeaderBoardApp.ModalControl
{
    public class PlayerAdd
    {
        private ModalPlayer playerAdd;

        public PlayerAdd(Window window)
        {
            
            playerAdd = new ModalPlayer();
            playerAdd.Owner = window;
            WireHandlers();
        }

        private void WireHandlers()
        {
            //throw new NotImplementedException();
        }

        public void ShowModal()
        {
            playerAdd.ShowDialog();
        }


    }
}
