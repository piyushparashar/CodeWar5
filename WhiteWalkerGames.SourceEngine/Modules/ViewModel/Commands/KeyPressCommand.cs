using System;
using System.Windows.Input;
using WhiteWalkersGames.SourceEngine.Modules.Drivers.Display;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel.Commands
{
    class KeyPressCommand : ICommand
    {
        public KeyPressCommand(IInputAdapter inputAdapter)
        {
            myInputAdapter = inputAdapter;
        }

        public bool CanExecute(object parameter)
        {
            return myInputAdapter.IsInputEnabled;
        }

        public void Execute(object parameter)
        {
            KeyBinding keyBinding = parameter as KeyBinding;

            if (keyBinding != null)
            {

                myInputAdapter.FireKeyPressed(keyBinding.Key);
            }
        }

        public event EventHandler CanExecuteChanged;

        private IInputAdapter myInputAdapter;
    }
}
