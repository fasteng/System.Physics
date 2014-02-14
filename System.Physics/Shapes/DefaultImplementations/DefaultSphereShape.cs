
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultSphereShape : BaseSphereShape
    {
        public DefaultSphereShape(SphereShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }

        public override float Radius { get; set; }
    }
}
