using System.Diagnostics;
using System.Windows;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Modals;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class PlayerSuper
    {
        protected ButtonAction buttonAction;
        protected ModalPlayer modalPlayer;
        protected Player player;

        public PlayerSuper()
        {
            modalPlayer = new ModalPlayer();
            buttonAction = ButtonAction.NONE;
            WireHandlers();
        }

        public Player GetPlayer()
        {
            return player;
        }

        private void WireHandlers()
        {
            modalPlayer.AddBtnConfirm(HandleBtnConfirm_Click);
        }

        private void HandleBtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I confirm");
            if (modalPlayer.IsValidPlayer())
            {
                buttonAction = ButtonAction.CONFIRM;
                player = modalPlayer.GetPlayer();
                modalPlayer.Close();
            }
            else
            {
                modalPlayer.DisplayError();
            }
        }
    }
}
