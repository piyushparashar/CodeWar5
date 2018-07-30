using System.Windows.Input;

namespace WhiteWalkersGames.SourceEngine.Modules.Game
{
    public class GameInputEventArgs
    {
        public System.Windows.Input.Key Input { get; }

        public GameInputEventArgs(Key inputKey)
        {
            Input = inputKey;
        }
    }
}
