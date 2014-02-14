
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using DigitalRune.Geometry.Shapes;

namespace System.Physics.DigitalRune.Shapes
{
    public class CapsuleShape : BaseCapsuleShape, IDigitalRuneShape
    {
        internal global::DigitalRune.Geometry.Shapes.CapsuleShape WrappedCapsuleShape {get; private set;}
        public CapsuleShape(CapsuleShapeDescriptor descriptor)
        {
            WrappedCapsuleShape = new global::DigitalRune.Geometry.Shapes.CapsuleShape(descriptor.Radius,descriptor.Height);
            UserData = descriptor.UserData;
        }

        public override float Height
        {
            get { return WrappedCapsuleShape.Height; }
            set { WrappedCapsuleShape.Height = value; }
        }
        public override float Radius
        {
            get { return WrappedCapsuleShape.Radius; }
            set { WrappedCapsuleShape.Radius = value; }
        }
    }
}
