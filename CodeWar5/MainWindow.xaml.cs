using System.Windows;
using CodeWar5.GameEngine;
using CodeWar5.GameEngine.Drivers;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace CodeWar5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisplayContext
    {

        private IGameController myGameHost = null;

        public MainWindow()
        {
            InitializeComponent();

            MapEntity mapEntityMine = new MapEntity
            {
                Description = "Mine",
                Icon = null,
                DisplayText = "X",
                ScoringWeight = -100,
                DistributionWeight = 1
            };
            MapEntity mapEntityTrench = new MapEntity
            {
                Description = "Trench",
                Icon = null,
                DisplayText = "T",
                ScoringWeight = -10,
                DistributionWeight = 3
            };
            MapEntity mapEntityEnemy = new MapEntity
            {
                Description = "Enemy Soldier",
                Icon = null,
                DisplayText = "ES",
                ScoringWeight = 10,
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
                Description = "Hill",
                Icon = null,
                DisplayText = "H",
                ScoringWeight = -5,
                DistributionWeight = 1
            };

            DisplayConfiguration displayConfiguration = new DisplayConfiguration
            {
                Columns = 5,
                GameTitle = "Tank Buster",
                MapEntities = new System.Collections.Generic.List<IMapEntity> { mapEntityMine, mapEntityHill, mapEntityExit, mapEntityEnemy, mapEntityTrench },
                Rows = 5,
                MaxScore = 100,
                MoveScore = -5,
                ParentControl = myCanvas
            };

            IGameContext gameContext = new GameContext
            {
                DisplayConfiguration = displayConfiguration,
                InputConfiguration = new InputConfiguration { InputElement = this },
                IsTwoPlayer = false,
                ParentControl = this.myCanvas,
            };

            myGameHost = GameFactory.CreateGameController(gameContext);

            IGameViewModel viewModel = myGameHost.GetGameViewModel();

            this.DataContext = viewModel;
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            myGameHost.StartGame();
        }
    }
}
