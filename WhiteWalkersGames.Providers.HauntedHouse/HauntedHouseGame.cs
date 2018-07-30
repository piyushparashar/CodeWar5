using System.Collections.Generic;
using System.ComponentModel.Composition;
using WhiteWalkersGames.SourceEngine.Modules.Common;

namespace WhiteWalkersGames.Providers.HauntedHouse
{
    [Export(typeof(IGame))]
    [ExportGameTitle("Haunted House")]
    public class HauntedHouseGame : IGame
    {
        public HauntedHouseGame()
        {
            MapEntity mapEntityMine = new MapEntity
            {
                Description = "Ghost",
                Icon = null,
                DisplayText = "G",
                ScoringWeight = -100,
                DistributionWeight = 1
            };
            MapEntity mapEntityTrench = new MapEntity
            {
                Description = "Zombie",
                Icon = null,
                DisplayText = "Z",
                ScoringWeight = -10,
                DistributionWeight = 3
            };
            MapEntity mapEntityEnemy = new MapEntity
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
            MapEntity mapEntityHill = new MapEntity
            {
                Description = "Wall",
                Icon = null,
                DisplayText = "W",
                ScoringWeight = -5,
                DistributionWeight = 1,
                IsMoveAllowedOnThis = false
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

        public IMoveEvaluator MoveEvaluators { get; set; }

        public ushort Columns { get; set; }

        public ushort Rows { get; set; }

        public int MaxScore { get; set; }

        public int MoveScore { get; set; }
    }
}
