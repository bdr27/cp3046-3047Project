using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
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
        protected Dictionary<int, Player> players;
        protected Team team;
        protected List<int> deletedPlayers;

        public TeamSuper(FileHandler fileHandler)
        {
            players = new Dictionary<int, Player>();
            deletedPlayers = new List<int>();
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
            this.players = players;
        }

        private void WireHandlers()
        {
            modalTeam.AddBtnAddPlayerHander(HandleBtnAddPlayer_Click);
            modalTeam.AddBtnAddExistingPlayerHandler(HandleBtnAddExistingPlayer_Click);
            modalTeam.AddBtnClearHandler(HandleBtnClear_Click);
            modalTeam.AddBtnDoneHandler(HandleBtnDone_Click);
            modalTeam.AddContextMenuView(HandleContextMenuView_Click);
            modalTeam.AddContextMenuEdit(HandleContextMenuEdit_Click);
            modalTeam.AddContextMenuDelete(HandleContextMenuDelete_Click);
        }

        private void HandleContextMenuDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to Delete?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var playerID = modalTeam.GetSelectedPlayerID();
            }
            //Update Player Names
        }

        private void HandleContextMenuEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Change this otherwise cancel is useless
            var editPlayer = new PlayerEdit();
            var playerID = modalTeam.GetSelectedPlayerID();
            editPlayer.SetPlayerDetails(fileHandler.GetPlayer(playerID).Clone());
            ModalDisplay.ShowModal(editPlayer, modalTeam.Owner);
            if (editPlayer.GetButtonAction().Equals(ButtonAction.DONE))
            {
                var player = editPlayer.GetPlayer();
                player.SetP_ID(playerID);
                fileHandler.UpdatePlayer(player);
                modalTeam.ShowPlayers(GetTeamPlayers());
            }
        }

        private void HandleContextMenuView_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewPlayer = new PlayerView(fileHandler);
            var playerID = modalTeam.GetSelectedPlayerID();
            Debug.WriteLine(playerID);
            viewPlayer.SetPlayerDetails(playerID);
            ModalDisplay.ShowModal(viewPlayer, modalTeam.Owner);
            modalTeam.ShowPlayers(GetTeamPlayers());
        }

        private Dictionary<int, Player> GetTeamPlayers()
        {
            var players = new Dictionary<int, Player>();
            foreach (var ID in team.GetPlayerIDs())
            {
                players.Add(ID, fileHandler.GetPlayer(ID));
            }
            return players;
        }

        private void HandleBtnDone_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            team = new Team(GetTeamName(), GetTeamContanct(), GetTeamPlayerIDs());
            if (team.IsValidTeam())
            {
                buttonAction = ButtonAction.DONE;
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
            foreach (var player in players)
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
            players = new Dictionary<int, Player>();
            modalTeam.ShowPlayers(players);
            modalTeam.ClearValue();
        }

        private void HandleBtnAddExistingPlayer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Rewrite this for the cancel buttons
            var playerSelect = new PlayerSelectToTeam(fileHandler);
            ModalDisplay.ShowModal(playerSelect, modalTeam);
            if (playerSelect.GetButtonAction().Equals(ButtonAction.DONE))
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
            if (playerAdd.GetButtonAction().Equals(ButtonAction.DONE))
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
            if (!players.ContainsKey(playerID))
            {
                players.Add(playerID, player);
                modalTeam.ShowPlayers(players);
            }
        }
    }
}
