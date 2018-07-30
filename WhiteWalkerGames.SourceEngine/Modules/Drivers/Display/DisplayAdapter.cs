/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Model;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;

namespace WhiteWalkersGames.SourceEngine.Drivers.Display
{
    internal interface IDisplayAdapter
    {
        void DrawField(List<IMapEntity> mapEntities, int rows, int colunms, ref ObservableCollection<ObservableCollection<DataBoundMapEntity>> fieldMap);

        void DisplayScore(int score);

        void DisplayMessage(string message);

        void DisplayLegends(string[] legends);

        void DisplayHealth(int health);

        void DisplayCustomScore(string message);

        void DisplayGameTitle(string title);
    }

    internal class DisplayAdapter : IDisplayAdapter
    {
        private IGameViewModel myViewModel;

        public DisplayAdapter(IGameViewModel viewModel)
        {
            myViewModel = viewModel;
        }
        public void DisplayHealth(int health)
        {
            myViewModel.Health = "Health: " + health;
        }

        public void DisplayCustomScore(string score)
        {
            myViewModel.CustomScore = score;
        }

        public void DisplayLegends(string[] legends)
        {
            myViewModel.Legends = legends.ToList();
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

                    if(!(x == 0 && y ==0))
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

                                if (!IsCountUnderDistributionWeight(countMapping[entityToCopy] +1, entityToCopy.DistributionWeight, totalRows * totalColumns))
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

            myViewModel.MapEntities = fieldMap;
        }

        public void DisplayScore(int score)
        {
            myViewModel.Score = $"Score: {score}";
        }

        public void DisplayMessage(string message)
        {
            myViewModel.Message = message;
        }

        public void DisplayGameTitle(string title)
        {
            myViewModel.GameTitle = title;
        }

        private bool IsCountUnderDistributionWeight(int entityAddCount, int distributionWeight, int totalCells)
        {
            return (distributionWeight == 0) || entityAddCount < (distributionWeight * totalCells / 10);
        }
    }
}
