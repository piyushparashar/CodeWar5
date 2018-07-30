using WhiteWalkersGames.SourceEngine.Drivers.Display;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.SourceEngine.Modules.Game
{
    internal abstract class AbstractGameController : IGameController
    {
        protected IGameViewModel myGameViewModel;
        protected IDisplayAdapter myDisplayAdapter;

        internal AbstractGameController()
        {
            myGameViewModel = new GameViewModel();
        }

        public virtual void StartGame()
        {
        }

        public IGameViewModel GetGameViewModel()
        {
            return myGameViewModel;
        }

        public virtual void InitializeGame(IGameControllerContext context)
        {
            myDisplayAdapter = new DisplayAdapter(myGameViewModel);
        }
    }
}
