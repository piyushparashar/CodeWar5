using System;
using System.Windows.Controls;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public class MapEntity : IMapEntity
    {
        public MapEntity()
        {
            Multiplicity = MapEntityMultiplicity.Multiple;
        }
        public Image Icon { get; set; }

        public string DisplayText { get; set; }

        public string Description { get; set; }

        public int ScoringWeight { get; set; }

        public MapEntityMultiplicity Multiplicity { get; set; }

        public ushort DistributionWeight {get;set;}

        public bool IsMoveAllowedOnThis { get; set; }
    }

    public class DataBoundMapEntity : MapEntity
    {
        public Guid PlayerId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }

    public class EmptyMapEnity : DataBoundMapEntity
    {
        public Image Icon => null;

        public string DisplayText => "";

        public string Description => "";

        public int ScoringWeight => 0;

        public MapEntityMultiplicity Multiplicity { get => MapEntityMultiplicity.Multiple ; set => throw new System.NotImplementedException(); }
    }
}
