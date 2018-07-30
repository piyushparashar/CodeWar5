using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public class GameFactory
    {
        public static IGameController CreateGameController(IGameControllerContext gameControllerContext)
        {
            if(gameControllerContext.GameMode == GameMode.SinglePlayer)
            {
                return new SinglePlayerGameController(gameControllerContext);
            }
            return new SinglePlayerGameController(gameControllerContext);
        }
    }
}
