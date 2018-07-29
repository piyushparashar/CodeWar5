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

           // if (gameContext.GameMode == GameMode.Multiplayer)
            //{
            //    //two player game
            //}
            //else if(gameContext.GameMode == GameMode.SinglePlayer)
            //{
                myGame = new SinglePlayerGame(gameContext);
            //}
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
