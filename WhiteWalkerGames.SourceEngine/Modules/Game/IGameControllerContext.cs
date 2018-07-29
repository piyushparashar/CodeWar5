namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public interface IGameControllerContext
    {
        IGame Game { get; }

        GameMode GameMode { get; }
    }
}
