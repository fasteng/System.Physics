using System.Collections.Generic;
using System.Maths;

namespace System.Physics.Shapes.Descriptors
{
    public struct ConvexPolyhedronShapeDescriptor : System.Physics.IDescriptor
    {
        public ConvexPolyhedronShapeDescriptor(IEnumerable<Vector3> vertices, object userData = null) : this()
        {
            Vertices = vertices;
            UserData = userData;
        }

        public IEnumerable<Vector3> Vertices
        {
            get;
            set;
        }

       public void ToDefault()
       {
           UserData = null;
           Vertices = null;
       }

        public object UserData { get; set; }
    }
}