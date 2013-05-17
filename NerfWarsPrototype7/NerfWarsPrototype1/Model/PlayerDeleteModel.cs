using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard.Model
{
    public class PlayerDeleteModel
    {
        private ModalPlayerEditDelete playerDelete;
        private List<Player> players;

        public PlayerDeleteModel(Window window)
        {
            playerDelete = new ModalPlayerEditDelete();
            playerDelete.Owner = window;
            playerDelete.SetDelete();
            WireHandlers();
        }

        public void Show(List<Player> players)
        {
            playerDelete.Show();
        }

        private void WireHandlers()
        {
            
        }
    }
}
