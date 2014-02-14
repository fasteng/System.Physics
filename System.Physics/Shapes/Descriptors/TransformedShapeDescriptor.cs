using System.Maths;

namespace System.Physics.Shapes.Descriptors
{
    public struct TransformedShapeDescriptor : System.Physics.IDescriptor
    {
        public TransformedShapeDescriptor(IShape shape, Matrix4x4 pose, object userData = null) : this()
        {
            Shape = shape;
            Pose = pose;
            UserData = userData;
        }

        public IShape Shape
        {
            get;
            set;
        }

        public Matrix4x4 Pose
        {
            get;
            set;
        }

        public void ToDefault()
        {
            Pose = Matrices.I;
            UserData = null;
        }

        public object UserData { get; set; }
    }
}