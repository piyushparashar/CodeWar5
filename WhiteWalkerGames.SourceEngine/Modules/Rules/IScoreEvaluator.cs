using System.Collections.Generic;

namespace WhiteWalkersGames.SourceEngine.Modules.Rules
{
    /// <summary>
    /// Interface responsible for evaluating score
    /// </summary>
    internal interface IScoreEvaluator
    {
        int EvaluateScore(IScoreEvaluationContext scoreEvaluationContext);
    }

    internal interface IScoreEvaluationContext
    {
        int CurrentRow { get; set; }

        int CurrentColumn { get; set; }

        string GridCellAttribute { get; set; }
    }

    /// <summary>
    /// Responsible for loading rules
    /// </summary>
    internal interface IRulesLoader
    {
        void LoadRules(string directoryPath);
    }

    /// <summary>
    /// Responsible for creating map route
    /// </summary>
    internal interface IRouteMapCreator
    {
        string[,] GenerateMap(IMapGenerationContext mapGenerationContext);
    }


    internal interface IMapGenerationContext
    {
        int NumberOfPlayers { get; set; }

        IDictionary<string, int> ObjectToScoreMapping { get; set; }
    }
}
