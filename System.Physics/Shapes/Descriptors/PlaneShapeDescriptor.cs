using System.Maths;
using System.Physics.Factories;

namespace System.Physics.Shapes.Descriptors
{
    public struct PlaneShapeDescriptor : System.Physics.IDescriptor
    {
        public PlaneShapeDescriptor(Vector3 normal, float distanceFromOrigin, object userData = null) : this()
        {
            Normal = normal;
            DistanceFromOrigin = distanceFromOrigin;
            UserData = userData;
        }

        public Vector3 Normal { get; set; }
        public float DistanceFromOrigin { get; set; }

        public void ToDefault()
        {
            Normal = Vectors.YAxis;
            DistanceFromOrigin = 0;
            UserData = null;
        }

        public object UserData { get; set; }
    }
}