﻿using System;

namespace CryptoTray.Types
{
    public class StringEventArgs : EventArgs
    {
        public string Value { get; private set; }

        public StringEventArgs(string value)
        {
            Value = value;
        }
    }
}
