using System.Windows.Controls;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public interface IMapEntity
    {
        Image Icon { get; }

        string DisplayText { get; }

        string Description { get; }

        int ScoringWeight { get; }

        ushort DistributionWeight { get; }

        MapEntityMultiplicity Multiplicity { get; set; }

        bool IsMoveAllowedOnThis { get; set; }
    }
}
