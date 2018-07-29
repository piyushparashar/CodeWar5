using System.Collections.Generic;
using System.Windows.Controls;
using WhiteWalkersGames.SourceEngine.Modules.Rules;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public class GameContext : IGameContext
    {
        public GameContext()
        {
            //GameMode = GameMode.SinglePlayer;
        }

        public IInputConfiguration InputConfiguration { get; set; }

        public IDisplayConfiguration DisplayConfiguration { get; set; }

        public List<IMoveEvaluator> MoveEvaluators {get; set;}

        //public GameMode GameMode { get; set; }
    }
}
