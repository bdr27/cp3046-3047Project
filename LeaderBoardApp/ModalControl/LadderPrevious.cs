using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaderBoardApp.Modals;

namespace LeaderBoardApp.ModalControl
{
    class LadderPrevious : ModalInterface
    {
        ModalLoadLadder mll;

        public LadderPrevious()
        {
            mll = new ModalLoadLadder();
        }
        #region ModalInterface Members

        public void SetOwner(System.Windows.Window window)
        {
            mll.Owner = window;
        }

        public void ShowDialog()
        {
            mll.ShowDialog();
        }

        public Enum.ButtonAction GetButtonAction()
        {
            return mll.GetButtonAction();
        }

        #endregion

        public void SetLadders(Dictionary<int, Utility.Ladder> dic)
        {
            mll.SetLadders(dic);
        }

        public int GetLadderID()
        {
            return mll.GetLadderID();
        }
    }
}
