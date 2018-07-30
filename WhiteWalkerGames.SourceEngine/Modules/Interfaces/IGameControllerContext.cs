using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Game;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    internal interface IGameControllerContext
    {
        IGame Game { get; }

        GameMode GameMode { get; }
    }
}
