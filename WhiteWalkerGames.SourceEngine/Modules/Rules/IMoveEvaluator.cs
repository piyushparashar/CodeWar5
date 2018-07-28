using System.Collections.Generic;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.Rules
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

        List<IMapEntity> RouteMap { get; set; }

        int CurrentScore { get; set; }

        IDisplayExtension DisplayExtension { get; set; }
    }

    public class MoveEvaluationResult
    {
        public bool IsMovePossible { get; set; }

        public int EvaluatedScore { get; set; }
    }


    public interface IDisplayExtension
    {
        // void MoveMapEntityOnMap(IMapEntity)
    }

}
