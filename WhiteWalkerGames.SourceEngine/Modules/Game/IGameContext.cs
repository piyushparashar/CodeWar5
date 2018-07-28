namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public interface IGameContext
    {
        IInputConfiguration InputConfiguration { get; }

        IDisplayConfiguration DisplayConfiguration { get; }

        bool IsTwoPlayer { get; }
    }
}
