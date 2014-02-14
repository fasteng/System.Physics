using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using DigitalRune.Geometry.Shapes;

namespace System.Physics.DigitalRune.Shapes
{
    public class BoxShape : BaseBoxShape, IDigitalRuneShape 
    {
        internal global::DigitalRune.Geometry.Shapes.BoxShape WrappedBoxShape {get; private set;}
        public BoxShape(BoxShapeDescriptor descriptor)
        {
            WrappedBoxShape = new global::DigitalRune.Geometry.Shapes.BoxShape(descriptor.WidthX, descriptor.WidthY, descriptor.WidthZ);
            UserData = descriptor.UserData;
        }

        public override float WidthX
        {
            get { return WrappedBoxShape.WidthX; }
            set { WrappedBoxShape.WidthX = value; }
        }
        public override float WidthY
        {
            get { return WrappedBoxShape.WidthY; }
            set { WrappedBoxShape.WidthY = value; }

        }
        public override float WidthZ
        {
            get { return WrappedBoxShape.WidthZ; }
            set { WrappedBoxShape.WidthZ = value; }

        }
    }
}
