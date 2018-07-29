using System;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public class DataBoundMapEntity : MapEntity
    {
        public Guid PlayerId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
