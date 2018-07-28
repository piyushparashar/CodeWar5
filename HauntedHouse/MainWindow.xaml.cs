using System.Windows;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace HauntedHouse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGameController myGameHost = null;

        public MainWindow()
        {
            InitializeComponent();

            MapEntity mapEntityGhost = new MapEntity
            {
                Description = "Ghost",
                Icon = null,
                DisplayText = "G",
                ScoringWeight = -100,
                DistributionWeight = 1
            };
            MapEntity mapEntityZombie = new MapEntity
            {
                Description = "Zombie",
                Icon = null,
                DisplayText = "Z",
                ScoringWeight = -10,
                DistributionWeight = 3
            };
            MapEntity mapEntityWall = new MapEntity
            {
                Description = "Wall",
                Icon = null,
                DisplayText = "W",
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
         

            DisplayConfiguration displayConfiguration = new DisplayConfiguration
            {
                Columns = 5,
                GameTitle = "Haunted House",
                MapEntities = new System.Collections.Generic.List<IMapEntity> { mapEntityGhost, mapEntityExit, mapEntityWall, mapEntityZombie },
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
