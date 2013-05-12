using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Utility;

namespace NerfWarsPrototype1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private int GAME_TIMER_INTERVAL = 1000;
        private int DEFAULT_MIN = 5;
        private int DEFAULT_SEC = 0;
     //   private bool gameBegun = false;
        private Game game = new Game();
        private List<Team> teams;
        private List<Player> tempPlayers;
        private Timer gameTimer;
       // private bool gamePause;
        private MainWindow mainWindow;
        private ProjectorWindow projectorWindow;
        private GameState gameState;

        public App()
            : base()
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
            // projectorWindow = new ProjectorWindow();
            // projectorWindow.Show();

            //Setup up test data
            testData();

            //Starting game state
            gameState = GameState.WAITING;
            //Loads the teams to the combo box
            //TODO should probably be done when the tab is pressed.
            loadTeamComboBoxes(mainWindow.playGame, teams);
            //Wires up the live match button handlers
            wireLiveMatchButtons(mainWindow.playGame);
            //Sets up the game timer.
            setupGameTime();
        }

        private void testData()
        {
            tempPlayers = loadTempPlayers();
            teams = loadTeams();
        }

        private List<Player> loadTempPlayers()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player("Bob", "Smith"));
            players.Add(new Player("John", "Jane"));
            players.Add(new Player("Sarah", "Luan"));
            players.Add(new Player("I am", "a person"));
            return players;
        }


        private List<Team> loadTeams()
        {
            List<Team> newTeams = new List<Team>();
            newTeams.Add(new Team(tempPlayers, "Wildcats"));
            newTeams.Add(new Team(tempPlayers, "Wildcats"));
            newTeams.Add(new Team(tempPlayers, "Super Awesome Wildcats"));
            return newTeams;
        }

        /// <summary>
        /// Loads the combo box's with the team names
        /// </summary>
        /// <param name="liveMatchTab"></param>
        /// <param name="teams"></param>
        private void loadTeamComboBoxes(LiveMatchTab liveMatchTab, List<Team> teams)
        {
            liveMatchTab.loadTeamSelectComboBox(teams);
        }

        /// <summary>
        /// Wires up the buttons for the live match
        /// </summary>
        /// <param name="liveMatchTab"></param>
        private void wireLiveMatchButtons(LiveMatchTab liveMatchTab)
        {
            liveMatchTab.btnStartPause.Click += btnStartPause_Click;
            liveMatchTab.btnFlagPlusA.Click += btnFlagPlusA_Click;
            liveMatchTab.btnFlagPlusB.Click += btnFlagPlusB_Click;
            liveMatchTab.btnFlagMinusA.Click += btnFlagMinusA_Click;
            liveMatchTab.btnFlagMinusB.Click += btnFlagMinusB_Click;
            liveMatchTab.btnTagMinusA.Click += btnTagMinusA_Click;
            liveMatchTab.btnTagMinusB.Click += btnTagMinusB_Click;
            liveMatchTab.btnTagPlusA.Click += btnTagPlusA_Click;
            liveMatchTab.btnTagPlusB.Click += btnTagPlusB_Click;
            liveMatchTab.btnReset.Click += btnReset_Click;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            resetMatch();
        }

        private void btnTagPlusB_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.teamBaddTag();
                setGameScoreLabels();
            }
        }

        private void btnTagPlusA_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.teamAaddTag();
                setGameScoreLabels();
            }
        }

        private void btnTagMinusB_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.teamBMinusTag();
                setGameScoreLabels();
            }
        }

        private void btnTagMinusA_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.teamAMinusTag();
                setGameScoreLabels();
            }
        }

        private void btnFlagMinusA_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.teamAMinusFlag();
                setGameScoreLabels();
            }
        }

        private void btnFlagMinusB_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.teamBMinusFlag();
                setGameScoreLabels();
            }
        }

        private void btnFlagPlusB_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.teamBaddFlag();
                setGameScoreLabels();
            }
        }

        private void btnFlagPlusA_Click(object sender, RoutedEventArgs e)
        {
            //Can't edit scores while waiting for match
            if (!gameState.Equals(GameState.WAITING))
            {
                game.teamAaddFlag();
                setGameScoreLabels();
            }
        }

        /// <summary>
        /// Click event for the btnStartPause in the LiveMatchTab. When a game begins the teams need to be loaded, check if they are unique and not null.
        /// Will then go on to load the correct information or if game has already begun will pause/start the timer depending on the state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartPause_Click(object sender, RoutedEventArgs e)
        {
            switch (gameState)
            {
                case GameState.WAITING:
                    createNewMatch();
                    break;
                case GameState.IN_GAME:
                    pauseMatch();
                    break;
                case GameState.PAUSE:
                    resumeMatch();
                    break;
            }
        }

        private void resumeMatch()
        {
            gameState = GameState.IN_GAME;
            changeStartPauseButton();
            disableReset();
            gameTimer.Start();
        }

        private void pauseMatch()
        {
            gameState = GameState.PAUSE;
            changeStartPauseButton();
            gameTimer.Stop();
            enableReset();
        }

        private void disableReset()
        {
            var liveMatch = mainWindow.playGame;
            liveMatch.disableBtnReset();
        }

        private void enableReset()
        {
            var liveMatch = mainWindow.playGame;
            liveMatch.enableBtnReset();
        }

        private void finishedMatch()
        {
            //Game is over
            gameState = GameState.GAME_OVER;
            enableReset();
            gameTimer.Stop();
            changeStartPauseButton();
        }        

        private void resetMatch()
        {
            //Changes values in the labels
            gameState = GameState.WAITING;
            changeStartPauseButton();
            game.reset(DEFAULT_MIN, DEFAULT_SEC);
            enableTeamComboBoxes();
            setTimerLabels();
            setGameScoreLabels();
            disableReset();
        }

        private void createNewMatch()
        {
            Team teamA = mainWindow.playGame.getTeamA();
            Team teamB = mainWindow.playGame.getTeamB();

            //Returns if either team is null or teams are the same
            if (teamA == null || teamB == null || teamA.Equals(teamB))
            {
                Debug.WriteLine("Please enter correct team stuff");
            }
            else
            {
                gameState = GameState.IN_GAME;
                disableTeamComboBoxes();
                disableReset();
                changeStartPauseButton();
                loadTeams(teamA, teamB);
                game.setMin(loadGameMin());
                game.setSec(loadGameSec());
                gameTimer.Start();
            }
        }

        /// <summary>
        /// Disable the team combo boxes
        /// </summary>
        private void disableTeamComboBoxes()
        {
            var liveMatchTab = mainWindow.playGame;
            liveMatchTab.disableTeamComboBoxes();
        }

        private void enableTeamComboBoxes()
        {
            var liveMatchTab = mainWindow.playGame;
            liveMatchTab.enableTeamComboBoxes();
        }

        /// <summary>
        /// Sets up the game timer.
        /// </summary>
        private void setupGameTime()
        {
            gameTimer = new Timer();
            gameTimer.Interval = GAME_TIMER_INTERVAL;
            gameTimer.Elapsed += gameTimer_Elapsed;
        }

        /// <summary>
        /// Change the value of the StartPause button based on what state the game currently is in. Should probably use a state machine
        /// </summary>
        private void changeStartPauseButton()
        {
            var btnStartPause = mainWindow.playGame.btnStartPause;
            switch (gameState)
            {
                case GameState.IN_GAME:
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Button>(setStartPauseToPause), btnStartPause);
                    break;
                case GameState.GAME_OVER:
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Button>(setStartPauseToGameOver), btnStartPause);
                    break;
                case GameState.PAUSE:
                case GameState.WAITING:
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Button>(setStartPauseToStart), btnStartPause);
                    break;
            }
        }

        //TODO move all these to the gui
        private void setStartPauseToGameOver(Button btnStartPause)
        {
            btnStartPause.IsEnabled = false;
            btnStartPause.Content = "GAME OVER";
        }

        private void setStartPauseToStart(Button btnStartPause)
        {
            btnStartPause.Content = "Start";
            btnStartPause.IsEnabled = true;
        }

        private void setStartPauseToPause(Button btnStartPause)
        {
            btnStartPause.Content = "Pause";
            btnStartPause.IsEnabled = true;
        }

        private void gameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            //Checks if game is over
            if (game.CountDown())
            {
                finishedMatch();
            }
            //Changes values in the labels
            setTimerLabels();
            setGameScoreLabels();
        }

        /// <summary>
        /// Sets the scores label for each Team A and Team B based on what the current score for each team is for the game
        /// </summary>
        private void setGameScoreLabels()
        {
            var playGame = mainWindow.playGame;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamAScore), playGame.lblScoreA);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamBScore), playGame.lblScoreB);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamATag), playGame.lblTagA);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamBTag), playGame.lblTagB);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamACap), playGame.lblFlagA);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(setTeamBCap), playGame.lblFlagB);
        }

        private void setTeamATag(Label lblTagA)
        {
            lblTagA.Content = "Tag: " + game.getTeamATag();
        }

        private void setTeamBTag(Label lblTagB)
        {
            lblTagB.Content = "Tag: " + game.getTeamBTag();
        }

        private void setTeamACap(Label lblFlagA)
        {
            lblFlagA.Content = "Flag: " + game.getTeamAFlag();
        }

        private void setTeamBCap(Label lblFlagB)
        {
            lblFlagB.Content = "Flag: " + game.getTeamBFlag();
        }

        private void setTeamAScore(Label lblScoreA)
        {
            lblScoreA.Content = "Score: " + game.getTeamAScore();
        }

        private void setTeamBScore(Label lblScoreB)
        {
            lblScoreB.Content = "Score: " + game.getTeamBScore();
        }

        /// <summary>
        /// Sets the minute and second label again based on what is in the game class.
        /// </summary>
        private void setTimerLabels()
        {
            var playGame = mainWindow.playGame;
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<TextBox>(setTextBlockMinute), playGame.TbMinutes);
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action<TextBox>(setTextBlockSeconds), playGame.TbSeconds);
        }

        private void setTextBlockSeconds(TextBox tbSeconds)
        {
            tbSeconds.Text = "" + game.getSec();
        }

        private void setTextBlockMinute(TextBox tbMinutes)
        {
            tbMinutes.Text = "" + game.getMin();
        }

        /// <summary>
        /// Returns the value of the minute TextBox so the game can have many different times
        /// </summary>
        /// <returns>Return an int for how long the game will be in minutes</returns>
        private int loadGameMin()
        {
            return mainWindow.playGame.getMin();
        }

        /// <summary>
        /// Returns the value of the seconds TextBox so the game can have many different times
        /// </summary>
        /// <returns>Return an int for how many seconds there are to start</returns>
        private int loadGameSec()
        {
            return mainWindow.playGame.getSec();
        }

        /// <summary>
        /// Loads the Teams into the game class so that they can be used to play the game
        /// </summary>
        /// <param name="teamA"></param>
        /// <param name="teamB"></param>
        private void loadTeams(Team teamA, Team teamB)
        {
            game.loadTeamA(teamA);
            game.loadTeamB(teamB);
            Debug.WriteLine(teamA);
            Debug.WriteLine(teamB);
        }
    }
}
