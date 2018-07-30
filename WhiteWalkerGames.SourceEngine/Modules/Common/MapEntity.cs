using System.Windows.Controls;

namespace WhiteWalkersGames.SourceEngine.Modules.Common
{
    public class MapEntity : IMapEntity
    {
        public MapEntity()
        {
            Multiplicity = MapEntityMultiplicity.Multiple;
            IsMoveAllowedOnThis = true;
            DisplayText = "";
        }
        public Image Icon { get; set; }

        public string DisplayText { get; set; }

        public string Description { get; set; }

        public int ScoringWeight { get; set; }

        public MapEntityMultiplicity Multiplicity { get; set; }

        public ushort DistributionWeight { get; set; }

        public bool IsMoveAllowedOnThis { get; set; }
    }
}
