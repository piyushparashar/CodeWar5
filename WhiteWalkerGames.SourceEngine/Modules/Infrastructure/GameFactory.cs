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

        void Stop();
    }

    public interface IGameController
    {
        void StartGame();

        void RestartGame();

        void StopGame();
    }

    public class PlayerMoveEventArgs
    {
        IMapEntity CurrentMapEntity { get; set; }

        int Score { get; set; }
    }

    public interface IGameContext
    {
        Grid ParentControl { get; }

        IInputConfiguration InputConfiguration { get; }

        IDisplayConfiguration DisplayConfiguration { get; }

        bool IsTwoPlayer { get; }
    }

    public class GameContext : IGameContext
    {
        public GameContext()
        {
            IsTwoPlayer = false;
        }
        public Grid ParentControl { get; set; }

        public IInputConfiguration InputConfiguration { get; set; }

        public IDisplayConfiguration DisplayConfiguration { get; set; }

        public bool IsTwoPlayer { get; set; }
    }

    public class GameFactory
    {
        public static IGameController CreateGameController(IGameContext gameContext)
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

        int MaxScore { get; }

        int MoveScore { get; }
    }

    public class DisplayConfiguration : IDisplayConfiguration
    {
        public string GameTitle { get; set; }

        public List<IMapEntity> MapEntities { get; set; }

        public ushort Columns { get; set; }

        public ushort Rows { get; set; }

        public int MaxScore { get; set; }

        public int MoveScore { get; set; }
    }

    public interface IMapEntity
    {
        Image Icon { get; }

        string DisplayText { get; }

        string Description { get; }

        int ScoringWeight { get; }
        MapEntityMultiplicity Multiplicity { get; set; }
    }

    public class MapEntity : IMapEntity
    {
        public MapEntity()
        {
            Multiplicity = MapEntityMultiplicity.Multiple;
        }
        public Image Icon { get; set; }

        public string DisplayText { get; set; }

        public string Description { get; set; }

        public int ScoringWeight { get; set; }

        public MapEntityMultiplicity Multiplicity { get; set; }
    }

    public enum MapEntityMultiplicity
    {
        Single,

        Multiple
    }

    public interface IInputConfiguration
    {
        IInputElement InputElement { get; }
    }

    public class InputConfiguration : IInputConfiguration
    {
        public IInputElement InputElement { get; set; }
    }
}
