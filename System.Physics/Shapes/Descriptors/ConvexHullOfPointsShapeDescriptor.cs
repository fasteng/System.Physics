using System.Collections.Generic;
using System.Maths;

namespace System.Physics.Shapes.Descriptors
{
    public struct ConvexHullOfPointsShapeDescriptor : System.Physics.IDescriptor
    {
        public ConvexHullOfPointsShapeDescriptor(IEnumerable<Vector3> points, object userData = null) : this()
        {
            Points = points;
            UserData = userData;
        }

        public IEnumerable<Vector3> Points
        {
            get;
            set;
        }

        public void ToDefault()
        {
            UserData = null;
            Points = null;
        }

        public object UserData { get; set; }
    }
}