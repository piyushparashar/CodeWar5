using System;
using System.Windows.Input;
using WhiteWalkersGames.SourceEngine.Drivers.Display;
using WhiteWalkersGames.SourceEngine.Modules.Drivers.Display;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    internal abstract class AbstractGame : IGame
    {
        protected InputAdapter myInputAdapter;
        private IGameViewModel myGameViewModel;
        protected IDisplayAdapter myDisplayAdapter;

        internal AbstractGame(IGameContext gameContext)
        {
            myGameViewModel = new GameViewModel(gameContext.DisplayConfiguration);

            myDisplayAdapter = new DisplayAdapter(myGameViewModel);

            myInputAdapter = new InputAdapter(gameContext.InputConfiguration);

           
        }

        public virtual void Restart()
        {
            //??
            //may be change the location of subject/player to original location and reset score
        }

        public virtual void Start()
        {
            myInputAdapter.StartListening();
        }

        public virtual void Stop()
        {
            myInputAdapter.StopListening();
        }

        public IGameViewModel GetViewModel()
        {
            return myGameViewModel;
        }
    }

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

            
            myDisplayAdapter.DrawField(myGameContext.DisplayConfiguration.MapEntities, myRowsCount, myColumnsCount, ref myFieldMap); // should use map entities to draw

            myCurrentRow = 0;
            myCurrentColumn = 0;
            myDisplayAdapter.DrawSubject(myCurrentRow, myCurrentColumn);

            myGameOver = false;
            myScore = 100;
            myDisplayAdapter.DisplayScore(myScore);
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
