using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel
{
    public interface IGameViewModel : INotifyPropertyChanged
    {
        string Message
        {
            get;
            set;
        }

        string Health
        {
            get;
            set;
        }

        string CustomScore
        {
            get;
            set;
        }

        string Score
        {
            get;
            set;
        }

        List<string> Legends
        {
            get;
            set;
        }

        Grid Canvas { get; }
    }
}
