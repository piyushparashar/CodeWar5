/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

namespace WhiteWalkersGames.SourceEngine.Drivers.Display
{
    public interface IDisplayAdapter
    {
        void DrawField(string[,] field);

        void DrawSubject(int x, int y);

        void DisplayScore(double score);

        void DisplayMessage(string message);

        void DisplayLegends(string[] legends);

        void DisplayHealth(int health);

        void DisplayCustomScore(string message);
    }
}
