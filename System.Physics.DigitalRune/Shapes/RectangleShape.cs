
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using DigitalRune.Geometry.Shapes;

namespace System.Physics.DigitalRune.Shapes
{
    public class RectangleShape : BaseRectangleShape, IDigitalRuneShape
    {
        internal global::DigitalRune.Geometry.Shapes.RectangleShape WrappedRectangleShape {get; private set;}
        public RectangleShape(RectangleShapeDescriptor descriptor)
        {
            WrappedRectangleShape = new global::DigitalRune.Geometry.Shapes.RectangleShape(descriptor.WidthX, descriptor.WidthY);
            UserData = descriptor.UserData;
        }

        public override float WidthY
        {
            get { return WrappedRectangleShape.WidthY; }
            set { WrappedRectangleShape.WidthY = value; }
        }
        public override float WidthX
        {
            get { return WrappedRectangleShape.WidthX; }
            set { WrappedRectangleShape.WidthX = value; }
        }
    }
}
