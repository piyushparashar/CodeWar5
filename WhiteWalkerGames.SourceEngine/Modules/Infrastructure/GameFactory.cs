using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{

    public class PlayerMoveEventArgs
    {
        IMapEntity CurrentMapEntity { get; set; }

        int Score { get; set; }
    }

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
