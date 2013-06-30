using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using LeaderBoardApp.AppLog;
using LeaderBoardApp.Enum;
using LeaderBoardApp.ModalControl;
using LeaderBoardApp.ProjectorDisplay;
using LeaderBoardApp.Tabs;
using LeaderBoardApp.Utility;
using LeaderBoardApp.Windows;

namespace LeaderBoardApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MainWindow mainWindow;
        public ProjectionWindow projectionWindow;
        public FileHandler fileHandler;
        public AL log;
        public ProjectorState projectorState;
        public LiveMatch liveMatch;
        public GameState gameState;
        public Game game;
        public SelectedTab selectedTab;
        public List<ScoreDisplay> displays;
        public Timer gameTimer;
        public int TIMER_INTERVAL = 1000;

        public App()
            : base()
        {
            log = new ConsoleAL();
            mainWindow = new MainWindow();
            projectionWindow = new ProjectionWindow();            
            game = new Game();
            displays = new List<ScoreDisplay>();
            projectorState = ProjectorState.STAND_BY;
            gameState = GameState.WAITING;
            liveMatch = mainWindow.liveMatch;
            selectedTab = mainWindow.GetSelectedTab();

            log.StartLog();

            SetupTimer();
            LoadDisplays();
            LoadFileHandler();
            WireHandlers();
            projectionWindow.Show();
            mainWindow.Show();
        }

        private void SetupTimer()
        {
            gameTimer = new Timer();
            gameTimer.Elapsed += GameTimer_Tick;
            gameTimer.Interval = TIMER_INTERVAL;
        }

        private void LoadDisplays()
        {
            displays.Add(mainWindow.projectorLiveMatch);
            displays.Add(projectionWindow.projectorLiveMatch);
            displays.Add(mainWindow);
            UpdateScores();
        }

        private void LoadFileHandler()
        {
            fileHandler = new MOCKFileHandler();
            fileHandler.LoadPlayers();
            fileHandler.LoadTeams();
        }

        private void WireHandlers()
        {
            WireTabSelection();
            WireSideMenu();
            WireRegistraionTab();
            WireLiveMatch();
        }



        #region MainWindowTabSelection

        private void WireTabSelection()
        {
            mainWindow.AddTabControl(HandleTab_SelectionChange);
        }

        private void HandleTab_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            if (!selectedTab.Equals(mainWindow.GetSelectedTab()))
            {
                selectedTab = mainWindow.GetSelectedTab();
                var liveMatch = mainWindow.liveMatch;
                log.TabSelect(selectedTab.ToString());
                switch (selectedTab)
                {
                    case SelectedTab.LIVE_MATCH:
                        liveMatch.LoadTeamComboBox(fileHandler.GetTeams());
                        break;
                }
            }
            
        }
        #endregion

        #region SideMenuSelection

        private void WireSideMenu()
        {
            mainWindow.AddSideMenuControlLiveMatch(HandleSideMenuControlLiveMatch_Click);
            mainWindow.AddSideMenuControlLadder(HandleSideMenuControlLadder_Click);
            mainWindow.AddSideMenuControlStandBy(HandleSideMenuControlStandBy_Click);
        }

        private void HandleSideMenuControlStandBy_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Stand By");
            projectorState = ProjectorState.STAND_BY;
            mainWindow.ChangeDisplay(projectorState);
            projectionWindow.ChangeDisplay(projectorState);
        }

        private void HandleSideMenuControlLadder_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Ladder");
            projectorState = ProjectorState.LADDER;
            mainWindow.ChangeDisplay(projectorState);
            projectionWindow.ChangeDisplay(projectorState);
        }

        private void HandleSideMenuControlLiveMatch_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Live Match");
            projectorState = ProjectorState.LIVE_MATCH;
            mainWindow.ChangeDisplay(projectorState);
            projectionWindow.ChangeDisplay(projectorState);
        }
        #endregion

        #region RegistraionTab

        private void WireRegistraionTab()
        {
            var regMenu = mainWindow.regMenu;
            regMenu.AddNewPlayerHandler(HandleNewPlayer_Click);
            regMenu.AddNewTeamHandler(HandleNewTeam_Click);
            regMenu.AddEditPlayerHandler(HandleEditPlayer_Click);
            regMenu.AddEditTeamHandler(HandleEditTeam_Click);
            regMenu.AddDeletePlayerHandler(HandleDeletePlayer_Click);
            regMenu.AddDeleteTeamHandler(HandleDeleteTeam_Click);
        }

        private void HandleNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Add Player");
            var addPlayer = new PlayerAdd();
            ModalDisplay.ShowModal(addPlayer, mainWindow);
            if (addPlayer.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                var newPlayer = addPlayer.GetPlayer();
                fileHandler.InsertPlayer(newPlayer);
                Debug.WriteLine(newPlayer.Details());
            }
        }

        private void HandleNewTeam_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Add Team");
            var addTeam = new TeamAdd(fileHandler);
            ModalDisplay.ShowModal(addTeam, mainWindow);
            if (addTeam.GetButtonAction().Equals(ButtonAction.CONFIRM))
            {
                var newTeam = addTeam.GetTeam();
                fileHandler.InsertTeam(newTeam);
            }
        }

        private void HandleEditPlayer_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Edit Player");
            var players = fileHandler.GetPlayers();
            var editPlayers = new PlayerSelectEdit(players);
            ModalDisplay.ShowModal(editPlayers, mainWindow);
            foreach (var playerID in editPlayers.GetPlayersIDSelected())
            {
                fileHandler.UpdatePlayer(players[playerID]);
            }
        }

        private void HandleEditTeam_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Edit Team");
            var teams = fileHandler.GetTeams();
            var players = fileHandler.GetPlayers();
            var editTeams = new TeamSelectEdit(fileHandler);
            ModalDisplay.ShowModal(editTeams, mainWindow);
            foreach (var teamID in editTeams.GetEditedTeamsID())
            {
                teams[teamID].SetTeamID(teamID);
                fileHandler.UpdateTeam(teams[teamID]);
            }
        }

        private void HandleDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Delete Player");
            var deletePlayers = new PlayerSelectDelete(fileHandler.GetPlayers());
            ModalDisplay.ShowModal(deletePlayers, mainWindow);
            var playersToDelete = deletePlayers.GetPlayersIDSelected();
            var oldPlayers = fileHandler.GetPlayers();
            foreach (var playerID in playersToDelete)
            {
                fileHandler.DeletePlayer(playerID);
            }
        }

        private void HandleDeleteTeam_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Delete Team");
            var oldTeam = fileHandler.GetTeams();
            var deleteTeams = new TeamSelectDelete(fileHandler);
            ModalDisplay.ShowModal(deleteTeams, mainWindow);
            var teamsToDelete = deleteTeams.GetDeletedTeams();
            foreach (var teamID in teamsToDelete)
            {
                fileHandler.DeleteTeam(teamID);
            }
        }

        #endregion

        #region LiveMatchTab

        private void WireLiveMatch()
        {
            liveMatch.NoMatchInProgress();
            liveMatch.AddEndGameHandler(HandleEndGame_Click);
            liveMatch.AddResetHandler(HandleResetGame_Click);
            liveMatch.AddStartPauseHandler(HandleStartPause_Click);
            liveMatch.AddTeamAFlagMinusHandler(HandleTeamAFlagMinus_Click);
            liveMatch.AddTeamAFlagPlusHandler(HandleTeamAFlagPlus_Click);
            liveMatch.AddTeamATagMinusHandler(HandleTeamATagMinus_Click);
            liveMatch.AddTeamATagPlusHandler(HandleTeamATagPlus_Click);
            liveMatch.AddTeamBFlagMinusHandler(HandleTeamBFlagMinus_Click);
            liveMatch.AddTeamBFlagPlusHandler(HandleTeamBFlagPlus_Click);
            liveMatch.AddTeamBTagMinusHandler(HandleTeamBTagMinus_Click);
            liveMatch.AddTeamBTagPlusHandler(HandleTeamBTagPlus_Click);
        }

        private void GameTimer_Tick(object sender, ElapsedEventArgs e)
        {
            if (game.CountDown())
            {
               // GameOver();
            }
            else
            {
                UpdateTime();
            }
        }

        private void StartGame()
        {
            var teamAID = liveMatch.GetTeamA();
            var teamBID = liveMatch.GetTeamB();

                liveMatch.MatchInProgress();
                liveMatch.DisableTimeInput();
                var fullTeamA = fileHandler.GetTeam(teamAID);
                var fullTeamB = fileHandler.GetTeam(teamBID);
                var teamA = new GameTeam { ID = teamAID, teamContact = fullTeamA.GetTeamContact(), teamName = fullTeamA.GetTeamName(), teamPlayers = fileHandler.GetPlayersFirstName(teamAID) };
                var teamB = new GameTeam { ID = teamBID, teamContact = fullTeamB.GetTeamContact(), teamName = fullTeamB.GetTeamName(), teamPlayers = fileHandler.GetPlayersFirstName(teamBID) };
                SetTeamsProjectorGame(teamA, teamB);
                game.NewGame();
                GetTime();
                gameTimer.Start();

                log.GameTeam(teamA, "A");
                log.GameTeam(teamB, "B");
            log.TeamAID(teamAID);
            log.TeamBID(teamBID);
        }

        private void GetTime()
        {
            game.SetMin(liveMatch.GetMin());
            game.SetSec(liveMatch.GetSec());
        }

        private void SetTeamsProjectorGame(GameTeam teamA, GameTeam teamB)
        {
            foreach (var display in displays)
            {
                display.SetTeamA(teamA);
                display.SetTeamB(teamB);
            }
        }

        private void UpdateTime()
        {
            foreach (var display in displays)
            {
                display.SetTime(game.GetMin(), game.GetSec());
            }
        }
        private void UpdateScores()
        {
            foreach (var display in displays)
            {
                display.SetTeamAFlag(game.GetTeamAFlag());
                display.SetTeamAScore(game.GetTeamAScore());
                display.SetTeamATag(game.GetTeamATag());
                display.SetTeamBFlag(game.GetTeamBFlag());
                display.SetTeamBScore(game.GetTeamBScore());
                display.SetTeamBTag(game.GetTeamBTag());                
            }
        }

        private void HandleEndGame_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("End Game");
            liveMatch.NoMatchInProgress();
            gameState = GameState.WAITING;
            ResetGame();
        }

        private void HandleResetGame_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Reset Game");
            liveMatch.NoMatchInProgress();
            gameState = GameState.WAITING;
            ResetGame();
        }

        private void HandleStartPause_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Start/Pause");
            if (liveMatch.ValidTime())
            {
                switch (gameState)
                {
                    case GameState.WAITING:
                        if (UniqueTeams())
                        {
                            StartGame();
                            gameState = GameState.IN_PROGRESS;
                        }
                        break;
                    case GameState.PAUSED:
                        ResumeGame();
                        gameState = GameState.IN_PROGRESS;
                        break;
                    case GameState.IN_PROGRESS:
                        PauseGame();
                        gameState = GameState.PAUSED;
                        break;
                    case GameState.FINISHED:
                        gameState = GameState.OVERTIME;
                        break;
                }
                liveMatch.SetStartPause(gameState);
            }
        }

        private bool UniqueTeams()
        {
            return liveMatch.GetTeamA() != liveMatch.GetTeamB();
        }

        private void ResetGame()
        {
            game.NewGame();
            liveMatch.EnableTimeInput();
            liveMatch.SetStartPause(gameState);
            UpdateScores();
        }

        private void ResumeGame()
        {
            liveMatch.DisableTimeInput();
            GetTime();
            gameTimer.Start();
        }

        private void PauseGame()
        {
            liveMatch.EnableTimeInput();
            gameTimer.Stop();            
        }

        private void HandleTeamAFlagMinus_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Team A Flag Minus");
            game.TeamAMinusFlag();
            UpdateScores();
        }

        private void HandleTeamAFlagPlus_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Team A Flag Plus");
            game.TeamAaddFlag();
            UpdateScores();
        }

        private void HandleTeamATagMinus_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Team A Tag Minus");
            game.TeamAMinusTag();
            UpdateScores();
        }

        private void HandleTeamATagPlus_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Team A Tag Plus");
            game.TeamAaddTag();
            UpdateScores();
        }

        private void HandleTeamBFlagMinus_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Team B Flag Minus");
            game.TeamBMinusFlag();
            UpdateScores();
        }

        private void HandleTeamBFlagPlus_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Team B Flag Plus");
            game.TeamBaddFlag();
            UpdateScores();
        }

        private void HandleTeamBTagMinus_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Team B Tag Minus");
            game.TeamBMinusTag();
            UpdateScores();
        }

        private void HandleTeamBTagPlus_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Team B Tag Plus");
            game.TeamBaddTag();
            UpdateScores();
        }

        #endregion
    }
}
