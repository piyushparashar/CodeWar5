﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;
using WhiteWalkersGames.SourceEngine.Modules.Interfaces;
using WhiteWalkersGames.SourceEngine.Modules.Rules;

namespace WhiteWalkersGames.Providers.TankBattle
{
    [Export(typeof(IGame2))]
    public class TankBattleGame : IGame2
    {
        public TankBattleGame()
        {
            MapEntity mapEntityMine = new MapEntity
            {
                Description = "Mine",
                Icon = null,
                DisplayText = "X",
                ScoringWeight = -100,
            };
            MapEntity mapEntityTrench = new MapEntity
            {
                Description = "Trench",
                Icon = null,
                DisplayText = "T",
                ScoringWeight = -10,
            };
            MapEntity mapEntityEnemy = new MapEntity
            {
                Description = "Enemy Soldier",
                Icon = null,
                DisplayText = "ES",
                ScoringWeight = 10,
            };
            MapEntity mapEntityExit = new MapEntity
            {
                Description = "Exit",
                Icon = null,
                DisplayText = "Ex",
                ScoringWeight = 0,
                Multiplicity = MapEntityMultiplicity.Single
            };
            MapEntity mapEntityHill = new MapEntity
            {
                Description = "Hill",
                Icon = null,
                DisplayText = "H",
                ScoringWeight = -5,
            };


            Columns = 5;
            GameTitle = "Tank Buster";
            Rows = 5;
            MaxScore = 100;
            MoveScore = -5;
            MapEntities = new List<IMapEntity> { mapEntityMine, mapEntityHill, mapEntityExit, mapEntityEnemy, mapEntityTrench };
        }

        public List<IMapEntity> MapEntities { get; set; }

        public string GameTitle { get; set; }

        public List<IMoveEvaluator> MoveEvaluators { get; set; }

        public ushort Columns { get; set; }

        public ushort Rows { get; set; }

        public int MaxScore { get; set; }

        public int MoveScore { get; set; }
    }
}