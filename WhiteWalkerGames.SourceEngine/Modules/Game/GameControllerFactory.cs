using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.Game
{
    internal class GameControllerFactory
    {
        internal static IGameController CreateGameController(IGameControllerContext gameControllerContext)
        {
            if(gameControllerContext.GameMode == GameMode.SinglePlayer)
            {
                return new SinglePlayerGameController(gameControllerContext);
            }
            return new SinglePlayerGameController(gameControllerContext);
        }
    }
}
