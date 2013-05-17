using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NerfWarsLeaderboard.Model
{
    public class TeamEditModel
    {
        private ModalTeamEditDelete teamEditModal;

        public TeamEditModel(Window window)
        {
            teamEditModal = new ModalTeamEditDelete();
            teamEditModal.Owner = window;
            WireHandlers();
        }

        public void Show()
        {
            teamEditModal.ShowDialog();
        }

        private void WireHandlers()
        {
            teamEditModal.btnModalTeamEdit.Click += BtnModalTeamEdit_Click;
            teamEditModal.btnEditTeamCancel.Click += BtnEditTeamCancel_Click;
        }

        void BtnModalTeamEdit_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I Edit stuff");
        }

        void BtnEditTeamCancel_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("I cancel and close the window");
            teamEditModal.Hide();
        }

    }
}
