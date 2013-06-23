using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    class PlayerSelectToTeam : PlayerSelect, ModalInterface
    {
        public PlayerSelectToTeam(Dictionary<int, Player> players)
            : base(players)
        {
            modalSelect.SetAddPlayer();
            WireHandlers();
        }

        private void WireHandlers()
        {
            modalSelect.AddBtnModalEditHandler(HandleBtnAdd_Click);
        }

        private void HandleBtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (modalSelect.GetSelectedPlayer() != null)
            {
                buttonAction = ButtonAction.CONFIRM;
                modalSelect.Close();
            }
        }

        public int GetSelectedPlayer()
        {
            return (int) modalSelect.GetSelectedPlayer();
        }


        #region ModalInterface Members

        public void SetOwner(Window window)
        {
            modalSelect.Owner = window;
        }

        public void ShowDialog()
        {
            modalSelect.ShowDialog();
        }

        public ButtonAction GetButtonAction()
        {
            return buttonAction;
        }

        #endregion
    }
}
