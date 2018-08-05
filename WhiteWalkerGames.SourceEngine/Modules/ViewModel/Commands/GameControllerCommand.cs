using System;
using System.Windows.Input;
using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Game;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel.Commands
{
   
    internal class GameControllerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            IGameControllerContext context = parameter as IGameControllerContext;
            IGameController gameController = GameControllerFactory.CreateGameController(context.GameMode);

            gameController.InitializeGame(context);
        }
    }
}
