using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public class GameFactory
    {
        public static IGameController CreateGameController(IGameContext gameContext)
        {
            return new GameController(gameContext);
        }
    }

    public enum MapEntityMultiplicity
    {
        Single,

        Multiple
    }
}
