using WhiteWalkersGames.SourceEngine.Drivers.Display;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public class GameController : IGameController
    {
        private IGameContext myGameContext;
        private IGame myGame;

        public GameController(IGameContext gameContext)
        {
            myGameContext = gameContext;

            if (gameContext.IsTwoPlayer)
            {
                //two player game
            }
            else
            {
                myGame = new SinglePlayerGame(gameContext);
            }

        }

        public void RestartGame()
        {
            myGame.Start();
        }

        public void StartGame()
        {
            myGame.Start();

        }

        public void StopGame()
        {
            myGame.Stop();
        }

        public IGameViewModel GetGameViewModel() { return myGame.GetViewModel(); }
    }
}
