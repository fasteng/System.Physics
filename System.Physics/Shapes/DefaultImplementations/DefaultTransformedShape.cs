
using System.Maths;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultTransformedShape : BaseTransformedShape
    {
        public DefaultTransformedShape(TransformedShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }
        public override IShape Shape { get; set; }
        public override Matrix4x4 Pose { get; set; }
    }
}
