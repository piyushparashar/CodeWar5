namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public interface IGameContext
    {
        IDisplayConfiguration DisplayConfiguration { get; }

        bool IsTwoPlayer { get; }
    }
}
