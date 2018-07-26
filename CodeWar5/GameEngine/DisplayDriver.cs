/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace CodeWar5.GameEngine.Drivers
{
    internal class DisplayDriver : IDisplayDriver, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Grid myCanvas;

        private string myMessage;
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

        private string myHealth;
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

        private string myCustomScore;
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

        private string myScore;
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

        private List<string> myLegends;
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

        private ContentControl mySubject;

        public DisplayDriver(IDisplayContext context, Grid canvas)
        {
            myCanvas = canvas;
            context.DataContext = this;
        }        

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void DisplayScore(double score)
        {
            Score = "Score: " + score;
        }

        public void DisplayMessage(string message)
        {
            Message = message;
        }

        public void DisplayHealth(int health)
        {
            Health = "Health: " + health;
        }

        public void DisplayCustomScore(string score)
        {
            CustomScore = score;
        }

        public void DisplayLegends(string[] legends)
        {
            Legends = legends.ToList();
        }

        public void DrawField(string [,] field)
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

            for (int x= 0; x < field.GetLength(0); x++)
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
            if(mySubject == null)
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
    }
}
