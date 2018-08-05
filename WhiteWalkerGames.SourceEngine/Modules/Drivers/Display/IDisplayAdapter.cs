/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System.Collections.Generic;
using System.Collections.ObjectModel;
using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Model;

namespace WhiteWalkersGames.SourceEngine.Drivers.Display
{
    internal interface IDisplayAdapter
    {
        void DrawField(List<IMapEntity> mapEntities, int rows, int colunms, ref ObservableCollection<ObservableCollection<DataBoundMapEntity>> fieldMap);

        void DisplayScore(int score);

        void DisplayMessage(string message);

        void DisplayLegends(string[] legends);

        void DisplayHealth(int health);

        void DisplayGameTitle(string title);
    }
}
