using System.Collections.ObjectModel;
using WhiteWalkersGames.SourceEngine.Modules.Common;

namespace WhiteWalkersGames.SourceEngine.Modules.Rules
{
    internal interface IScoreEvaluationContext : IMoveEvaluatorContext
    {
       
    }

    internal class ScoreEvaluationContext : IScoreEvaluationContext
    {
        public int CurrentRow { get; set; }
        public int CurrentColumn { get; set; }
        public int NextRow { get; set; }
        public int NextColumn { get; set; }
        public ObservableCollection<ObservableCollection<IMapEntity>> FieldMap { get; set; }
        public RouteMap RouteMap { get; set; }
        public int CurrentScore { get; set; }
    }
}
