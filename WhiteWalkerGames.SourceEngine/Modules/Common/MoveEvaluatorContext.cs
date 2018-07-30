using System.Collections.Generic;

namespace WhiteWalkersGames.SourceEngine.Modules.Common
{
    public interface IMoveEvaluatorContext : IEvaluationContext
    {
        List<List<IMapEntity>> FieldMap { get; }
    }

    public class MoveEvaluatorContext : IMoveEvaluatorContext
    {
        public int CurrentRow { get; set; }
        public int CurrentColumn { get; set; }
        public int NextRow { get; set; }
        public int NextColumn { get; set; }
        public RouteMap RouteMap { get; set; }
        public int CurrentScore { get; set; }
        public List<List<IMapEntity>> FieldMap { get; set; }
    }
}