using System.Maths;
using System.Physics.DigitalRune;
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using DigitalRune.Geometry.Shapes;

namespace System.Physics.DigitalRune.Shapes
{
    public class LineSegmentShape : BaseLineSegmentShape, IDigitalRuneShape 
    {
        internal global::DigitalRune.Geometry.Shapes.LineSegmentShape WrappedLineSegmentShape {get; private set;}
        public LineSegmentShape(LineSegmentShapeDescriptor descriptor)
        {
            WrappedLineSegmentShape = new global::DigitalRune.Geometry.Shapes.LineSegmentShape(descriptor.StartPoint.ToDigitalRune(),
                                                            descriptor.EndPoint.ToDigitalRune());
            UserData = descriptor.UserData;
        }
        

        public override Vector3 StartPoint
        {
            get { return WrappedLineSegmentShape.Start.ToStandard(); }
            set { WrappedLineSegmentShape.Start = value.ToDigitalRune(); }
        }
        public override Vector3 EndPoint
        {
            get { return WrappedLineSegmentShape.Start.ToStandard(); }
            set { WrappedLineSegmentShape.Start = value.ToDigitalRune(); }
        }

        public override float Length 
        {
            get { return Length; }
        }
        public override float LengthSquared
        {
            get { return LengthSquared; }
        }
    }
}
