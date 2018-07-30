using System.Windows.Controls;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public class EmptyMapEnity : DataBoundMapEntity
    {
        public Image Icon => null;

        public string DisplayText => "";

        public string Description => "";

        public int ScoringWeight => 0;

        public MapEntityMultiplicity Multiplicity { get => MapEntityMultiplicity.Multiple ; set => throw new System.NotImplementedException(); }
    }
}
