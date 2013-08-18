using LeaderBoardApp.Enum;
using LeaderBoardApp.Utility;
using System.Diagnostics;
using System.Windows;

namespace LeaderBoardApp.ModalControl
{
    class TeamSelectView : TeamSelect, ModalInterface
    {
        public TeamSelectView(FileHandler fileHandler)
            :base (fileHandler)
        {
            modalSelect.SetTeamView();
            WireHandlers();
        }

        private void WireHandlers()
        {
            modalSelect.AddBtnModalEditHandler(HandlerBtnModalView_Click);
        }

        private void HandlerBtnModalView_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("VIEW IT");
            modalSelect.Hide();
            var teamView = new TeamView(fileHandler);
            teamView.SetTeamDetail((int)modalSelect.GetSelectedPlayer());
            ModalDisplay.ShowModal(teamView, modalSelect);
            modalSelect.DisplayTeams(teams);
            modalSelect.Show();
        }

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
    }
}
