using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using NerfWarsLeaderboard.Model;
using NerfWarsLeaderboard.Utility;

namespace NerfWarsLeaderboard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private int GAME_TIMER_INTERVAL = 1000;
        private int DEFAULT_MIN = 5;
        private int DEFAULT_SEC = 0;
        private Game game = new Game();
        private List<Team> teams;
        private List<Player> players;
        private Timer gameTimer;
        private MainWindow mainWindow;
        private ProjectorWindow projectorWindow;
        private GameState gameState;
        private DataBaseHandler dbHandler;
        private TeamAddModel teamAddModel;
        private TeamEditModel teamEditModel;
        private TeamDeleteModel teamDeleteModel;
        private PlayerAddModel playerAddModel;
        private PlayerSelectEditModel playerSelectEditModel;
        private PlayerDeleteModel playerDeleteModel;
        private ProjectorState projectorState;

        public App()
            : base()
        {
            
            mainWindow = new MainWindow();
            projectorWindow = new ProjectorWindow();
            projectorState = ProjectorState.STANDBY;
            projectorWindow.Show();
            mainWindow.Show();

            dbHandler = new MOCKDataBaseHandler();

            //Starting game state
            gameState = GameState.WAITING;
            //Loads the teams to the combo box
            //TODO should probably be done when the tab is pressed.

            Load();
        }

        private void Load()
        {
            LoadData();
            //Wires up the live match button handlers
            WireHandlers();
            LoadModels();
            //Sets up the game timer.
            SetupGameTime();

            LoadTeamComboBoxes(mainWindow.playGame, teams);
        }

        /// <summary>
        /// Loads various data
        /// </summary>
        private void LoadData()
        {
            players = dbHandler.LoadPlayers();
            teams = dbHandler.LoadTeams();
        }

        private void LoadModels()
        {
            teamAddModel = new TeamAddModel(mainWindow);
            teamEditModel = new TeamEditModel(mainWindow);
            teamDeleteModel = new TeamDeleteModel(mainWindow);
            playerAddModel = new PlayerAddModel(mainWindow);
            playerSelectEditModel = new PlayerSelectEditModel(mainWindow);
            playerDeleteModel = new PlayerDeleteModel(mainWindow);
        }

        private void WireHandlers()
        {
            WireLiveMatchButtons(mainWindow.playGame);
            WireRegistrationButtons(mainWindow.regMenu);
        }

        /// <summary>
        /// Loads the combo box's with the team names
        /// </summary>
        /// <param name="liveMatchTab"></param>
        /// <param name="teams"></param>
        private void LoadTeamComboBoxes(TabLiveMatch liveMatchTab, List<Team> teams)
        {
            liveMatchTab.ClearTeamComboBox();
            liveMatchTab.LoadTeamSelectComboBox(teams);
        }

        private void WireRegistrationButtons(TabRegistration regTab)
        {
            regTab.btnAddPlayer.Click += BtnAddPlayer_Click;
            regTab.btnEditPlayer.Click += BtnEditPlayer_Click;
            regTab.btnDeletePlayer.Click += BtnDeletePlayer_Click;
            regTab.btnAddTeam.Click += BtnAddTeam_Click;
            regTab.btnDeleteTeam.Click += BtnDeleteTeam_Click;
            regTab.btnEditTeam.Click += BtnEditTeam_Click;
        }

        private void DisplayTeamModal(CurrentAction regButtonClick)
        {
            switch (regButtonClick)
            {
                case CurrentAction.ADD:
                    Debug.WriteLine("Add new teams");
                    openAddTeamDialog();
                    break;
                case CurrentAction.DELETE:
                    Debug.WriteLine("Delete teams");
                    openDeleteTeamDialog();
                    break;
                case CurrentAction.EDIT:
                    Debug.WriteLine("Edit Existing teams");
                    openEditTeamDialog();
                    break;
            }
            LoadTeamComboBoxes(mainWindow.playGame, teams);
            teams = dbHandler.GetTeams();
        }

        private void openDeleteTeamDialog()
        {
            teamDeleteModel.UpdateTeams(teams);
            teamDeleteModel.Show();
            if (teamDeleteModel.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                dbHandler.DeleteTeam(teamDeleteModel.GetTeam());
            }
        }

        private void openEditTeamDialog()
        {
            do
            {
                teamEditModel.UpdateTeams(teams);
                teamEditModel.Show();
                if (teamEditModel.GetButtonAction().Equals(ButtonAction.CONFIRM))
                {
                    Team team = teamEditModel.GetTeam();
                    TeamAddModel teamEdit = new TeamAddModel(mainWindow);
                    teamEdit.SetTeam(team);
                    teamEdit.Show();
                    dbHandler.UpdateTeam(team);
                    Debug.WriteLine("Display the team add window with the ability to edit");
                }
            } while (!teamEditModel.GetButtonAction().Equals(ButtonAction.CLOSE));
        }

        private void openAddTeamDialog()
        {
            Team team = new Team();
            teamAddModel.SetTeam(team);
            do
            {
                teamAddModel.Show();
                switch (teamAddModel.GetButtonAction())
                {
                    case ButtonAction.ADD:
                        openAddPlayerDialog();
                        checkAddNewPlayerToTeam(playerAddModel.GetPlayer());
                        break;
                    case ButtonAction.EXISTING:
                        Debug.WriteLine("Going to add existing player to team");
                        openTeamAddExistingPlayer();
                        break;
                }
            } while (!teamAddModel.GetButtonAction().Equals(ButtonAction.CLOSE));
            dbHandler.InsertTeam(teamAddModel.GetTeam());
        }

        private void openTeamAddExistingPlayer()
        {
            PlayerSelectEditModel existingPlayerWindow = new PlayerSelectEditModel(mainWindow);
            existingPlayerWindow.Show(players);
            if (existingPlayerWindow.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                teamAddModel.AddPlayer(existingPlayerWindow.GetPlayer());                
            }
        }

        private void checkAddNewPlayerToTeam(Player player)
        {
            if (playerAddModel.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                teamAddModel.AddPlayer(player);
                players.Add(player);
                dbHandler.InsertPlayer(player);
            }
        }

        private void DisplayPlayerModal(CurrentAction regButtonClick)
        {
            switch (regButtonClick)
            {
                case CurrentAction.ADD:
                    Debug.WriteLine("Add new players");
                    openAddPlayerDialog();
                    break;
                case CurrentAction.EDIT:
                    Debug.WriteLine("Edit existing players");
                    openPlayerSelectEditDialog();
                    break;
                case CurrentAction.DELETE:
                    Debug.WriteLine("Delete players");
                    openDeletePlayerDialog();
                    break;
            }
            //Update the players
            players = dbHandler.GetPlayers();
            LoadTeamComboBoxes(mainWindow.playGame, teams);
        }

        private void openDeletePlayerDialog()
        {
            playerDeleteModel.Show(players);
            //Checks what button was pressed
            if (playerDeleteModel.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                dbHandler.DeletePlayer(playerDeleteModel.GetPlayer());
            }
        }

        private void openPlayerSelectEditDialog()
        {
            do
            {
                playerSelectEditModel.Show(players);
                //Checks for the user if they are editing a player
                if (playerSelectEditModel.GetIsEditingPlayer())
                {
                    Debug.WriteLine("Display selecting the player to edit");
                    PlayerEditModel playerEditWindow = new PlayerEditModel(mainWindow);
                    playerEditWindow.Show(players, playerSelectEditModel.GetPlayer());
                    //Player has pressed confirmed so they do wish to update a player
                    if (playerEditWindow.GetAction().Equals(ButtonAction.CONFIRM))
                    {
                        dbHandler.UpdatePlayer(playerEditWindow.GetPlayer());
                    }
                }
            } while (playerSelectEditModel.GetIsEditingPlayer());
        }

        private void openAddPlayerDialog()
        {
            playerAddModel.Show(players);
            dbHandler.InsertPlayer(playerAddModel.GetPlayer());
        }

        private void BtnEditTeam_Click(object sender, RoutedEventArgs e)
        {
            CurrentAction regButtonClick = CurrentAction.EDIT;
            DisplayTeamModal(regButtonClick);
        }

        private void BtnDeleteTeam_Click(object sender, RoutedEventArgs e)
        {
            CurrentAction regButtonClick = CurrentAction.DELETE;
            DisplayTeamModal(regButtonClick);
        }

        private void BtnAddTeam_Click(object sender, RoutedEventArgs e)
        {
            CurrentAction regButtonClick = CurrentAction.ADD;
            DisplayTeamModal(regButtonClick);
        }

        /// <summary>
        /// This code is bad. I need to rewrite it when I have more time. More then likely on the weekend
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            CurrentAction regButtonClick = CurrentAction.DELETE;
            DisplayPlayerModal(regButtonClick);
        }

        /// <summary>
        /// More bad code needs to be rewritten with the message handler in mind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BtnEditPlayer_Click(object sender, RoutedEventArgs e)
        {
            CurrentAction regButtonClick = CurrentAction.EDIT;
            DisplayPlayerModal(regButtonClick);
        }


        private void BtnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            CurrentAction regButtonClick = CurrentAction.ADD;
            DisplayPlayerModal(regButtonClick);
        }

        /// <summary>
        /// Wires up the buttons for the live match
        /// </summary>
        /// <param name="liveMatchTab"></param>
        private void WireLiveMatchButtons(TabLiveMatch liveMatchTab)
        {
            liveMatchTab.btnStartPause.Click += BtnStartPause_Click;
            liveMatchTab.btnFlagPlusA.Click += BtnFlagPlusA_Click;
            liveMatchTab.btnFlagPlusB.Click += BtnFlagPlusB_Click;
            liveMatchTab.btnFlagMinusA.Click += BtnFlagMinusA_Click;
            liveMatchTab.btnFlagMinusB.Click += btnFlagMinusB_Click;
            liveMatchTab.btnTagMinusA.Click += BtnTagMinusA_Click;
            liveMatchTab.btnTagMinusB.Click += BtnTagMinusB_Click;
            liveMatchTab.btnTagPlusA.Click += BtnTagPlusA_Click;
            liveMatchTab.btnTagPlusB.Click += BtnTagPlusB_Click;
            liveMatchTab.btnReset.Click += BtnReset_Click;
            mainWindow.projectorController.btnLiveMatch.Click += btnLiveMatch_Click;
            mainWindow.projectorController.btnLadder.Click += btnLadder_Click;
            mainWindow.projectorController.btnStandby.Click += btnStandby_Click;
        }

        void btnLiveMatch_Click(object sender, RoutedEventArgs e)
        {
            projectorState = ProjectorState.LIVE;
            projectorWindow.ProjectorGame.Visibility = Visibility.Visible;
            projectorWindow.ProjectorLadder.Visibility = Visibility.Hidden;
            projectorWindow.ProjectorStandby.Visibility = Visibility.Hidden;

            mainWindow.ProjectorGame.Visibility = Visibility.Visible;
            mainWindow.ProjectorLadder.Visibility = Visibility.Hidden;
            mainWindow.ProjectorStandby.Visibility = Visibility.Hidden;
        }

        void btnLadder_Click(object sender, RoutedEventArgs e)
        {
            projectorState = ProjectorState.LADDER;
            projectorWindow.ProjectorGame.Visibility = Visibility.Hidden;
            projectorWindow.ProjectorLadder.Visibility = Visibility.Visible;
            projectorWindow.ProjectorStandby.Visibility = Visibility.Hidden;

            mainWindow.ProjectorGame.Visibility = Visibility.Hidden;
            mainWindow.ProjectorLadder.Visibility = Visibility.Visible;
            mainWindow.ProjectorStandby.Visibility = Visibility.Hidden;
        }

        void btnStandby_Click(object sender, RoutedEventArgs e)
        {
            projectorState = ProjectorState.STANDBY;
            projectorWindow.ProjectorGame.Visibility = Visibility.Hidden;
            projectorWindow.ProjectorLadder.Visibility = Visibility.Hidden;
            projectorWindow.ProjectorStandby.Visibility = Visibility.Visible;

            mainWindow.ProjectorGame.Visibility = Visibility.Hidden;
            mainWindow.ProjectorLadder.Visibility = Visibility.Hidden;
            mainWindow.ProjectorStandby.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// When the reset button is clicked reset the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetMatch();
        }

        private void BtnTagPlusB_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.TeamBaddTag();
                SetGameScoreLabels();
            }
        }

        private void BtnTagPlusA_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.TeamAaddTag();
                SetGameScoreLabels();
            }
        }

        private void BtnTagMinusB_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.TeamBMinusTag();
                SetGameScoreLabels();
            }
        }

        private void BtnTagMinusA_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.TeamAMinusTag();
                SetGameScoreLabels();
            }
        }

        private void BtnFlagMinusA_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.TeamAMinusFlag();
                SetGameScoreLabels();
            }
        }

        private void btnFlagMinusB_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.TeamBMinusFlag();
                SetGameScoreLabels();
            }
        }

        private void BtnFlagPlusB_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.TeamBaddFlag();
                SetGameScoreLabels();
            }
        }

        private void BtnFlagPlusA_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.TeamAaddFlag();
                SetGameScoreLabels();
            }
        }

        /// <summary>
        /// Click event for the btnStartPause in the LiveMatchTab. When a game begins the teams need to be loaded, check if they are unique and not null.
        /// Will then go on to load the correct information or if game has already begun will pause/start the timer depending on the state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartPause_Click(object sender, RoutedEventArgs e)
        {
            switch (gameState)
            {
                case GameState.WAITING:
                    CreateNewMatch();
                    break;
                case GameState.IN_GAME:
                    PauseMatch();
                    break;
                case GameState.PAUSE:
                    ResumeMatch();
                    break;
            }
        }

        private void ResumeMatch()
        {
            gameState = GameState.IN_GAME;
            ChangeStartPauseButton();
            DisableReset();
            gameTimer.Start();
        }

        private void PauseMatch()
        {
            gameState = GameState.PAUSE;
            ChangeStartPauseButton();
            gameTimer.Stop();
            enableReset();
        }

        private void DisableReset()
        {
            var liveMatch = mainWindow.playGame;
            liveMatch.DisableBtnReset();
        }

        private void enableReset()
        {
            var liveMatch = mainWindow.playGame;
            liveMatch.EnableBtnReset();
        }

        private void FinishedMatch()
        {
            //Game is over
            gameState = GameState.GAME_OVER;
            enableReset();
            gameTimer.Stop();
            ChangeStartPauseButton();
        }

        private void ResetMatch()
        {
            //Changes values in the labels
            gameState = GameState.WAITING;
            ChangeStartPauseButton();
            game.Reset(DEFAULT_MIN, DEFAULT_SEC);
            EnableTeamComboBoxes();
            SetTimerLabels();
            SetGameScoreLabels();
            DisableReset();
        }

        private void CreateNewMatch()
        {
            //TODO clean up this code
            Team teamA = mainWindow.playGame.GetTeamA();
            Team teamB = mainWindow.playGame.GetTeamB();

            //Returns if either team is null or teams are the same
            if (teamA == null || teamB == null || teamA.Equals(teamB))
            {
                Debug.WriteLine("Please enter correct team stuff");
            }
            else
            {
                projectorWindow.LoadTeams(teamA, teamB);
                mainWindow.updateProjectorTeam(teamA, teamB);
                gameState = GameState.IN_GAME;
                DisableTeamComboBoxes();
                DisableReset();
                ChangeStartPauseButton();
                LoadTeams(teamA, teamB);
                game.SetMin(LoadGameMin());
                game.SetSec(LoadGameSec());
                gameTimer.Start();
            }
        }

        /// <summary>
        /// Disable the team combo boxes
        /// </summary>
        private void DisableTeamComboBoxes()
        {
            var liveMatchTab = mainWindow.playGame;
            liveMatchTab.DisableTeamComboBoxes();
        }

        private void EnableTeamComboBoxes()
        {
            var liveMatchTab = mainWindow.playGame;
            liveMatchTab.EnableTeamComboBoxes();
        }

        /// <summary>
        /// Sets up the game timer.
        /// </summary>
        private void SetupGameTime()
        {
            gameTimer = new Timer();
            gameTimer.Interval = GAME_TIMER_INTERVAL;
            gameTimer.Elapsed += GameTimer_Elapsed;
        }

        /// <summary>
        /// Change the value of the StartPause button based on what state the game currently is in. Should probably use a state machine
        /// </summary>
        private void ChangeStartPauseButton()
        {
            var btnStartPause = mainWindow.playGame.btnStartPause;
            switch (gameState)
            {
                case GameState.IN_GAME:
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Button>(SetStartPauseToPause), btnStartPause);
                    break;
                case GameState.GAME_OVER:
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Button>(SetStartPauseToGameOver), btnStartPause);
                    break;
                case GameState.PAUSE:
                case GameState.WAITING:
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Button>(SetStartPauseToStart), btnStartPause);
                    break;
            }
        }

        //TODO move all these to the gui
        private void SetStartPauseToGameOver(Button btnStartPause)
        {
            btnStartPause.IsEnabled = false;
            btnStartPause.Content = "GAME OVER";
        }

        private void SetStartPauseToStart(Button btnStartPause)
        {
            btnStartPause.Content = "Start";
            btnStartPause.IsEnabled = true;
        }

        private void SetStartPauseToPause(Button btnStartPause)
        {
            btnStartPause.Content = "Pause";
            btnStartPause.IsEnabled = true;
        }

        private void GameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

            //Checks if game is over
            if (game.CountDown())
            {
                FinishedMatch();
            }
            //Changes values in the labels
            SetTimerLabels();
            SetGameScoreLabels();
        }

        /// <summary>
        /// Sets the scores label for each Team A and Team B based on what the current score for each team is for the game
        /// </summary>
        private void SetGameScoreLabels()
        {
            var playGame = mainWindow.playGame;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamAScore), playGame.lblScoreA);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamBScore), playGame.lblScoreB);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamATag), playGame.lblTagA);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamBTag), playGame.lblTagB);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamACap), playGame.lblFlagA);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetTeamBCap), playGame.lblFlagB);
        
            projectorWindow.UpdateGameDetails(game);
            mainWindow.updateProjectorGame(game);
        }

        private void SetTeamATag(Label lblTagA)
        {
            lblTagA.Content = "Tag: " + game.GetTeamATag();
        }

        private void SetTeamBTag(Label lblTagB)
        {
            lblTagB.Content = "Tag: " + game.GetTeamBTag();
        }

        private void SetTeamACap(Label lblFlagA)
        {
            lblFlagA.Content = "Flag: " + game.GetTeamAFlag();
        }

        private void SetTeamBCap(Label lblFlagB)
        {
            lblFlagB.Content = "Flag: " + game.GetTeamBFlag();
        }

        private void SetTeamAScore(Label lblScoreA)
        {
            lblScoreA.Content = "Score: " + game.GetTeamAScore();
        }

        private void SetTeamBScore(Label lblScoreB)
        {
            lblScoreB.Content = "Score: " + game.GetTeamBScore();
        }

        /// <summary>
        /// Sets the minute and second label again based on what is in the game class.
        /// </summary>
        private void SetTimerLabels()
        {
            var playGame = mainWindow.playGame;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<TextBox>(SetTextBlockMinute), playGame.TbMinutes);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<TextBox>(SetTextBlockSeconds), playGame.TbSeconds);
        }

        private void SetTextBlockSeconds(TextBox tbSeconds)
        {
            tbSeconds.Text = "" + game.GetSec();
        }

        private void SetTextBlockMinute(TextBox tbMinutes)
        {
            tbMinutes.Text = "" + game.GetMin();
        }

        /// <summary>
        /// Returns the value of the minute TextBox so the game can have many different times
        /// </summary>
        /// <returns>Return an int for how long the game will be in minutes</returns>
        private int LoadGameMin()
        {
            return mainWindow.playGame.GetMin();
        }

        /// <summary>
        /// Returns the value of the seconds TextBox so the game can have many different times
        /// </summary>
        /// <returns>Return an int for how many seconds there are to start</returns>
        private int LoadGameSec()
        {
            return mainWindow.playGame.GetSec();
        }

        /// <summary>
        /// Loads the Teams into the game class so that they can be used to play the game
        /// </summary>
        /// <param name="teamA"></param>
        /// <param name="teamB"></param>
        private void LoadTeams(Team teamA, Team teamB)
        {
            game.LoadTeamA(teamA);
            game.LoadTeamB(teamB);
            Debug.WriteLine(teamA);
            Debug.WriteLine(teamB);
        }
    }
}
