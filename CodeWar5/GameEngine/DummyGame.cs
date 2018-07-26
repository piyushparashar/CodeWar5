/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System.Windows.Input;
using CodeWar5.GameEngine.Drivers;

namespace CodeWar5.GameEngine
{
    internal class DummyGame
    {
        private const string Mine = "X";
        private const string Hill = "H";
        private const string Trench = "T";
        private const string River = "R";
        private const string EnemySoldier = "S";
        private const string Exit = "E";

        private readonly IDisplayDriver myDisplayDriver;
        private readonly IInputDriver myInputDriver;
        private int myCurrentRow;
        private int myCurrentColumn;
        private double myScore;
        private int myHealth;
        private bool myGameOver = false;

        private readonly string[,] myField = new string[,]
        {
            {"", Hill, Mine, "", Trench},
            {Trench, "", "", EnemySoldier, ""},
            {Mine, EnemySoldier, Mine, "", Mine},
            {Hill, "", Hill, "", Trench},
            {River, EnemySoldier, "", "", Exit},
        };

        public DummyGame(IDisplayDriver display, IInputDriver input)
        {
            myDisplayDriver = display;
            myInputDriver = input;
            myInputDriver.InputReceived += OnInputReceived;
        }

        public void Start()
        {
           
            myDisplayDriver.DisplayMessage("");
            myDisplayDriver.DrawField(myField);

            myCurrentRow = 0;
            myCurrentColumn = 0;
            myDisplayDriver.DrawSubject(myCurrentRow, myCurrentColumn);

            myGameOver = false;
            myScore = 100;
            myDisplayDriver.DisplayScore(myScore);
        }

        private void OnInputReceived(object sender, GameInputEventArgs e)
        {
            if(myGameOver == true)
            {
                return;
            }

            if (e.Input == Key.Left)
            {
                myCurrentColumn--;
            }
            if (e.Input == Key.Right)
            {
                myCurrentColumn++;
            }
            if (e.Input == Key.Up)
            {
                myCurrentRow--;
            }
            if (e.Input == Key.Down)
            {
                myCurrentRow++;
            }

            myDisplayDriver.DrawSubject(myCurrentRow, myCurrentColumn);

            myScore -= GetScore();
            myDisplayDriver.DisplayScore(myScore);

            if (!myGameOver && myScore <= 0)
            {
                myDisplayDriver.DisplayMessage("Game Over, you lost!!!");
                myGameOver = true;
            }
        }

        int GetScore()
        {
            if(string.IsNullOrEmpty(myField[myCurrentRow, myCurrentColumn]))
            {
                return 5;
            }
            else if(myField[myCurrentRow, myCurrentColumn] == Mine)
            {
                myDisplayDriver.DisplayMessage("Game Over, you lost!!!");
                myGameOver = true;
            }
            else if (myField[myCurrentRow, myCurrentColumn] == Exit)
            {
                myDisplayDriver.DisplayMessage("Game Over, you won!!!");
                myGameOver = true;
            }

            return 10;
        }
    }
}
