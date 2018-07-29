/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WhiteWalkersGames.SourceEngine.Modules.Infrastructure;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;
using WhiteWalkersGames.SourceEngine.Modules.Views;

namespace WhiteWalkersGames.SourceEngine.Drivers.Display
{
    public interface IDisplayAdapter
    {
        void DrawField(List<IMapEntity> mapEntities, int rows, int colunms, ref IMapEntity[,] fieldMap);

        void DrawSubject(int row, int column);

        void DisplayScore(int score);

        void DisplayMessage(string message);

        void DisplayLegends(string[] legends);

        void DisplayHealth(int health);

        void DisplayCustomScore(string message);

        void DisplayGameTitle(string title);
    }

    public class DisplayAdapter : IDisplayAdapter
    {
        private IGameViewModel myViewModel;
        private Grid myCanvas;
        private ContentControl mySubject;

        public DisplayAdapter(IGameViewModel viewModel)
        {
            myViewModel = viewModel;
            myCanvas = viewModel.Canvas;
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

        public void DrawField(List<IMapEntity> mapEntities, int totalRows, int totalColumns, ref IMapEntity[,] fieldMap)
        {
            mySubject = null;
            myCanvas.Children.Clear();
            myCanvas.RowDefinitions.Clear();
            myCanvas.ColumnDefinitions.Clear();

            Dictionary<IMapEntity, int> countMapping = new Dictionary<IMapEntity, int>();

            mapEntities.ForEach(entity => countMapping.Add(entity, 0));

            for (int i = 0; i < totalRows; i++)
            {
                myCanvas.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }
            for (int i = 0; i < totalColumns; i++)
            {
                myCanvas.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }
            Random random = new Random();
            int mapEntityToPick = 0;
            int lastEntityPicked = 0;
            int totalEntitiesTypes = mapEntities.Count;

            for (int x = 0; x < totalColumns; x++)
            {
                for (int y = 0; y < totalRows; y++)
                {
                    var cell = new ContentControl();

                    if (x == 0 && y == 0)
                    {
                        cell.Content = new EmptyMapEnity();
                    }
                    else
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

                                cell.Content = new DataBoundMapEntity
                                {
                                    Description = entityToCopy.Description,
                                    DisplayText = entityToCopy.DisplayText,
                                    Icon = entityToCopy.Icon,
                                    ScoringWeight = entityToCopy.ScoringWeight,
                                    Row = y,
                                    Column = x,
                                    IsMoveAllowedOnThis = entityToCopy.IsMoveAllowedOnThis
                                };

                                countMapping[entityToCopy]++;
                            }
                            else
                            {
                                cell.Content = new EmptyMapEnity();
                            }
                        }
                        else
                        {
                            cell.Content = new EmptyMapEnity();
                        }
                    }
                   
                    Grid.SetRow(cell, x);
                    Grid.SetColumn(cell, y);
                    myCanvas.Children.Add(cell);
                    fieldMap[x, y] = cell.Content as IMapEntity;
                }
            }
        }

        private bool IsCountUnderDistributionWeight(int entityAddCount, int distributionWeight, int totalCells)
        {
            return  (distributionWeight == 0) || entityAddCount < (distributionWeight * totalCells /10);
        }

        public void DrawSubject(int x, int y)
        {
            if (mySubject == null)
            {
                mySubject = new ContentControl
                {
                    Content = new SubjectCell()
                };
                myCanvas.Children.Add(mySubject);
            }

            Grid.SetRow(mySubject, x);
            Grid.SetColumn(mySubject, y);
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
    }
}
