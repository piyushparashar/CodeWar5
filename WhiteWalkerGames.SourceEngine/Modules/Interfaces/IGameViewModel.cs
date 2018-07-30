using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WhiteWalkersGames.SourceEngine.Modules.Common;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel
{
    internal interface IGameViewModel : INotifyPropertyChanged
    {
        ObservableCollection<ObservableCollection<IMapEntity>> MapEntities { get; set; }

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

        string GameTitle
        { get; set; }

    }
}
