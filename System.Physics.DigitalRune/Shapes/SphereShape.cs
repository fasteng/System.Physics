
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using DigitalRune.Geometry.Shapes;

namespace System.Physics.DigitalRune.Shapes
{
    public class SphereShape : BaseSphereShape, IDigitalRuneShape
    {
        internal global::DigitalRune.Geometry.Shapes.SphereShape WrappedSphereShape {get; private set;}
        public SphereShape(SphereShapeDescriptor descriptor)
        {
            WrappedSphereShape = new global::DigitalRune.Geometry.Shapes.SphereShape(descriptor.Radius);
            UserData = descriptor.UserData;
        }
        public override float Radius
        {
            get { return WrappedSphereShape.Radius; }
            set { WrappedSphereShape.Radius = value; }
        }
    }
}
