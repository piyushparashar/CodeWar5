namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public class GameControllerContext : IGameControllerContext
    {
        public IGame Game {get;set;}

        public GameMode GameMode { get; set; }
    }
}
