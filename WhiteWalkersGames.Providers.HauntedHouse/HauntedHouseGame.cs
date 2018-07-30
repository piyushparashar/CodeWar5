using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using WhiteWalkersGames.SourceEngine.Modules.Common;

namespace WhiteWalkersGames.Providers.HauntedHouse
{
    [Export(typeof(IGame))]
    [ExportGameTitle("Haunted House")]
    public class HauntedHouseGame : IGame
    {
        public HauntedHouseGame()
        {
            MapEntity mapEntityGhost = new MapEntity
            {
                Description = "Ghost",
                Icon = null,
                DisplayText = "G",
                ScoringWeight = -100,
                DistributionWeight = 1,
            };
            MapEntity mapEntityZombie = new MapEntity
            {
                Description = "Zombie",
                Icon = null,
                DisplayText = "Z",
                ScoringWeight = -10,
                DistributionWeight = 3,
            };
            MapEntity mapEntityWeapon = new MapEntity
            {
                Description = "Weapon",
                Icon = null,
                DisplayText = "X",
                ScoringWeight = 0,
                DistributionWeight = 2
            };
            MapEntity mapEntityExit = new MapEntity
            {
                Description = "Exit",
                Icon = null,
                DisplayText = "Ex",
                ScoringWeight = 0,
                Multiplicity = MapEntityMultiplicity.Single
            };
            MapEntity mapEntityWall = new MapEntity
            {
                Description = "Wall",
                Icon = null,
                DisplayText = "W",
                ScoringWeight = 0,
                DistributionWeight = 1,
                IsMoveAllowedOnThis = false
            };


            Columns = 5;
            GameTitle = "Haunted House Game";
            Rows = 5;
            MaxScore = 100;
            MoveScore = -5;
            MapEntities = new List<IMapEntity> { mapEntityGhost, mapEntityWall, mapEntityExit, mapEntityWeapon, mapEntityZombie };
            MoveEvaluator = new HauntedHouseGameMoveEvaluation();
        }

        public List<IMapEntity> MapEntities { get; set; }
        public IMoveEvaluator MoveEvaluator { get; set; }

        public string GameTitle { get; set; }

        public ushort Columns { get; set; }

        public ushort Rows { get; set; }

        public int MaxScore { get; set; }

        public int MoveScore { get; set; }
        public void Reset()
        {
            MoveEvaluator = new HauntedHouseGameMoveEvaluation();
        }
    }


    public class HauntedHouseGameMoveEvaluation : IMoveEvaluator
    {
        public MoveEvaluationResult EvaluateMove(IMoveEvaluatorContext moveEvaluatorContext)
        {
            var result = new MoveEvaluationResult();

            var nextEntity = moveEvaluatorContext.FieldMap[moveEvaluatorContext.NextRow][moveEvaluatorContext.NextColumn];

            if (nextEntity.IsMoveAllowedOnThis)
            {

                if (nextEntity.DisplayText == "X")
                {
                    if (!HasWeapon)
                    {
                        result.UpdatdEntities.Add((Row: moveEvaluatorContext.NextRow, Column: moveEvaluatorContext.NextColumn, UpdatedEntity: new MapEntity()));
                        HasWeapon = true;
                    }
                    result.EvaluatedScore = moveEvaluatorContext.CurrentScore;
                    result.IsMovePossible = true;
                }
                else if (nextEntity.DisplayText == "G" || nextEntity.DisplayText == "Z")
                {
                    if (HasWeapon)
                    {
                        result.UpdatdEntities.Add((Row: moveEvaluatorContext.NextRow, Column: moveEvaluatorContext.NextColumn, UpdatedEntity: new MapEntity()));
                        result.EvaluatedScore = nextEntity.DisplayText == "Z" ? moveEvaluatorContext.CurrentScore + 10 : moveEvaluatorContext.CurrentScore + 20;
                        HasWeapon = false;
                    }
                    else
                    {
                        result.EvaluatedScore = 0;
                    }
                    result.IsMovePossible = true;
                }
                else if (nextEntity.DisplayText == "Ex")
                {
                    result.IsMovePossible = true;
                    result.EvaluatedScore = moveEvaluatorContext.CurrentScore;
                    result.IsGameWon = true;
                }
                else if (nextEntity.DisplayText == "")
                {
                    result.IsMovePossible = true;
                    result.EvaluatedScore = moveEvaluatorContext.CurrentScore;
                }
            }
            else
            {
                if (nextEntity.DisplayText == "W")
                {
                    result.IsMovePossible = false;
                    result.EvaluatedScore = moveEvaluatorContext.CurrentScore;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            UpdateGhostLocation(moveEvaluatorContext, result);

            return result;
        }

        private void UpdateGhostLocation(IMoveEvaluatorContext moveEvaluatorContext, MoveEvaluationResult result)
        {
            if (!GhostLocations.Any())
            {
                //Find the ghost location
                for (int i = 0; i < moveEvaluatorContext.FieldMap.Count; i++)
                {
                    for (int j = 0; j < moveEvaluatorContext.FieldMap[i].Count; j++)
                    {
                        if (moveEvaluatorContext.FieldMap[i][j].DisplayText == "G")
                        {
                            GhostLocations.Add((Row: i, Column: j, MapEntity: moveEvaluatorContext.FieldMap[i][j]));
                        }
                    }
                }
            }
            else
            {
                var changedLocations = 0;
                for (int i = 0; i < moveEvaluatorContext.FieldMap.Count; i++)
                {
                    for (int j = 0; j < moveEvaluatorContext.FieldMap[i].Count; j++)
                    {
                        if (moveEvaluatorContext.FieldMap[i][j].DisplayText == "" && i != moveEvaluatorContext.NextRow &&
                            j != moveEvaluatorContext.NextColumn)
                        {

                            result.UpdatdEntities.Add((Row: i, Column: j, UpdatedEntity: GhostLocations[changedLocations].MapEntity));
                            result.UpdatdEntities.Add((Row: GhostLocations[changedLocations].Row, Column: GhostLocations[changedLocations].Column, UpdatedEntity: new MapEntity()));
                            GhostLocations[changedLocations] = (i, j, GhostLocations[changedLocations].MapEntity);
                            changedLocations++;
                            if (changedLocations == GhostLocations.Count)
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }

        internal bool HasWeapon { get; set; }
        internal List<(int Row, int Column, IMapEntity MapEntity)> GhostLocations { get; set; } = new List<(int Row, int Column, IMapEntity mapEntity)>();
    }

}
