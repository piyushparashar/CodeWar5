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
        private const string Mine = "X";
        private const string Hill = "H";
        private const string Trench = "T";
        private const string River = "R";
        private const string EnemySoldier = "S";
        private const string Exit = "E";

        private int myCurrentRow;
        private int myCurrentColumn;
        private double myScore;
        private int myHealth;
        private bool myGameOver = false;

        string[,] myField = new string[,]
          {
            {"", Hill, Mine, "", Trench},
            {Trench, "", "", EnemySoldier, ""},
            {Mine, EnemySoldier, Mine, "", Mine},
            {Hill, "", Hill, "", Trench},
            {River, EnemySoldier, "", "", Exit},
          };

        public SinglePlayerGame(IGameContext gameContext) : base(gameContext)
        {
            myInputAdapter.InputReceived += OnInputReceived;
        }

        public override void Start()
        {
            myDisplayAdapter.DisplayMessage("");
            myDisplayAdapter.DrawField(myField);

            myCurrentRow = 0;
            myCurrentColumn = 0;
            myDisplayAdapter.DrawSubject(myCurrentRow, myCurrentColumn);

            myGameOver = false;
            myScore = 100;
            myDisplayAdapter.DisplayScore(myScore);
        }

        private void OnInputReceived(GameInputEventArgs gameInputEventArgs)
        {

            if (gameInputEventArgs.Input == Key.Left)
            {
                myCurrentColumn--;
            }
            if (gameInputEventArgs.Input == Key.Right)
            {
                myCurrentColumn++;
            }
            if (gameInputEventArgs.Input == Key.Up)
            {
                myCurrentRow--;
            }
            if (gameInputEventArgs.Input == Key.Down)
            {
                myCurrentRow++;
            }

            myDisplayAdapter.DrawSubject(myCurrentRow, myCurrentColumn);

            myScore -= GetScore();
            myDisplayAdapter.DisplayScore(myScore);

            if (!myGameOver && myScore <= 0)
            {
                myDisplayAdapter.DisplayMessage("Game Over, you lost!!!");
                myGameOver = true;
            }
        }

        int GetScore()
        {
            if (string.IsNullOrEmpty(myField[myCurrentRow, myCurrentColumn]))
            {
                return 5;
            }
            else if (myField[myCurrentRow, myCurrentColumn] == Mine)
            {
                myDisplayAdapter.DisplayMessage("Game Over, you lost!!!");
                myGameOver = true;
            }
            else if (myField[myCurrentRow, myCurrentColumn] == Exit)
            {
                myDisplayAdapter.DisplayMessage("Game Over, you won!!!");
                myGameOver = true;
            }

            return 10;
        }
    }
}
