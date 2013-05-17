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
        private AddEditPlayerModel addEditPlayerModel;
        private SelectPlayerModel editDeletePlayerModel;
        private AddEditTeamModel addEditTeamModel;
        private SelectTeamModel selectTeamModel;
        private TeamAddModel teamAddModel;
        private TeamEditModel teamEditModel;
        private TeamDeleteModel teamDeleteModel;
        private PlayerAddModel playerAddModel;
        private PlayerEditModel playerEditModel;
        private PlayerDeleteModel playerDeleteModel;

        public App()
            : base()
        {
            mainWindow = new MainWindow();
            projectorWindow = new ProjectorWindow();
            projectorWindow.Show();
            mainWindow.Show();

            dbHandler = new MOCKDataBaseHandler();

            //Setup up test data


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
            playerEditModel = new PlayerEditModel(mainWindow);
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
        private void LoadTeamComboBoxes(LiveMatchTab liveMatchTab, List<Team> teams)
        {
            liveMatchTab.ClearTeamComboBox();
            liveMatchTab.LoadTeamSelectComboBox(teams);
        }

        private void WireRegistrationButtons(RegistrationTab regTab)
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
                    Debug.WriteLine("I add things");
                    openAddTeamDialog();
                    break;
                case CurrentAction.DELETE:
                    Debug.WriteLine("I delelet things");
                    openDeleteTeamDialog();
                    break;
                case CurrentAction.EDIT:
                    Debug.WriteLine("I edit things");
                    openEditTeamDialog();
                    break;
            }
        }

        private void openDeleteTeamDialog()
        {
            teamDeleteModel.Show();
        }

        private void openEditTeamDialog()
        {
            teamEditModel.Show();
        }

        private void openAddTeamDialog()
        {
            teamAddModel.Show();
        }

        private void DisplayPlayerModal(CurrentAction regButtonClick)
        {
            switch (regButtonClick)
            {
                case CurrentAction.ADD:
                    Debug.WriteLine("I add players");
                    openAddPlayerDialog();
                    break;
                case CurrentAction.EDIT:
                    Debug.WriteLine("I edit players");
                    openEditPlayerDialog();
                    break;
                case CurrentAction.DELETE:
                    Debug.WriteLine("I delete players");
                    openDeletePlayerDialog();
                    break;
            }
        }

        private void openDeletePlayerDialog()
        {
            playerDeleteModel.Show();
        }

        private void openEditPlayerDialog()
        {
            playerEditModel.Show();
        }

        private void openAddPlayerDialog()
        {
            playerAddModel.Show();
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
            /*       while (!selectTeamModel.getButtonAction().Equals(ButtonAction.CLEAR))
                   {
                       selectTeamModel.updateTeams(teams);
                       selectTeamModel.show();
                       Team deletedTeam = selectTeamModel.getRemovedTeam();
                       teams.Remove(deletedTeam);
                   }
                   selectTeamModel.setToNothing();
              */
        }

        private void BtnAddTeam_Click(object sender, RoutedEventArgs e)
        {
            CurrentAction regButtonClick = CurrentAction.ADD;
            DisplayTeamModal(regButtonClick);
            /*     CurrentAction currentAction = CurrentAction.ADD;
                 addEditTeamModel.showWindow(currentAction);
                 ButtonAction buttonAction = addEditTeamModel.getButtonAction();
                 while (!buttonAction.Equals(ButtonAction.CLOSE))
                 {
                     switch (buttonAction)
                     {
                         case ButtonAction.CREATE:
                             addEditPlayerModel.showWindow(CurrentAction.ADD);
                             if (addEditPlayerModel.getButtonAction().Equals(ButtonAction.CONFIRM))
                             {
                                 Player player = addEditPlayerModel.getPlayer();
                                 currentAction = CurrentAction.EDIT;
                                 addEditTeamModel.showWindow(player);
                                 buttonAction = addEditTeamModel.getButtonAction();
                             }
                             else
                             {
                                 buttonAction = ButtonAction.CLOSE;
                             }
                             break;
                         case ButtonAction.CONFIRM:
                             teams.Add(addEditTeamModel.getTeam());
                             buttonAction = ButtonAction.CLOSE;
                             break;
                     }
                 }
                 addEditTeamModel.setToNothing();
                 LoadTeamComboBoxes(mainWindow.playGame, teams);
            */
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
            /*         CurrentAction currentAction = CurrentAction.DELETE;
                     while (!editDeletePlayerModel.getButtonAction().Equals(ButtonAction.CLOSE))
                     {
                         editDeletePlayerModel.showWindow(players, currentAction);
                         Player player = editDeletePlayerModel.getPlayer();
                         switch (editDeletePlayerModel.getButtonAction())
                         {
                             case ButtonAction.EDIT:
                                 players = editDeletePlayerModel.deletePlayer(player);
                                 break;
                         }
                     }
                     editDeletePlayerModel.setToNothing();
              */
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
            /*         CurrentAction currentAction = CurrentAction.EDIT;
                     while (!editDeletePlayerModel.getButtonAction().Equals(ButtonAction.CLOSE))
                     {
                         editDeletePlayerModel.showWindow(players, currentAction);
                         Player player = editDeletePlayerModel.getPlayer();
                         switch (editDeletePlayerModel.getButtonAction())
                         {
                             case ButtonAction.EDIT:
                                 addEditPlayerModel.showWindow(currentAction, player);
                                 break;
                         }
                     }
                     editDeletePlayerModel.setToNothing();
              */
        }
        

        private void BtnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            CurrentAction regButtonClick = CurrentAction.ADD;
            DisplayPlayerModal(regButtonClick);
            
            /*         CurrentAction currentAction = CurrentAction.ADD;
                     addEditPlayerModel.showWindow(currentAction);
                     AddPlayerAction(addEditPlayerModel.getButtonAction());
              */
        }

        /// <summary>
        /// Wires up the buttons for the live match
        /// </summary>
        /// <param name="liveMatchTab"></param>
        private void WireLiveMatchButtons(LiveMatchTab liveMatchTab)
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
