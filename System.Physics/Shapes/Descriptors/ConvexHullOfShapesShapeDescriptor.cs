using System.Collections.Generic;

namespace System.Physics.Shapes.Descriptors
{
    public struct ConvexHullOfShapesShapeDescriptor : System.Physics.IDescriptor
    {
        public ConvexHullOfShapesShapeDescriptor(IEnumerable<IShapePositioner> children, object userData = null) : this()
        {
            Children = children;
            UserData = userData;
        }

        public IEnumerable<IShapePositioner> Children
        {
            get;
            set;
        }

       public void ToDefault()
       {
           UserData = null;
           Children = null;
       }

        public object UserData { get; set; }
    }
}