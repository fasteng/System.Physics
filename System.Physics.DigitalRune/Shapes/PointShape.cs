using System.Maths;
using System.Physics.DigitalRune;
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using DigitalRune.Geometry.Shapes;

namespace System.Physics.DigitalRune.Shapes
{
    public class PointShape : BasePointShape, IDigitalRuneShape 
    {
        internal global::DigitalRune.Geometry.Shapes.PointShape WrappedPointShape {get; private set;}
        public PointShape(PointShapeDescriptor descriptor)
        {
            WrappedPointShape = new global::DigitalRune.Geometry.Shapes.PointShape(descriptor.Position.ToDigitalRune());
            UserData = descriptor.UserData;
        }

        public override Vector3 Position
        {
            get { return WrappedPointShape.Position.ToStandard(); }
            set { WrappedPointShape.Position = value.ToDigitalRune(); }
        }
    }
}
