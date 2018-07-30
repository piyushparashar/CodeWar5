using WhiteWalkersGames.SourceEngine.Modules.Common;

namespace WhiteWalkersGames.SourceEngine.Modules.Rules
{
    internal interface IScoreEvaluator
    {
        MoveEvaluationResult EvaluateScore(IScoreEvaluationContext context);
    }

    internal class ScoreEvaluator : IScoreEvaluator
    {
        private int myMoveScore;

        public ScoreEvaluator(int moveScore)
        {
            myMoveScore = moveScore;
        }

        public MoveEvaluationResult EvaluateScore(IScoreEvaluationContext context)
        {
            MoveEvaluationResult result = new MoveEvaluationResult();
            var nextEntity = context.FieldMap[context.NextRow][ context.NextColumn];

            if (nextEntity.IsMoveAllowedOnThis)
            {
                result.IsMovePossible = true;

                result.EvaluatedScore = context.CurrentScore + nextEntity.ScoringWeight + myMoveScore;
            }
            else
            {
                result.IsMovePossible = false;
                result.EvaluatedScore = context.CurrentScore;
            }

            return result;
        }
    }
}
