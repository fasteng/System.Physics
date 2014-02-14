
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultCylinderShape : BaseCylinderShape
    {
        public DefaultCylinderShape(CylinderShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }

        public override float Height { get; set; }
        public override float Radius { get; set; }
    }
}
