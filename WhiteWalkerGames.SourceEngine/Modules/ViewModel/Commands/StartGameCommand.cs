/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;
using System.Windows.Input;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel.Commands
{
    internal class StartGameCommand : ICommand
    {
        internal StartGameCommand(IGameController gameController)
        {
            myGameController = gameController;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            myGameController?.StartGame();
        }

        public event EventHandler CanExecuteChanged;

        private IGameController myGameController;
    }
}
