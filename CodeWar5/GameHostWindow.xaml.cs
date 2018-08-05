using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Linq;
using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Game;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.Host
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameHostWindow : MetroWindow
    {

        private IGameProvider myGameProvider = new GameProvider();
        private IGameViewModel myGameViewModel = new GameViewModel();

        public GameHostWindow()
        {
            InitializeComponent();

            myGameProvider.LoadGames();

            IDictionary<string, IGame> myGames = myGameProvider.GetGames();

            if (myGames.Any())
            {
                GameControllerFactory.SetViewModel(myGameViewModel);

                myGameViewModel.Games = myGames;

                this.DataContext = myGameViewModel;
            }
        }
    }
}
