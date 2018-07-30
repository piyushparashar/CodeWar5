using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.Game
{
    internal class GameControllerContext : IGameControllerContext
    {
        public IGame Game {get;set;}

        public GameMode GameMode { get; set; }
    }
}
