using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WhiteWalkersGames.SourceEngine.Modules.Infrastructure
{
    public interface IGame
    {
        void Start();

        void Restart();
    }

    public interface IGameHost
    {
        void CreateGame(IGameContext context);

        void StartGame();

        void RestartGame();


    }

    public interface IGameContext
    {
        ContentControl ParentControl { get; }

        IInputConfiguration InputConfiguration { get; }

        IDisplayConfiguration DisplayConfiguration { get; }

        bool IsTwoPlayer { get; }
    }

    public class GameFactory
    {
        IGameHost CreateGameHost()
        {
            return null;
        }
    }

    public interface IDisplayConfiguration
    {
        string GameTitle { get; }

        List<IMapEntity> MapEntities { get; }

        ushort Columns { get; }

        ushort Rows { get; }
    }

    public interface IMapEntity
    {
        Image Icon { get; }

        string DisplayText { get; }

        string Description { get; }

        int ScoringWeight { get; }
    }


    public interface IInputConfiguration
    {
        IInputElement InputElement { get; }
    }
}
