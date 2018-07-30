using System.Collections.Generic;

namespace WhiteWalkersGames.SourceEngine.Modules.Common
{
    public interface IGame
    {
        string GameTitle { get; }

        List<IMapEntity> MapEntities { get; }

        IMoveEvaluator MoveEvaluators { get; set; }

        ushort Columns { get; }

        ushort Rows { get; }

        int MaxScore { get; }

        int MoveScore { get; }
    }
}
