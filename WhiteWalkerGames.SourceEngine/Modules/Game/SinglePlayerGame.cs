using System.Collections.Generic;
using System.Windows.Input;
using WhiteWalkersGames.SourceEngine.Modules.Drivers.Display;
using WhiteWalkersGames.SourceEngine.Modules.Rules;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    internal class SinglePlayerGame : AbstractGame
    {
        private int myCurrentRow;
        private int myNextRow;
        private int myCurrentColumn;
        private int myNextColumn;
        private int myScore;
        private int myHealth;
        private bool myGameOver = false;

        private IGameContext myGameContext;
        private ushort myRowsCount;
        private ushort myColumnsCount;

        private IMapEntity[,] myFieldMap;
        private RouteMap myRouteMap;
        private IScoreEvaluator myScoreEvaluator;

        public SinglePlayerGame(IGameContext gameContext) : base(gameContext)
        {
            myInputAdapter.InputReceived += OnInputReceived;
            myGameContext = gameContext;
            myRowsCount = gameContext.DisplayConfiguration.Rows;
            myColumnsCount = gameContext.DisplayConfiguration.Columns;

            myFieldMap = new IMapEntity[myRowsCount, myColumnsCount];

            myScoreEvaluator = new ScoreEvaluator(gameContext.DisplayConfiguration.MoveScore);
            myRouteMap = new RouteMap();
        }

        public override void Start()
        {
            base.Start();
            myDisplayAdapter.DisplayMessage("");

            myDisplayAdapter.DisplayGameTitle(myGameContext.DisplayConfiguration.GameTitle);

            UpdateLegends();
            
            myDisplayAdapter.DrawField(myGameContext.DisplayConfiguration.MapEntities, myRowsCount, myColumnsCount, ref myFieldMap); 

            myCurrentRow = 0;
            myCurrentColumn = 0;
            myDisplayAdapter.DrawSubject(myCurrentRow, myCurrentColumn);

            myGameOver = false;
            myScore = myGameContext.DisplayConfiguration.MaxScore;
            myDisplayAdapter.DisplayScore(myScore);
            
        }

        private void UpdateLegends()
        {
            List<string> legends = new List<string>();
            foreach (IMapEntity mapEntity in myGameContext.DisplayConfiguration.MapEntities)
            {
                legends.Add($"{mapEntity.DisplayText}\t{mapEntity.Description}");
            }

            myGameViewModel.Legends = legends;
        }

        private void OnInputReceived(GameInputEventArgs gameInputEventArgs)
        {

            if(!AreCoordinatesValid(gameInputEventArgs))
            {
                return;
            }

            //Do scoring
            //Evaluate what is th score
            //If possible to move ?
            //Yes 
            //Is score > 0 
            //YES


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

            if(result.IsMovePossible)
            {
                myScore = result.EvaluatedScore;
                
                //After evaluation and scoring update the coordinates and display
                myCurrentColumn = myNextColumn;
                myCurrentRow = myNextRow;

                myDisplayAdapter.DrawSubject(myCurrentRow, myCurrentColumn);
                myDisplayAdapter.DisplayScore(myScore);
                myRouteMap.Steps.Add(new RouteMapEntry
                {
                    Column = myCurrentColumn,
                    Row = myCurrentRow,
                    MapEntity = myFieldMap[myCurrentRow, myCurrentColumn],
                    Score = myScore
                });
            }

            if (!myGameOver && myScore <= 0)
            {
                myDisplayAdapter.DisplayScore(0);
                myDisplayAdapter.DisplayMessage("Game Over, you lost!!!");
                myGameOver = true;
               
                base.Stop();
            }
        }

        private bool AreCoordinatesValid(GameInputEventArgs gameInputEventArgs)
        {
            myNextColumn = myCurrentColumn;
            myNextRow = myCurrentRow;

            switch(gameInputEventArgs.Input)
            {
                case Key.Left:
                    if(myCurrentColumn == 0)
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
                        myNextRow = myCurrentRow  - 1;
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
