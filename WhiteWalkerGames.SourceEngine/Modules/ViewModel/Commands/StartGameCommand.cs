/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;
using System.Windows.Input;
using WhiteWalkersGames.SourceEngine.Modules.Game;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel.Commands
{
    internal class StartGameCommand : ICommand
    {
        internal StartGameCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            GameMode gameMode = (GameMode)parameter;

            IGameController gameController = GameControllerFactory.CreateGameController(gameMode);

            gameController.StartGame();
        }

        public event EventHandler CanExecuteChanged;

    }
}
