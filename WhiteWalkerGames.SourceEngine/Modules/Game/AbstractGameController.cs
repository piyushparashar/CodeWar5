using System;
using WhiteWalkersGames.SourceEngine.Drivers.Display;
using WhiteWalkersGames.SourceEngine.Modules.Drivers.Display;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    internal abstract class AbstractGameController : IGameController
    {
        protected InputAdapter myInputAdapter;
        protected IGameViewModel myGameViewModel;
        protected IDisplayAdapter myDisplayAdapter;

        internal AbstractGameController(IGameControllerContext gameControllerContext)
        {
            myGameViewModel = new GameViewModel();

            myDisplayAdapter = new DisplayAdapter(myGameViewModel);
        }

        public virtual void StartGame()
        {
        }

        public IGameViewModel GetGameViewModel()
        {
            return myGameViewModel;
        }
       
    }
}
