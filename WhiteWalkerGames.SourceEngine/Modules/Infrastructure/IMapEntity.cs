using System.Windows.Controls;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public interface IMapEntity
    {
        Image Icon { get; }

        string DisplayText { get; }

        string Description { get; }

        int ScoringWeight { get; }
        MapEntityMultiplicity Multiplicity { get; set; }
    }
}
