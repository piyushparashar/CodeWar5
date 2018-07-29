using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel
{

    internal class GameViewModel : IGameViewModel
    {
        private string myMessage;
        private string myHealth;
        private string myCustomScore;
        private string myScore;
        private List<string> myLegends;
        private string myGameTitle;
        private ObservableCollection<ObservableCollection<DataBoundMapEntity>> myMapEntities;

        internal GameViewModel()
        {
         
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string GameTitle
        {
            get { return myGameTitle; }
            set
            {
                myGameTitle = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<ObservableCollection<DataBoundMapEntity>> MapEntities
        {
            get
            {
                return myMapEntities;
            }
            set
            {
                myMapEntities = value;
                RaisePropertyChanged();
            }
        }

        public string Message
        {
            get
            {
                return myMessage;
            }
            set
            {
                myMessage = value;
                RaisePropertyChanged();
            }
        }

        public string Health
        {
            get
            {
                return myHealth;
            }
            set
            {
                myHealth = value;
                RaisePropertyChanged();
            }
        }

        public string CustomScore
        {
            get
            {
                return myCustomScore;
            }
            set
            {
                myCustomScore = value;
                RaisePropertyChanged();
            }
        }

        public string Score
        {
            get
            {
                return myScore;
            }
            set
            {
                myScore = value;
                RaisePropertyChanged();
            }
        }

        public List<string> Legends
        {
            get
            {
                return myLegends;
            }
            set
            {
                myLegends = value;
                RaisePropertyChanged();
            }
        }

        public Grid Canvas { get; }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }       
    }
}
