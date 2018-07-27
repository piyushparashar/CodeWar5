/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

namespace WhiteWalkersGames.SourceEngine.Modules.Views
{
    internal class FieldCell
    {
        public string Text { get; }

        public int Row { get;}

        public int Column { get; }

        public FieldCell(string txt, int x, int y)
        {
            Text = txt;
            Row = x;
            Column = y;
        }
    }
}
