using System.Collections.ObjectModel;

namespace WhiteWalkersGames.SourceEngine.Modules.Common
{
    /// <summary>
    /// Responsible for evaluating each move
    /// </summary>
    public interface IMoveEvaluator
    {
        MoveEvaluationResult EvaluateMove(IMoveEvaluatorContext moveEvaluatorContext);
    }

    public interface IMoveEvaluatorContext
    {
        int CurrentRow { get; set; }

        int CurrentColumn { get; set; }

        int NextRow { get; set; }

        int NextColumn { get; set; }

        RouteMap RouteMap { get; set; }

        ObservableCollection<ObservableCollection<IMapEntity>> FieldMap { get; set; }

        int CurrentScore { get; set; }
    }

    public class MoveEvaluationResult
    {
        public bool IsMovePossible { get; set; }

        public int EvaluatedScore { get; set; }
    }
}
