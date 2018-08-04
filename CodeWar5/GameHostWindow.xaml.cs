using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Game;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel.Commands;

namespace WhiteWalkersGames.Host
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameHostWindow : MetroWindow
    {

        private IGameController myGameHost = null;

        private IGameProvider myGameProvider = new GameProvider();

        public GameHostWindow()
        {
            InitializeComponent();

            myGameProvider.LoadGames();

            IDictionary<string, IGame> myGames = myGameProvider.GetGames();

            if (myGames.Any())
            {
                myGameHost = GameControllerFactory.CreateGameController(GameMode.SinglePlayer);
            }

            IGameViewModel viewModel = myGameHost.GetGameViewModel();

            viewModel.Games = myGames;

            viewModel.GameControllerCommand = new GameControllerCommand(myGameHost);

            viewModel.StartGameCommand = new StartGameCommand(myGameHost);

            this.DataContext = viewModel;
        }
    }
}
