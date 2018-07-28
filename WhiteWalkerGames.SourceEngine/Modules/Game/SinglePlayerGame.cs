using System.Collections.Generic;
using System.Windows.Input;
using WhiteWalkersGames.SourceEngine.Modules.Drivers.Display;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    internal class SinglePlayerGame : AbstractGame
    {
        private int myCurrentRow;
        private int myNextRow;
        private int myCurrentColumn;
        private int myNextColumn;
        private double myScore;
        private int myHealth;
        private bool myGameOver = false;

        private IGameContext myGameContext;
        private ushort myRowsCount;
        private ushort myColumnsCount;

        private IMapEntity[,] myFieldMap;

        public SinglePlayerGame(IGameContext gameContext) : base(gameContext)
        {
            myInputAdapter.InputReceived += OnInputReceived;
            myGameContext = gameContext;
            myRowsCount = gameContext.DisplayConfiguration.Rows;
            myColumnsCount = gameContext.DisplayConfiguration.Columns;

            myFieldMap = new IMapEntity[myRowsCount, myColumnsCount];
        }

        public override void Start()
        {
            base.Start();
            myDisplayAdapter.DisplayMessage("");

            UpdateLegends();
            
            myDisplayAdapter.DrawField(myGameContext.DisplayConfiguration.MapEntities, myRowsCount, myColumnsCount, ref myFieldMap); 

            myCurrentRow = 0;
            myCurrentColumn = 0;
            myDisplayAdapter.DrawSubject(myCurrentRow, myCurrentColumn);

            myGameOver = false;
            myScore = 100;
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


            //After evaluation and scoring update the coordinates and display
            myCurrentColumn = myNextColumn;
            myCurrentRow = myNextRow;

            myDisplayAdapter.DrawSubject(myCurrentRow, myCurrentColumn);

            if (!myGameOver && myScore <= 0)
            {
                myDisplayAdapter.DisplayMessage("Game Over, you lost!!!");
                myGameOver = true;
                base.Stop();
            }
        }

        private bool AreCoordinatesValid(GameInputEventArgs gameInputEventArgs)
        {

            switch(gameInputEventArgs.Input)
            {
                case Key.Left:
                    if(myCurrentColumn == 0)
                    {
                        return false;
                    }
                    else
                    {
                        myNextColumn--;
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
                        myNextColumn++;
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
                        myNextRow--;
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
                        myNextRow++;
                        return true;
                    }
                    break;
            }
            return false;
        }
    }
}
