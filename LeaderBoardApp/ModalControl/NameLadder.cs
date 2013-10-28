using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaderBoardApp.Modals;

namespace LeaderBoardApp.ModalControl
{
    public class NameLadder : ModalInterface
    {
        ModalNameLadder mdl;

        public NameLadder()
        {
            mdl = new ModalNameLadder();
        }

        #region ModalInterface Members

        public void SetOwner(System.Windows.Window window)
        {
            mdl.Owner = window;
        }

        public void ShowDialog()
        {
            mdl.ShowDialog();
        }

        public Enum.ButtonAction GetButtonAction()
        {
            return mdl.GetButtonAction();
        }

        #endregion

        public string GetName()
        {
            return mdl.GetName();
        }
    }
}
