using System.Maths;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultPointShape : BasePointShape
    {
        public DefaultPointShape(PointShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }

        public override Vector3 Position { get; set; }
    }
}
