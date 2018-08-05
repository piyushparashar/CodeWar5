using WhiteWalkersGames.SourceEngine.Drivers.Display;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.SourceEngine.Modules.Game
{
    internal abstract class AbstractGameController : IGameController
    {
        protected IGameViewModel myGameViewModel;
        protected IDisplayAdapter myDisplayAdapter;

        internal AbstractGameController(IGameViewModel gameViewModel)
        {
            myGameViewModel = gameViewModel;
        }

        public virtual void StartGame()
        {
        }

        public virtual void InitializeGame(IGameControllerContext context)
        {
            myDisplayAdapter = myGameViewModel as IDisplayAdapter;
        }
    }
}
