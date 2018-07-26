/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Windows.Input;

namespace CodeWar5.GameEngine.Drivers
{
    public class GameInputEventArgs : EventArgs
    {
        public Key Input { get; }

        public GameInputEventArgs(Key inputKey)
        {
            Input = inputKey;
        }
    }
}
