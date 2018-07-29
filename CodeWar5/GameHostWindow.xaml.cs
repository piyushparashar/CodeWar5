using System.Windows;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.Host
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameHostWindow : Window
    {

        private IGameController myGameHost = null;

        public GameHostWindow()
        {
            InitializeComponent();

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
                ParentControl = myCanvas
            };

            IGameContext gameContext = new GameContext
            {
                DisplayConfiguration = displayConfiguration,
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
