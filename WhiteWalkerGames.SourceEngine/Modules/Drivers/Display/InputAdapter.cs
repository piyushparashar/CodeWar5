using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.Drivers.Display
{
    internal interface IInputAdapter
    {
        IInputElement InputElement { get; }

        void StopListening();

        void StartListening();
    }

    internal class InputAdapter : IInputAdapter
    {
        private IInputConfiguration myInputConfiguration;
        private bool isInputActive = false;

        internal InputAdapter(IInputConfiguration inputConfiguration)
        {
            myInputConfiguration = inputConfiguration;
            myInputConfiguration.InputElement.KeyDown += OnSourceKeyDown;
        }

        private void OnSourceKeyDown(object sender, KeyEventArgs e)
        {
            if (isInputActive)
            {
                InputReceived?.Invoke(new GameInputEventArgs(e.Key));
            }
        }

        public event Action<GameInputEventArgs> InputReceived;

        public System.Windows.IInputElement InputElement => myInputConfiguration.InputElement;

        public void StartListening()
        {
            isInputActive = true;
        }

        public void StopListening()
        {
            isInputActive = false;
        }
    }

    public class GameInputEventArgs
    {
        public System.Windows.Input.Key Input { get; }

        public GameInputEventArgs(Key inputKey)
        {
            Input = inputKey;
        }
    }


}

