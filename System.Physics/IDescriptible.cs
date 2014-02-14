using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Physics
{
    public interface IDescriptible<TDescriptor>  where TDescriptor : IDescriptor
    {
        TDescriptor Descriptor { get; set; }
    }
}
