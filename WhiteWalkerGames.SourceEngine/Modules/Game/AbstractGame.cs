using WhiteWalkersGames.SourceEngine.Drivers.Display;
using WhiteWalkersGames.SourceEngine.Modules.Drivers.Display;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    internal abstract class AbstractGame : IGame
    {
        protected InputAdapter myInputAdapter;
        protected IGameViewModel myGameViewModel;
        protected IDisplayAdapter myDisplayAdapter;

        internal AbstractGame(IGameContext gameContext)
        {
            myInputAdapter = new InputAdapter();

            myGameViewModel = new GameViewModel(gameContext.DisplayConfiguration, myInputAdapter);

            myDisplayAdapter = new DisplayAdapter(myGameViewModel);
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
}
