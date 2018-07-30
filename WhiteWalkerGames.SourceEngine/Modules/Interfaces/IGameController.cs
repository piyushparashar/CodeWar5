using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    internal interface IGameController
    {
        void InitializeGame(IGameControllerContext context);

        void StartGame();

        IGameViewModel GetGameViewModel();
    }
}
