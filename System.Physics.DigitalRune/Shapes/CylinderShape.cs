
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using DigitalRune.Geometry.Shapes;

namespace System.Physics.DigitalRune.Shapes
{
    public class CylinderShape : BaseCylinderShape, IDigitalRuneShape 
    {
        internal global::DigitalRune.Geometry.Shapes.CylinderShape WrappedCylinderShape {get; private set;}

        public CylinderShape(CylinderShapeDescriptor descriptor)
        {
            WrappedCylinderShape = new global::DigitalRune.Geometry.Shapes.CylinderShape(descriptor.Radius,descriptor.Height);
            UserData = descriptor.UserData;
        }
        public override float Height
        {
            get { return WrappedCylinderShape.Height; }
            set { WrappedCylinderShape.Height = value; }
        }
        public override float Radius
        {
            get { return WrappedCylinderShape.Radius; }
            set { WrappedCylinderShape.Radius = value; }
        }
    }
}
