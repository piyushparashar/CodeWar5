using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.Game
{
    internal class GameControllerFactory
    {
        internal static IGameController CreateGameController(GameMode gameMode)
        {
            if(gameMode == GameMode.SinglePlayer)
            {
                return new SinglePlayerGameController();
            }
            return new SinglePlayerGameController();
        }
    }
}
