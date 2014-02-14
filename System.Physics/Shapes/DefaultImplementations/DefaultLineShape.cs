
using System.Maths;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultLineShape : BaseLineShape
    {
        public DefaultLineShape(LineShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }
        public override Vector3 Direction { get; set; }
        public override Vector3 PointOnLine { get; set; }
    }
}
