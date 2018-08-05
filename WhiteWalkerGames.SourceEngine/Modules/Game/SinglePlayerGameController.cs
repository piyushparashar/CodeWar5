using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;
using WhiteWalkersGames.SourceEngine.Modules.Model;
using WhiteWalkersGames.SourceEngine.Modules.Rules;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel.Commands;

namespace WhiteWalkersGames.SourceEngine.Modules.Game
{
    internal class SinglePlayerGameController : AbstractGameController
    {
        private int myCurrentRow;
        private int myNextRow;
        private int myCurrentColumn;
        private int myNextColumn;
        private int myScore;
        private int myHealth;
        private bool myGameOver = false;

        private IGameControllerContext myContext;
        private ushort myRowsCount;
        private ushort myColumnsCount;
        private IGame myGame;
        private ObservableCollection<ObservableCollection<DataBoundMapEntity>> myFieldMap;
        private RouteMap myRouteMap;
        private IScoreEvaluator myScoreEvaluator;
        private IKeyPressCommand myKeyPressCommand;

        public SinglePlayerGameController(IGameViewModel gameViewModel) : base(gameViewModel) 
        {

        }

        public override void InitializeGame(IGameControllerContext context)
        {
            Reset();

            base.InitializeGame(context);

            myGame = context.Game;
            myContext = context;
            myRowsCount = myGame.Rows;
            myColumnsCount = myGame.Columns;

            myFieldMap = new ObservableCollection<ObservableCollection<DataBoundMapEntity>>();

            myScoreEvaluator = new ScoreEvaluator(myGame.MoveScore, myGame.MoveEvaluator);
            myRouteMap = new RouteMap();

            myKeyPressCommand = myGameViewModel.KeyPressCommand;
            myKeyPressCommand.InputReceived += OnInputReceived;
        }

        private void Reset()
        {
            myKeyPressCommand.InputReceived -= OnInputReceived;
            myFieldMap.Clear();
        }

        public override void StartGame()
        {
            myKeyPressCommand.EnableEvents(true);
            myDisplayAdapter.DisplayMessage("");

            myDisplayAdapter.DisplayGameTitle(myGame.GameTitle);

            UpdateLegends();

            myDisplayAdapter.DrawField(myGame.MapEntities.ToList(), myRowsCount, myColumnsCount, ref myFieldMap);

            myCurrentRow = 0;
            myCurrentColumn = 0;

            myGameOver = false;
            myScore = myGame.MaxScore;
            myDisplayAdapter.DisplayScore(myScore);

        }

        private void UpdateLegends()
        {
            List<string> legends = new List<string>();
            foreach (IMapEntity mapEntity in myGame.MapEntities)
            {
                legends.Add($"{mapEntity.DisplayText}\t{mapEntity.Description}");
            }

            myGameViewModel.Legends = legends;
        }

        private void OnInputReceived(GameInputEventArgs gameInputEventArgs)
        {

            if (!AreCoordinatesValid(gameInputEventArgs))
            {
                return;
            }

            MoveEvaluationResult result = myScoreEvaluator.EvaluateScore(new ScoreEvaluationContext
            {
                CurrentColumn = myCurrentColumn,
                CurrentRow = myCurrentRow,
                CurrentScore = myScore,
                FieldMap = myFieldMap,
                NextColumn = myNextColumn,
                NextRow = myNextRow,
                RouteMap = myRouteMap,
            });

            if (result.IsMovePossible)
            {
                myScore = result.EvaluatedScore;

                myFieldMap[myCurrentRow][myCurrentColumn].IsActive = false;

                //After evaluation and scoring update the coordinates and display
                myCurrentColumn = myNextColumn;
                myCurrentRow = myNextRow;

                myFieldMap[myCurrentRow][myCurrentColumn].IsActive = true;

                myDisplayAdapter.DisplayScore(myScore);

                myRouteMap.Steps.Add(new RouteMapEntry
                {
                    Column = myCurrentColumn,
                    Row = myCurrentRow,
                    MapEntity = myFieldMap[myCurrentRow][myCurrentColumn],
                    Score = myScore
                });
            }

            if (result.IsGameWon)
            {
                myDisplayAdapter.DisplayScore(result.EvaluatedScore);
                myDisplayAdapter.DisplayMessage("You won!!");
                myGameOver = true;
                myGame.Reset();
                myKeyPressCommand.EnableEvents(false);
                return;
            }

            if (!myGameOver && myScore <= 0)
            {
                myDisplayAdapter.DisplayScore(0);
                myDisplayAdapter.DisplayMessage("Game Over, you lost!!!");
                myGameOver = true;
                myGame.Reset();
                myKeyPressCommand.EnableEvents(false);
            }
        }

        private bool AreCoordinatesValid(GameInputEventArgs gameInputEventArgs)
        {
            myNextColumn = myCurrentColumn;
            myNextRow = myCurrentRow;

            switch (gameInputEventArgs.Input)
            {
                case Key.Left:
                    if (myCurrentColumn == 0)
                    {
                        return false;
                    }
                    else
                    {
                        myNextColumn = myCurrentColumn - 1;
                        return true;
                    }
                    break;
                case Key.Right:
                    if (myCurrentColumn == myColumnsCount - 1)
                    {
                        return false;
                    }
                    else
                    {
                        myNextColumn = myCurrentColumn + 1;
                        return true;
                    }
                    break;
                case Key.Up:
                    if (myCurrentRow == 0)
                    {
                        return false;
                    }
                    else
                    {
                        myNextRow = myCurrentRow - 1;
                        return true;
                    }
                    break;
                case Key.Down:
                    if (myCurrentRow == myRowsCount - 1)
                    {
                        return false;
                    }
                    else
                    {
                        myNextRow = myCurrentRow + 1;
                        return true;
                    }
                    break;
            }
            return false;
        }
    }
}
