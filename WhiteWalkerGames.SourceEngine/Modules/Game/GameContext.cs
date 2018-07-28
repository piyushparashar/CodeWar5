using System.Windows.Controls;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public class GameContext : IGameContext
    {
        public GameContext()
        {
            IsTwoPlayer = false;
        }
        public Grid ParentControl { get; set; }

        public IInputConfiguration InputConfiguration { get; set; }

        public IDisplayConfiguration DisplayConfiguration { get; set; }

        public bool IsTwoPlayer { get; set; }
    }
}
