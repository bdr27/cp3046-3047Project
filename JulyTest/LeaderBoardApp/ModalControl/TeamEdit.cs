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
    public class TeamEdit : TeamSuper, ModalInterface
    {
        public TeamEdit(FileHandler fileHandler)
            :base(fileHandler)
        {
            modalTeam.SetEdit();
        }

        public void ShowTeam()
        {
            modalTeam.ShowTeam(team, players);
        }

        #region ModalInterface Members

        public void SetOwner(Window window)
        {
            modalTeam.Owner = window;
        }

        public void ShowDialog()
        {
            modalTeam.ShowDialog();
        }

        public ButtonAction GetButtonAction()
        {
            return buttonAction;
        }

        #endregion

        public Dictionary<int, Player> GetPlayers()
        {
            return players;
        }
    }
}
