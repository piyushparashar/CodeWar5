using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Game;
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

        private IGameProvider myGameProvider = new GameProvider();

        public GameHostWindow()
        {
            InitializeComponent();

            myGameProvider.LoadGames();

            IDictionary<string, IGame> myGames = myGameProvider.GetGames();

            myGameHost = GameControllerFactory.CreateGameController(new GameControllerContext
            {
                Game = myGames.Values.First(),
                GameMode = GameMode.SinglePlayer
            });

            IGameViewModel viewModel = myGameHost.GetGameViewModel();

            this.DataContext = viewModel;
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            myGameHost.StartGame();
        }
    }
}
