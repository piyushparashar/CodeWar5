using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    internal interface IGameController
    {
        void StartGame();

        IGameViewModel GetGameViewModel();
    }
}
