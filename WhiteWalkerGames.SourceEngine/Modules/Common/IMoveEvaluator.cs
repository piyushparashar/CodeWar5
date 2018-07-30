using System.Collections.Generic;

namespace WhiteWalkersGames.SourceEngine.Modules.Common
{
    /// <summary>
    /// Responsible for evaluating each move
    /// </summary>
    public interface IMoveEvaluator
    {
        MoveEvaluationResult EvaluateMove(IMoveEvaluatorContext moveEvaluatorContext);
    }

    public class MoveEvaluationResult
    {
        public bool IsMovePossible { get; set; }

        public int EvaluatedScore { get; set; }

        public List<(int Row, int Column, IMapEntity UpdatedEntity)> UpdatdEntities { get; set; }
    }
}
