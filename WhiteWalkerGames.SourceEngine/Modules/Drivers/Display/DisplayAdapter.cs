/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WhiteWalkersGames.SourceEngine.Modules.ViewModel;
using WhiteWalkersGames.SourceEngine.Modules.Views;

namespace WhiteWalkersGames.SourceEngine.Drivers.Display
{
    internal interface IDisplayAdapter
    {
        void DrawField(string[,] field);

        void DrawSubject(int x, int y);

        void DisplayScore(double score);

        void DisplayMessage(string message);

        void DisplayLegends(string[] legends);

        void DisplayHealth(int health);

        void DisplayCustomScore(string message);
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

        public void DrawField(string[,] field)
        {
            mySubject = null;
            myCanvas.Children.Clear();
            myCanvas.RowDefinitions.Clear();
            myCanvas.ColumnDefinitions.Clear();

            for (int i = 0; i < field.GetLength(0); i++)
            {
                myCanvas.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }
            for (int i = 0; i < field.GetLength(1); i++)
            {
                myCanvas.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }

            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    var cell = new ContentControl
                    {
                        Content = new FieldCell(field[x, y], x, y)
                    };
                    Grid.SetRow(cell, x);
                    Grid.SetColumn(cell, y);
                    myCanvas.Children.Add(cell);
                }
            }
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

        public void DisplayScore(double score)
        {
            myViewModel.Score = $"Score: {score}";
        }

        public void DisplayMessage(string message)
        {

        }
    }
}
