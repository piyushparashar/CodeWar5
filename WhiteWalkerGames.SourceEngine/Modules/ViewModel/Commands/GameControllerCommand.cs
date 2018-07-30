using System;
using System.Windows.Input;
using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Game;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel.Commands
{
    internal interface IGameControllerCommand : ICommand
    {


    }
    internal class GameControllerCommand : IGameControllerCommand
    {
        private IGameController myGameController;

        public GameControllerCommand(IGameController gameController)
        {
            myGameController = gameController;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            IGame gameToStart = parameter as IGame;

            myGameController.InitializeGame(new GameControllerContext {
                Game = gameToStart,
                GameMode = GameMode.SinglePlayer
            });
        }
    }
}
