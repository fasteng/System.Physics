
using System.Maths;
using System.Physics.DigitalRune;
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using DigitalRune.Geometry.Shapes;

namespace System.Physics.DigitalRune.Shapes
{
    public class LineShape : BaseLineShape, IDigitalRuneShape
    {
        internal global::DigitalRune.Geometry.Shapes.LineShape WrappedLineShape {get; private set;}
        public LineShape(LineShapeDescriptor descriptor)
        {
            WrappedLineShape = new global::DigitalRune.Geometry.Shapes.LineShape(descriptor.PointOnLine.ToDigitalRune(),
                                              descriptor.Direction.ToDigitalRune());
            UserData = descriptor.UserData;
        }

        public override Vector3 Direction 
        { 
            get
            {
                return WrappedLineShape.Direction.ToStandard();
            }
            set
            {
                WrappedLineShape.Direction = value.ToDigitalRune();
            }
        }
        public override Vector3 PointOnLine
        {
            get
            {
                return WrappedLineShape.PointOnLine.ToStandard();
            }
            set
            {
                WrappedLineShape.PointOnLine = value.ToDigitalRune();
            }
        }
    }
}
