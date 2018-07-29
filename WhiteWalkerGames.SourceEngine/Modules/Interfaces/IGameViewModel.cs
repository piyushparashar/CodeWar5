using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel
{
    public interface IGameViewModel : INotifyPropertyChanged
    {
        ObservableCollection<ObservableCollection<DataBoundMapEntity>> MapEntities { get; set; }

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
