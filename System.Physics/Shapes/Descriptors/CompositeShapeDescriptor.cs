using System.Collections.Generic;

namespace System.Physics.Shapes.Descriptors
{
    public struct CompositeShapeDescriptor : IDescriptor
    {
        public CompositeShapeDescriptor(object userData = null) : this()
        {
            UserData = userData;
        }

        public void ToDefault()
        {
            UserData = null;
        }

        public object UserData { get; set; }
    }
}