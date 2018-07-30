#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using WhiteWalkersGames.SourceEngine.Modules.Common;
#endregion

namespace WhiteWalkersGames.SourceEngine.Modules.Game
{
    /// <summary>
    /// Responsible for loading games which has exported <see cref="IGame"/>
    /// </summary>
    internal interface IGameProvider
    {
        /// <summary>
        /// Loads games which has exported <see cref="IGame"/>
        /// </summary>
        void LoadGames();

        /// <summary>
        /// Gets games loaded
        /// </summary>
        /// <returns></returns>
        IDictionary<string, IGame> GetGames();

    }

    /// <summary>
    /// Implementation of <see cref="IGameProvider"/>
    /// </summary>
    internal class GameProvider : IGameProvider
    {
        #region Implementation of IGameProvider
        /// <summary>
        /// see <see cref="IGameProvider.LoadGames"/>
        /// </summary>
        public void LoadGames()
        {
            ComposablePartCatalog catalog = GetComposablePartCatalog();

            if (catalog == null)
            {
                return;
            }

            var container = new CompositionContainer(catalog);

            container.ComposeParts(this);
        }

        /// <summary>
        /// see <see cref="IGameProvider.GetGames"/>
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, IGame> GetGames()
        {
            var games = new Dictionary<string, IGame>();

            foreach (Lazy<IGame, IGameMetadata> game in myGamesFromComposition)
            {
                games.Add(game.Metadata.GameTitle, game.Value);
            }

            return games;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Returns the AggregateCatalog containing AssemblyCatalogs for the plugin assemblies with search pattern
        /// </summary>
        /// <returns></returns>
        private ComposablePartCatalog GetComposablePartCatalog()
        {
            var aggregateCatalog = new AggregateCatalog();

            var directoryCatalog = new DirectoryCatalog(ExtensionDirectory, ExtensionSearchPattern);

            aggregateCatalog.Catalogs.Add(directoryCatalog);


            return aggregateCatalog;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Dlls search pattern
        /// </summary>
        internal string ExtensionSearchPattern => "WhiteWalkersGames.Providers.*.dll";

        #endregion Properties

        #region Fields

        [ImportMany(typeof(IGame))]
        private IEnumerable<Lazy<IGame, IGameMetadata>> myGamesFromComposition;
        /// <summary>
        /// Directory path of games application extension
        /// </summary>
        private static string ExtensionDirectory => Environment.ExpandEnvironmentVariables(PluginPath);

        /// <summary>
        /// Extensions path
        /// </summary>
        private const string PluginPath = "C:\\TEMP";

        #endregion Fields
    }
}

