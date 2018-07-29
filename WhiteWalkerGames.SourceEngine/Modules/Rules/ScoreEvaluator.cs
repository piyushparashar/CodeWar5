using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.Rules
{
    internal interface IScoreEvaluator
    {
        MoveEvaluationResult EvaluateScore(IScoreEvaluationContext context);
    }

    internal interface IScoreEvaluationContext
    {
        int CurrentRow { get; set; }

        int CurrentColumn { get; set; }

        int NextRow { get; set; }

        int NextColumn { get; set; }

        IMapEntity[,] FieldMap { get; set; }

        RouteMap RouteMap { get; set; }

        int CurrentScore { get; set; }
    }

    internal class ScoreEvaluationContext : IScoreEvaluationContext
    {
        public int CurrentRow { get; set ; }
        public int CurrentColumn { get ; set ; }
        public int NextRow { get ; set ; }
        public int NextColumn { get ; set ; }
        public IMapEntity[,] FieldMap { get ; set ; }
        public RouteMap RouteMap { get ; set ; }
        public int CurrentScore { get ; set ; }
    }

    internal class RouteMap
    {
        public RouteMap()
        {
            Steps = new List<RouteMapEntry>();
        }

        internal List<RouteMapEntry> Steps {get;set;}
    }

    internal class RouteMapEntry
    {
        internal int Row { get; set; }

        internal int Column { get; set; }

        internal IMapEntity MapEntity { get; set; }

        internal int Score { get; set; }
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
            var nextEntity = context.FieldMap[context.NextRow, context.NextColumn];

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
