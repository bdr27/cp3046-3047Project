using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Modals;
using LeaderBoardApp.Utility;

namespace LeaderBoardApp.ModalControl
{
    public class TeamSuper
    {
        protected ModalTeam modalTeam;
        protected ButtonAction buttonAction;
        protected FileHandler fileHandler;
        protected Dictionary<int, Player> teamPlayers;
        protected Team team;

        public TeamSuper(FileHandler fileHandler)
        {
            teamPlayers = new Dictionary<int, Player>();
            this.fileHandler = fileHandler;
            modalTeam = new ModalTeam();
            buttonAction = ButtonAction.NONE;
            WireHandlers();
        }

        public Team GetTeam()
        {
            return team;
        }

        public void SetTeam(Team team)
        {
            this.team = team;
        }

        public void SetPlayers(Dictionary<int, Player> players)
        {
            teamPlayers = players;
        }

        private void WireHandlers()
        {
            modalTeam.AddBtnAddPlayerHander(HandleBtnAddPlayer_Click);
            modalTeam.AddBtnAddExistingPlayerHandler(HandleBtnAddExistingPlayer_Click);
            modalTeam.AddBtnClearHandler(HandleBtnClear_Click);
            modalTeam.AddBtnConfirmHandler(HandleBtnConfirm_Click);
        }

        private void HandleBtnConfirm_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            team = new Team(GetTeamName(), GetTeamContanct(), GetTeamPlayerIDs());
            if (team.IsValidTeam())
            {
                buttonAction = ButtonAction.CONFIRM;
                modalTeam.Close();
            }
            else
            {
                modalTeam.DisplayError();
            }
        }

        private List<int> GetTeamPlayerIDs()
        {
            var playerIDs = new List<int>();
            foreach (var player in teamPlayers)
            {
                playerIDs.Add(player.Key);
            }
            return playerIDs;
        }

        private string GetTeamContanct()
        {
            return modalTeam.GetTeamContact();
        }

        private string GetTeamName()
        {
            return modalTeam.GetTeamName();
        }

        private void HandleBtnClear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            teamPlayers = new Dictionary<int, Player>();
            modalTeam.ShowPlayers(teamPlayers);
            modalTeam.ClearValue();
        }

        private void HandleBtnAddExistingPlayer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var playerSelect = new PlayerSelectToTeam(fileHandler.GetPlayers());
            ModalDisplay.ShowModal(playerSelect, modalTeam);
            if (playerSelect.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                var playerID = (int) playerSelect.GetSelectedPlayer();    
                var player = fileHandler.GetPlayer(playerID);
                AddPlayerToTeam(playerID, player.Clone());
            }
            
        }

        private void HandleBtnAddPlayer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var playerAdd = new PlayerAdd();
            ModalDisplay.ShowModal(playerAdd, modalTeam);
            if (playerAdd.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                var newPlayer = playerAdd.GetPlayer();
                var playerID = fileHandler.GetCurrentPlayerID();
                newPlayer.SetP_ID(playerID);
                fileHandler.InsertPlayer(newPlayer);
                Debug.WriteLine(newPlayer.Details());
                AddPlayerToTeam(playerID, newPlayer.Clone());
            }
        }

        private void AddPlayerToTeam(int playerID, Player player)
        {
            if (!teamPlayers.ContainsKey(playerID))
            {
                teamPlayers.Add(playerID, player);
                modalTeam.ShowPlayers(teamPlayers);
            }
        }
    }
}
