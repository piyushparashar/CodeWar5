using System.Collections.Generic;
using WhiteWalkersGames.SourceEngine.Modules.Rules;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public interface IGame
    {
        string GameTitle { get; }

        List<IMapEntity> MapEntities { get; }

        List<IMoveEvaluator> MoveEvaluators { get; set; }

        ushort Columns { get; }

        ushort Rows { get; }

        int MaxScore { get; }

        int MoveScore { get; }
    }
}
