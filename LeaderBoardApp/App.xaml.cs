using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using LeaderBoardApp.AppLog;
using LeaderBoardApp.Enum;
using LeaderBoardApp.Exceptions;
using LeaderBoardApp.ModalControl;
using LeaderBoardApp.Tabs;
using LeaderBoardApp.Utility;
using LeaderBoardApp.Windows;

namespace LeaderBoardApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// This is the main controller for the leaderboard application
    /// Written By: Brendan Russo, Andrew Martini and Alex Lakh 
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
        public const string DEFAULT_MESSAGE = "Please Stand By";
        public const int DEFAULT_MIN = 5;
        public const int DEFAULT_SEC = 0;
        private int teamAID;
        private int teamBID;
        private Ladder ladder;
        private MatchResult matchSelected;
        private int currentMatchID;

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

        #region SETUP
       

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
            WireStandByMessage();
            WireViewTabHandlers();
            WireLadderTabHanders();
        }

        #endregion

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
                      if (gameState.Equals(GameState.WAITING) || gameState.Equals(GameState.FINISHED))
                        {
                            if (liveMatch.GetMatchType().Equals(MatchType.General))
                            {
                                liveMatch.LoadTeamComboBox(fileHandler.GetTeams());
                                liveMatch.EnableGenericButton();
                            }
                            else if (liveMatch.GetMatchType().Equals(MatchType.Ladder)) 
                            {
                                liveMatch.DisableGenericButton();
                            }
                        }
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

        private void CheckWindow()
        {
            if (!projectionWindow.IsWindowVisible())
            {
                projectionWindow = new ProjectionWindow();
                LoadDisplays();
                projectionWindow.Show();
            }
        }

        private void HandleSideMenuControlStandBy_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Stand By");
            CheckWindow();
            changeProjector(ProjectorState.STAND_BY);
        }

        private void HandleSideMenuControlLadder_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Ladder");
            CheckWindow();
            changeProjector(ProjectorState.LADDER);
        }

        private void HandleSideMenuControlLiveMatch_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Live Match");
            CheckWindow();
            changeProjector(ProjectorState.LIVE_MATCH);
        }

        private void changeProjector(ProjectorState ps)
        {
            projectorState = ps;
            mainWindow.ChangeDisplay(ps);
            projectionWindow.ChangeDisplay(ps);
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
            if (addPlayer.GetButtonAction().Equals(ButtonAction.DONE))
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
            if (addTeam.GetButtonAction().Equals(ButtonAction.DONE))
            {
                var newTeam = addTeam.GetTeam();
                fileHandler.InsertTeam(newTeam);
            }
        }

        private void HandleEditPlayer_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Edit Player");
            var players = fileHandler.GetPlayers();
            var editPlayers = new PlayerSelectEdit(fileHandler);
            ModalDisplay.ShowModal(editPlayers, mainWindow);
            /*foreach (var playerID in editPlayers.GetPlayersIDSelected())
            {
                fileHandler.UpdatePlayer(players[playerID]);
            }*/
        }

        private void HandleEditTeam_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Edit Team");
            var teams = fileHandler.GetTeams();
            var players = fileHandler.GetPlayers();
            var editTeams = new TeamSelectEdit(fileHandler);
            ModalDisplay.ShowModal(editTeams, mainWindow);
            /*  foreach (var teamID in editTeams.GetEditedTeamsID())
              {
                  teams[teamID].SetTeamID(teamID);
                  fileHandler.UpdateTeam(teams[teamID]);
              }*/
        }

        private void HandleDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Delete Player");
            var deletePlayers = new PlayerSelectDelete(fileHandler);
            ModalDisplay.ShowModal(deletePlayers, mainWindow);
            /*var playersToDelete = deletePlayers.GetPlayersIDSelected();
            var oldPlayers = fileHandler.GetPlayers();
            foreach (var playerID in playersToDelete)
            {
                fileHandler.DeletePlayer(playerID);
            }*/
        }

        private void HandleDeleteTeam_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("Delete Team");
            var oldTeam = fileHandler.GetTeams();
            var deleteTeams = new TeamSelectDelete(fileHandler);
            ModalDisplay.ShowModal(deleteTeams, mainWindow);
            /*  var teamsToDelete = deleteTeams.GetDeletedTeams();
              foreach (var teamID in teamsToDelete)
              {
                  fileHandler.DeleteTeam(teamID);
              }*/
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
            liveMatch.AddGenericMatchHandler(HandleGenericMatch_Click);
        }

        private void GameTimer_Tick(object sender, ElapsedEventArgs e)
        {
            if (game.CountDown())
            {
                GameOver();
            }
            else
            {
                UpdateTime();
            }
        }

        private void GameOver()
        {
            PauseGame();
        }

        private void StartGame()
        {
            changeProjector(ProjectorState.LIVE_MATCH);

            teamAID = liveMatch.GetTeamA();
            teamBID = liveMatch.GetTeamB();

            liveMatch.MatchInProgress();
            liveMatch.DisableTimeInput();
            liveMatch.DisableGenericButton();
            Team fullTeamA;
            Team fullTeamB;

            List<string> teamAPlayers = fileHandler.GetPlayersFirstName(teamAID);
            List<string> teamBPlayers = fileHandler.GetPlayersFirstName(teamBID);
            if (liveMatch.GetMatchType().Equals(MatchType.Generic))
            {
                fullTeamA = liveMatch.GetGenericTeamGreen();
                fullTeamB = liveMatch.GetGenericTeamOrange();
                teamAID = -1;
                teamBID = -2;
                teamAPlayers = new List<string>();
                teamBPlayers = new List<string>();
            }
            else
            {
                fullTeamA = fileHandler.GetTeam(teamAID);
                fullTeamB = fileHandler.GetTeam(teamBID);
            }

            var teamA = new GameTeam { ID = teamAID, teamContact = fullTeamA.GetTeamContact(), teamName = fullTeamA.GetTeamName(), teamPlayers = teamAPlayers };
            var teamB = new GameTeam { ID = teamBID, teamContact = fullTeamB.GetTeamContact(), teamName = fullTeamB.GetTeamName(), teamPlayers = teamBPlayers };
           
            SetTeamsProjectorGame(teamA, teamB);
            game.NewGame();
            GetTime();
            gameTimer.Start();

            UpdateTime();
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
            var box = MessageBox.Show("Do you want to end the match", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (box == MessageBoxResult.Yes)
            {
                gameTimer.Stop();
                MatchResult mr;
                log.ButtonPress("End Game");
                if (liveMatch.GetMatchType().Equals(MatchType.Ladder))
                {
                    mr = game.GetMatchResult(teamAID, teamBID, currentMatchID);
                    var scoreA = GetScores(game.GetTeamAFlag(), game.GetTeamATag());
                    var scoreB = GetScores(game.GetTeamBFlag(), game.GetTeamBTag());
                    if (scoreA.GetScore() != scoreB.GetScore())
                    {
                        var lv = mainWindow.ladderView;
                        lv.SetResult(scoreA, scoreB);
                        try
                        {
                            fileHandler.AddMatchResult(mr);
                            ladder.MatchPlayed(mr.GetMatchID(), mr);
                        }
                        catch (TournamentWinnerException)
                        {
                            ShowWinner(ladder.GetTournamentWinnerID());
                        }
                        lv.SetMatches(ladder.GetAllMatches());
                        mainWindow.ChangeLadder();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    mr = game.GetMatchResult(teamAID, teamBID);
                }
                liveMatch.NoMatchInProgress();
                gameState = GameState.WAITING;
                ResetGame();
            }
        }

        private void ShowWinner(int winner)
        {
            var team = fileHandler.GetTeam(winner);
            var message = string.Format("Congratulations {0} you are the winners of this tournament", team.GetTeamName());
            var winnerBox = MessageBox.Show(message);
        }

        private Score GetScores(int flag, int tag)
        {
            var score = new Score();
            score.SetFlag(flag);
            score.SetTag(tag);
            return score;
        }

        private void HandleGenericMatch_Click(object sender, RoutedEventArgs e)
        {
            GenericMatch();
        }

        private void GenericMatch()
        {
            if (!liveMatch.GetMatchType().Equals(MatchType.Generic))
            {
                liveMatch.SetMatchType(MatchType.Generic);
                liveMatch.GenericMatch();
            }
            else
            {
                liveMatch.SetMatchType(MatchType.General);
                liveMatch.LoadTeamComboBox(fileHandler.GetTeams());
            }
        }

        private void HandleResetGame_Click(object sender, RoutedEventArgs e)
        {
            var box = MessageBox.Show("Do you want to reset the match", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (box == MessageBoxResult.Yes)
            {
                log.ButtonPress("Reset Game");
                liveMatch.NoMatchInProgress();
                gameState = GameState.WAITING;
                ResetGame();
            }
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
                        UpdateTime();
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

            //Improve this at some point
            game.SetMin(DEFAULT_MIN);
            game.SetMin(DEFAULT_SEC);
            liveMatch.SetTime(DEFAULT_MIN, DEFAULT_SEC);
            liveMatch.EnableTimeInput();
            liveMatch.SetStartPause(gameState);
            projectionWindow.ResetScoreBoard(DEFAULT_MIN, DEFAULT_SEC);
            mainWindow.projectorLiveMatch.ResetScoreBoard(DEFAULT_MIN, DEFAULT_SEC);
            liveMatch.ResetLiveMatch();
            liveMatch.EnableGenericButton();
        }

        private void ResumeGame()
        {
            liveMatch.DisableTimeInput();
            GetTime();
            gameTimer.Start();
        }

        private void PauseGame()
        {
            gameState = GameState.PAUSED;
            liveMatch.SetStartPause(gameState);
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
            PauseGame();
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
            PauseGame();
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

        #region StandByMessage

        private void WireStandByMessage()
        {
            mainWindow.AddBtnDefaultStandByMessageHandler(HandleBtnDefaultStandByMessage_Click);
            mainWindow.AddBtnSetStandByMessageHandler(HandleBtnSetStandByMessage_Click);
        }

        private void HandleBtnDefaultStandByMessage_Click(object sender, RoutedEventArgs e)
        {
            var message = DEFAULT_MESSAGE;
            SetStandByMessage(message);
        }

        private void HandleBtnSetStandByMessage_Click(object sender, RoutedEventArgs e)
        {
            var message = mainWindow.GetStandByMessage();
            SetStandByMessage(message);
        }

        private void SetStandByMessage(string message)
        {
            mainWindow.SetStandByMessage(message);
            projectionWindow.SetStandByMessage(message);
        }

        #endregion

        #region ViewTab

        private void WireViewTabHandlers()
        {
            mainWindow.AddViewPlayerHandler(HandleBtnViewPlayer_Click);
            mainWindow.AddTeamPlayerHander(HandlerBtnViewTeam_Click);
        }

        private void HandlerBtnViewTeam_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("View Team");
            var viewTeam = new TeamSelectView(fileHandler);
            ModalDisplay.ShowModal(viewTeam, mainWindow);
        }

        private void HandleBtnViewPlayer_Click(object sender, RoutedEventArgs e)
        {
            log.ButtonPress("View Player");
            var viewPlayer = new PlayerSelectView(fileHandler);
            ModalDisplay.ShowModal(viewPlayer, mainWindow);
        }
        #endregion

        #region LadderTab
        private void WireLadderTabHanders()
        {
            var ladder = mainWindow.ladderView;
            ladder.AddLadderGenerateHandler(HandleBtnLadderGenerate_Click);
            ladder.AddLadderDoubleClick(HandleListView_DoubleClick);
        }

        private void HandleBtnLadderGenerate_Click(object sender, RoutedEventArgs e)
        {
            var modal = new NameLadder();
            modal.SetOwner(mainWindow);
            modal.ShowDialog();
            var action = modal.GetButtonAction();
            if (action.Equals(ButtonAction.DONE))
            {
                var name = modal.GetName();
                var teams = fileHandler.GetTeams().Values;
                MatchResult.SetTeams(fileHandler.GetTeams());
                var teamIDs = new List<int>();
                foreach (var team in teams)
                {
                    teamIDs.Add(team.GetTeamID());
                }                
                ladder = new Ladder(teamIDs);
                ladder.SetLadderName(name);
                ladder.GenerateLadder();
                var matches = ladder.GetMatches();
                var ladderTab = mainWindow.ladderView;
                fileHandler.SaveLadder(ladder);
                ladderTab.SetMatches(matches);
            }
        }

        private void HandleListView_DoubleClick(object sender, RoutedEventArgs e)
        {
            var ladderTab = mainWindow.ladderView;
            try
            {
                matchSelected = ladderTab.GetTeamsSelectedTeam();
                if (!matchSelected.GetPlayed())
                {
                    currentMatchID = matchSelected.GetMatchID();
                    liveMatch.SetMatchType(MatchType.Ladder);
                    LaunchGame(matchSelected);
                }
            }
            catch (NoGameSelectedException)
            {
                Console.WriteLine("No game selected");
            }
        }
        #endregion

        private void LaunchGame(MatchResult matchPlayed)
        {
            //Have to clear the scores
            var liveMatchTab = mainWindow.liveMatch;
            mainWindow.ChangeLiveMatch();
            liveMatchTab.SetPlayed(matchPlayed);
        }
    }
}