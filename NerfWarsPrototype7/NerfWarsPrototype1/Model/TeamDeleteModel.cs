using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NerfWarsLeaderboard.Model
{
    public class TeamDeleteModel
    {
        private ModalTeamEditDelete teamDeleteModel;

        public TeamDeleteModel(Window window)
        {
            teamDeleteModel = new ModalTeamEditDelete();
            teamDeleteModel.Owner = window;
            WireHandlers();

        }

        public void Show()
        {
            teamDeleteModel.ShowDialog();
        }

        private void WireHandlers()
        {
            teamDeleteModel.btnEditTeamCancel.Click += btnEditTeamCancel_Click;
            teamDeleteModel.btnModalTeamEdit.Click += btnModalTeamEdit_Click;
        }

        void btnModalTeamEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Debug.WriteLine("I Delete things");
            teamDeleteModel.Hide();
        }

        private void btnEditTeamCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Debug.WriteLine("I Close the window");
        }
    }
}
