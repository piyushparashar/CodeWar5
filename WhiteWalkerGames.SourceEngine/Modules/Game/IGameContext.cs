using System.Collections.Generic;
using WhiteWalkersGames.SourceEngine.Modules.Rules;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public interface IGameContext
    {
        IInputConfiguration InputConfiguration { get; }

        IDisplayConfiguration DisplayConfiguration { get; }

        List<IMoveEvaluator> MoveEvaluators { get; }
    }

    public enum GameMode
    {
        SinglePlayer,

        Multiplayer,

        MultiplayerRemote
    }
}
