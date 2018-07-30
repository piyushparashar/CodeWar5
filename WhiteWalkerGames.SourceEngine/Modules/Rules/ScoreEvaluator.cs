using WhiteWalkersGames.SourceEngine.Modules.Common;

namespace WhiteWalkersGames.SourceEngine.Modules.Rules
{
    internal interface IScoreEvaluator
    {
        MoveEvaluationResult EvaluateScore(IScoreEvaluationContext context);
    }

    internal class ScoreEvaluator : IScoreEvaluator
    {
        private readonly int myMoveScore;
        private readonly IMoveEvaluator myCustomEvaluator;

        public ScoreEvaluator(int moveScore, IMoveEvaluator customMoveEvaluator)
        {
            myMoveScore = moveScore;
            myCustomEvaluator = customMoveEvaluator;
        }

        public MoveEvaluationResult EvaluateScore(IScoreEvaluationContext context)
        {
            MoveEvaluationResult result = new MoveEvaluationResult();

            var nextEntity = context.FieldMap[context.NextRow][context.NextColumn];

            if (nextEntity.IsMoveAllowedOnThis)
            {
                if (myCustomEvaluator != null)
                {
                    var moveResult = myCustomEvaluator.EvaluateMove(context);

                    if (moveResult.IsMovePossible)
                    {
                        result.EvaluatedScore = context.CurrentScore + nextEntity.ScoringWeight + myMoveScore;
                    }
                    else
                    {
                        result.EvaluatedScore = context.CurrentScore;
                    }
                    result.IsMovePossible = moveResult.IsMovePossible;
                }
                else
                {
                    result.IsMovePossible = true;
                    result.EvaluatedScore = context.CurrentScore + nextEntity.ScoringWeight + myMoveScore;
                }
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
