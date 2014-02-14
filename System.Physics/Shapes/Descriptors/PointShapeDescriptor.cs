using System.Maths;

namespace System.Physics.Shapes.Descriptors
{
    public struct PointShapeDescriptor : IDescriptor
    {
        public PointShapeDescriptor(Vector3 position, object userData = null) : this()
        {
            Position = position;
            UserData = userData;
        }

        public Vector3 Position
        {
            get;
            set;
        }

        public void ToDefault()
        {
            Position = new Vector3();
            UserData = null;
        }

        public object UserData { get; set; }
    }
}