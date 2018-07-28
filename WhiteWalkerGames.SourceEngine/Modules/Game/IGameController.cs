using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public interface IGameController
    {
        void StartGame();

        void RestartGame();

        void StopGame();

        IGameViewModel GetGameViewModel();
    }
}
