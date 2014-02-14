using System.Maths;

namespace System.Physics.Shapes.Descriptors
{
    public struct LineShapeDescriptor : IDescriptor
    {
        public LineShapeDescriptor(Vector3 pointOnLine, Vector3 direction, object userData = null) : this()
        {
            PointOnLine = pointOnLine;
            Direction = direction;
            UserData = userData;
        }

        public Vector3 Direction
        {
            get;
            set;
        }

        public Vector3 PointOnLine
        {
            get;
            set;
        }

        public void ToDefault()
        {
            Direction = Vectors.XAxis;
            PointOnLine = new Vector3();
            UserData = 0;
        }

        public object UserData { get; set; }
    }
}