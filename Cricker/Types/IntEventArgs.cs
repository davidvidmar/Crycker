using System;

namespace Cricker.Types
{
    public class IntEventArgs : EventArgs
    {
        public int Value { get; private set; }

        public IntEventArgs(int value)
        {
            Value = value;
        }
    }
}
