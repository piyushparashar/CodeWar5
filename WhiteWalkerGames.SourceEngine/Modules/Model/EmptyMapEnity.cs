using System.Windows.Controls;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public class EmptyMapEnity : DataBoundMapEntity
    {
        public override Image Icon => null;

        public override string DisplayText => "";

        public override string Description => "";

        public override int ScoringWeight => 0;

        public override MapEntityMultiplicity Multiplicity { get => MapEntityMultiplicity.Multiple ; set => throw new System.NotImplementedException(); }
    }
}
