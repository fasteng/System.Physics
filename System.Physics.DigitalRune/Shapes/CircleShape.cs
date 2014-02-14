using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using DigitalRune.Geometry.Shapes;

namespace System.Physics.DigitalRune.Shapes
{
    public class CircleShape : BaseCircleShape, IDigitalRuneShape 
    {
        internal global::DigitalRune.Geometry.Shapes.CircleShape WrappedCircleShape {get; private set;}
        public CircleShape(CircleShapeDescriptor descriptor)
        {
            WrappedCircleShape = new global::DigitalRune.Geometry.Shapes.CircleShape(descriptor.Radius);
            UserData = descriptor.UserData;
        }
       
        public override float Radius 
        {
            get { return WrappedCircleShape.Radius; }
            set { WrappedCircleShape.Radius = value; }
        }
    }
}
