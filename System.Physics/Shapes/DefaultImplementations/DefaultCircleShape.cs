
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultCircleShape : BaseCircleShape
    {
        public DefaultCircleShape(CircleShapeDescriptor descriptor)
        {
          Descriptor = descriptor;
        }

        public override float Radius { get; set; }
    }
}
