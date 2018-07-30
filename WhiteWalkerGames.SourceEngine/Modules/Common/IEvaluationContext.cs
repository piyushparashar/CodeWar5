namespace WhiteWalkersGames.SourceEngine.Modules.Common
{
    public interface IEvaluationContext
    {
        int CurrentRow { get; set; }

        int CurrentColumn { get; set; }

        int NextRow { get; set; }

        int NextColumn { get; set; }

        RouteMap RouteMap { get; set; }

        int CurrentScore { get; set; }
    }
}
