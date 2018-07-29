using System.ComponentModel.Composition;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;
using WhiteWalkersGames.SourceEngine.Modules.Interfaces;

namespace WhiteWalkersGames.Providers.TankBattle
{
    public class TankBattleProvider : IGameProvider
    {
        public TankBattleProvider()
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

            DisplayConfiguration displayConfiguration = new DisplayConfiguration
            {
                Columns = 5,
                GameTitle = "Tank Buster",
                MapEntities = new System.Collections.Generic.List<IMapEntity> { mapEntityMine, mapEntityHill, mapEntityExit, mapEntityEnemy, mapEntityTrench },
                Rows = 5,
                MaxScore = 100,
                MoveScore = -5,
            };

            GameContext = new GameContext
            {
                DisplayConfiguration = displayConfiguration,
            };
        }

        public IGameContext GameContext { get; }
    }
}
