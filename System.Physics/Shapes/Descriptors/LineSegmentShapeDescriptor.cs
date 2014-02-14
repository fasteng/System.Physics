using System.Maths;

namespace System.Physics.Shapes.Descriptors
{
    public struct LineSegmentShapeDescriptor : System.Physics.IDescriptor
    {
        public LineSegmentShapeDescriptor(Vector3 startPoint, Vector3 endPoint, object userData = null) : this()
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            UserData = userData;
        }

        public Vector3 StartPoint
        {
            get;
            set;
        }

        public Vector3 EndPoint
        {
            get;
            set;
        }

        public void ToDefault()
        {
            StartPoint = new Vector3(-0.5f,0,0);
            EndPoint = new Vector3(0.5f, 0, 0);
            UserData = null;
        }

        public object UserData { get; set; }
    }
}
