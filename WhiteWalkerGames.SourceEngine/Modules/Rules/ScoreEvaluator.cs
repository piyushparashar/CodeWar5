﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Model;

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
                    var moveEvaluatorContext = GetMoveEvaluatorContext(context);

                    var moveResult = myCustomEvaluator.EvaluateMove(moveEvaluatorContext);

                    if (moveResult.IsMovePossible)
                    {
                        result.EvaluatedScore = moveResult.EvaluatedScore + myMoveScore;
                    }
                    else
                    {
                        result.EvaluatedScore = context.CurrentScore;
                    }
                    result.IsMovePossible = moveResult.IsMovePossible;
                    result.IsGameWon = moveResult.IsGameWon;
                    result.UpdatdEntities = moveResult.UpdatdEntities;
                }
                else
                {
                    result.IsMovePossible = true;
                    result.EvaluatedScore = context.CurrentScore + nextEntity.ScoringWeight + myMoveScore;
                    if (nextEntity.DisplayText == "Ex")
                    {
                        result.IsGameWon = true;
                    }
                }
            }
            else
            {
                result.IsMovePossible = false;
                result.EvaluatedScore = context.CurrentScore;
            }

            if (result.UpdatdEntities.Any())
            {
                foreach ((int Row, int Column, IMapEntity UpdatedEntity) resultUpdatdEntity in result.UpdatdEntities)
                {
                    context.FieldMap[resultUpdatdEntity.Row][resultUpdatdEntity.Column] = new DataBoundMapEntity(resultUpdatdEntity.UpdatedEntity);
                }
            }

            return result;
        }

        private static MoveEvaluatorContext GetMoveEvaluatorContext(IScoreEvaluationContext context)
        {
            var fieldMap = new List<List<IMapEntity>>();

            foreach (ObservableCollection<DataBoundMapEntity> boundMapEntities in context.FieldMap)
            {
                fieldMap.Add(boundMapEntities.Cast<IMapEntity>().ToList());
            }

            var moveEvaluatorContext = new MoveEvaluatorContext()
            {
                CurrentColumn = context.CurrentColumn,
                CurrentRow = context.CurrentRow,
                CurrentScore = context.CurrentScore,
                NextColumn = context.NextColumn,
                NextRow = context.NextRow,
                FieldMap = fieldMap
            };
            return moveEvaluatorContext;
        }
    }
}
