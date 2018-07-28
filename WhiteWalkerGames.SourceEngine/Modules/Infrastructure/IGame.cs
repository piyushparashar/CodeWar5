using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public interface IGame
    {
        void Start();

        void Restart();

        void Stop();

        IGameViewModel GetViewModel();
    }
}
