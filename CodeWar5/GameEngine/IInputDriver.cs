/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */
   
using System;

namespace CodeWar5.GameEngine.Drivers
{
    public interface IInputDriver
    {
        event EventHandler<GameInputEventArgs> InputReceived;
    }
}
