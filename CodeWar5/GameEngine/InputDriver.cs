/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Windows;
using System.Windows.Input;

namespace CodeWar5.GameEngine.Drivers
{
    internal class InputDriver : IInputDriver
    {
        private readonly IInputElement mySource;

        public event EventHandler<GameInputEventArgs> InputReceived;

        public InputDriver(IInputElement source)
        {
            mySource = source;
            mySource.KeyDown += OnSourceKeyDown;
        }

        private void OnSourceKeyDown(object sender, KeyEventArgs e)
        {
            InputReceived?.Invoke(this, new GameInputEventArgs(e.Key));
        }
    }

}
