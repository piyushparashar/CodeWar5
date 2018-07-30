using System;
using System.ComponentModel.Composition;

namespace WhiteWalkersGames.SourceEngine.Modules.Common
{
    /// <summary>API:NO
    /// MetaData information provided by the game provider
    /// </summary>
    public interface IGameMetadata
    {
        /// <summary>
        /// Game title
        /// </summary>
        string GameTitle { get; }
    }

    /// <summary>API:YES
    /// Mandatory attribute to be exported by the game provider
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]

    public class ExportGameTitle : Attribute
    {
        /// <summary>API:YES
        /// Constructor which accepts the game title
        /// </summary>
        /// <param name="gameTitle"></param>
        public ExportGameTitle(string gameTitle)
        {
            GameTitle = gameTitle;
        }

        /// <summary>API:NO
        /// Game title
        /// </summary>
        public string GameTitle { get; }
    }
}
