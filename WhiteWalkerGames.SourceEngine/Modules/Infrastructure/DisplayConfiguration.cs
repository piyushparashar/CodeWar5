using System.Collections.Generic;
using System.Windows.Controls;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public class DisplayConfiguration : IDisplayConfiguration
    {
        public string GameTitle { get; set; }

        public List<IMapEntity> MapEntities { get; set; }

        public ushort Columns { get; set; }

        public ushort Rows { get; set; }

        public int MaxScore { get; set; }

        public int MoveScore { get; set; }

        public Grid ParentControl { get; set; }
    }
}
