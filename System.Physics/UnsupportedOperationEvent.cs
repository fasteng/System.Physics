using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Physics
{
    public delegate void UnsupportedOperationEventHandler(object sender,
                                     UnsupportedOperationEventArgs args);

    public class UnsupportedOperationEventArgs : EventArgs
    {
        public string Message { get; set; }

        public UnsupportedOperationEventArgs(string message)
        {
            Message = message;
        }
    }

}
