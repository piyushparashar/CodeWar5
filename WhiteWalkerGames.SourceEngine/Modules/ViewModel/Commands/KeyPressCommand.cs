using System;
using System.Windows.Input;
using WhiteWalkersGames.SourceEngine.Modules.Game;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel.Commands
{
    internal interface IKeyPressCommand : ICommand
    {
        event Action<GameInputEventArgs> InputReceived;

        void EnableEvents(bool enable);

    }
    internal class KeyPressCommand : IKeyPressCommand
    {
        private bool myIsInvokationEnabled;

        public event Action<GameInputEventArgs> InputReceived;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            KeyBinding keyBinding = parameter as KeyBinding;
            if (keyBinding != null && myIsInvokationEnabled)
            {
                InputReceived?.Invoke(new GameInputEventArgs(keyBinding.Key));
            }
        }

        public void EnableEvents(bool enable)
        {
            myIsInvokationEnabled = enable;
        }

        public event EventHandler CanExecuteChanged;
    }
}