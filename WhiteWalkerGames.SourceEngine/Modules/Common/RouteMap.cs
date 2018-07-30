using System.Collections.Generic;

namespace WhiteWalkersGames.SourceEngine.Modules.Common
{
    public class RouteMap
    {
        public RouteMap()
        {
            Steps = new List<RouteMapEntry>();
        }

        internal List<RouteMapEntry> Steps {get;set;}
    }

    public class RouteMapEntry
    {
        internal int Row { get; set; }

        internal int Column { get; set; }

        internal IMapEntity MapEntity { get; set; }

        internal int Score { get; set; }
    }
}
