using System.Collections.ObjectModel;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.Rules
{
    internal interface IScoreEvaluationContext
    {
        int CurrentRow { get; set; }

        int CurrentColumn { get; set; }

        int NextRow { get; set; }

        int NextColumn { get; set; }

        ObservableCollection<ObservableCollection<DataBoundMapEntity>> FieldMap { get; set; }

        RouteMap RouteMap { get; set; }

        int CurrentScore { get; set; }
    }

    internal class ScoreEvaluationContext : IScoreEvaluationContext
    {
        public int CurrentRow { get; set; }
        public int CurrentColumn { get; set; }
        public int NextRow { get; set; }
        public int NextColumn { get; set; }
        public ObservableCollection<ObservableCollection<DataBoundMapEntity>> FieldMap { get; set; }
        public RouteMap RouteMap { get; set; }
        public int CurrentScore { get; set; }
    }
}
