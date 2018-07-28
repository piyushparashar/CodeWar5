using System.Collections.Generic;
using System.Windows.Controls;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public  interface IDisplayConfiguration
    {
        Grid ParentControl { get; }

        string GameTitle { get; }

        List<IMapEntity> MapEntities { get; }

        ushort Columns { get; }

        ushort Rows { get; }

        int MaxScore { get; }

        int MoveScore { get; }
    }
}
