using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WhiteWalkersGames.SourceEngine.Drivers.Display;
using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Game;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;
using WhiteWalkersGames.SourceEngine.Modules.Model;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel.Commands;

namespace WhiteWalkersGames.SourceEngine.Modules.ViewModel
{

    internal class GameViewModel : IGameViewModel, IDisplayAdapter
    {
        private string myMessage;
        private string myHealth;
        private string myCustomScore;
        private string myScore;
        private List<string> myLegends;
        private string myGameTitle;
        private ObservableCollection<ObservableCollection<DataBoundMapEntity>> myMapEntities;
        private IDictionary<string, IGame> myGames;
        private GameMode myGameMode;

        internal GameViewModel()
        {
            KeyPressCommand = new KeyPressCommand();

            GameControllerCommand = new GameControllerCommand();

            StartGameCommand = new StartGameCommand();
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

        public IDictionary<string, IGame> Games
        {
            get => myGames;
            set
            {
                myGames = value;

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

        private IGameController myGameController;

        public KeyPressCommand KeyPressCommand { get; set; }

        public GameControllerCommand GameControllerCommand { get; set; }

        public StartGameCommand StartGameCommand { get; set; }

        public GameMode GameMode
        {
            get => myGameMode;
            set
            {
                myGameMode = value;
            }
        }

        #region IDisplayAdapter Implementation

        public void DisplayHealth(int health)
        {
            Health = "Health: " + health;
        }

        public void DisplayLegends(string[] legends)
        {
            Legends = legends.ToList();
        }

        public void DrawField(List<IMapEntity> mapEntities, int totalRows, int totalColumns, ref ObservableCollection<ObservableCollection<DataBoundMapEntity>> fieldMap)
        {
            fieldMap.Clear();

            Dictionary<IMapEntity, int> countMapping = new Dictionary<IMapEntity, int>();

            mapEntities.ForEach(entity => countMapping.Add(entity, 0));

            Random random = new Random();
            int mapEntityToPick = 0;
            int lastEntityPicked = 0;
            int totalEntitiesTypes = mapEntities.Count;

            ObservableCollection<DataBoundMapEntity> rowMapEntities = new ObservableCollection<DataBoundMapEntity>();
            for (int x = 0; x < totalColumns; x++)
            {
                rowMapEntities = new ObservableCollection<DataBoundMapEntity>();

                for (int y = 0; y < totalRows; y++)
                {

                    DataBoundMapEntity content = new EmptyMapEnity();

                    if (!(x == 0 && y == 0))
                    {
                        lastEntityPicked = mapEntityToPick;

                        do
                        {
                            mapEntityToPick = random.Next(0, mapEntities.Count + 3);

                        } while (lastEntityPicked == mapEntityToPick);

                        lastEntityPicked = mapEntityToPick;

                        if (mapEntityToPick < mapEntities.Count)
                        {
                            var entityToCopy = mapEntities.ElementAt(mapEntityToPick);

                            int entityAddCount = countMapping[entityToCopy];

                            if ((entityToCopy.Multiplicity == MapEntityMultiplicity.Multiple || entityAddCount < 1))
                            {
                                while (entityToCopy.Multiplicity != MapEntityMultiplicity.Single && !IsCountUnderDistributionWeight(entityAddCount, entityToCopy.DistributionWeight, totalRows * totalColumns))
                                {
                                    var tempMapEntityIndex = random.Next(0, mapEntities.Count);
                                    var tempEntity = mapEntities.ElementAt(tempMapEntityIndex);
                                    if (lastEntityPicked == tempMapEntityIndex || tempEntity.Multiplicity == MapEntityMultiplicity.Single)
                                    {
                                        continue;
                                    }
                                    entityToCopy = tempEntity;
                                    entityAddCount = countMapping[entityToCopy];
                                    mapEntityToPick = tempMapEntityIndex;
                                };

                                content = new DataBoundMapEntity(entityToCopy)
                                {
                                    Row = y,
                                    Column = x,
                                };

                                if (!IsCountUnderDistributionWeight(countMapping[entityToCopy] + 1, entityToCopy.DistributionWeight, totalRows * totalColumns))
                                {
                                    countMapping.Remove(entityToCopy);
                                    mapEntities.Remove(entityToCopy);
                                }
                                else
                                {
                                    countMapping[entityToCopy]++;
                                }
                            }
                        }
                    }
                    else
                    {
                        content.IsActive = true;
                    }


                    rowMapEntities.Add(content);
                }

                fieldMap.Add(rowMapEntities);
            }

            MapEntities = fieldMap;
        }

        public void DisplayScore(int score)
        {
            Score = $"Score: {score}";
        }

        public void DisplayMessage(string message)
        {
            Message = message;
        }

        public void DisplayGameTitle(string title)
        {
            GameTitle = title;
        }

        #endregion

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool IsCountUnderDistributionWeight(int entityAddCount, int distributionWeight, int totalCells)
        {
            return (distributionWeight == 0) || entityAddCount < (distributionWeight * totalCells / 10);
        }
    }
}
