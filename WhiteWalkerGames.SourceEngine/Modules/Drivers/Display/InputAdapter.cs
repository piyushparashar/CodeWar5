using System;
using System.Windows.Input;

namespace WhiteWalkersGames.SourceEngine.Modules.Drivers.Display
{
    internal interface IInputAdapter
    {
        void FireKeyPressed(Key key);

        void StopListening();

        void StartListening();

        bool IsInputEnabled { get; }
    }

    internal class InputAdapter : IInputAdapter
    {
        private bool isInputEnabled = false;

        public void FireKeyPressed(Key key)
        {

                InputReceived?.Invoke(new GameInputEventArgs(key));

        }

        public event Action<GameInputEventArgs> InputReceived;

        public void StartListening()
        {
            isInputEnabled = true;
        }

        public void StopListening()
        {
            isInputEnabled = false;
        }

        public bool IsInputEnabled => isInputEnabled;
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

