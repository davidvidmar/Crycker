using System;
using System.Collections.Generic;

namespace Crycker.Data
{
    public class Values : List<double>
    {
        public event EventHandler ValuesChanged;

        public void AddValue(double d)
        {
            Add(d);
            if (Count > 240) RemoveAt(0);
            OnValuesChanged(new EventArgs());
        }

        protected virtual void OnValuesChanged(EventArgs e)
        {
            var handler = ValuesChanged;
            handler?.Invoke(this, e);
        }
    }
}
