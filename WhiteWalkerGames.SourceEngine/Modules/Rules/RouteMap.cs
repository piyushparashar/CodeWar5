using System.Collections.Generic;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.Rules
{
    internal class RouteMap
    {
        public RouteMap()
        {
            Steps = new List<RouteMapEntry>();
        }

        internal List<RouteMapEntry> Steps {get;set;}
    }

    internal class RouteMapEntry
    {
        internal int Row { get; set; }

        internal int Column { get; set; }

        internal IMapEntity MapEntity { get; set; }

        internal int Score { get; set; }
    }
}
