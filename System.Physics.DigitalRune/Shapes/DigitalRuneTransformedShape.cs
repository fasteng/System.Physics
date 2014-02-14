
using System.Maths;
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.DigitalRune.Shapes
{
    public class DigitalRuneTransformedShape : BaseTransformedShape, IDigitalRuneShape
    {
        public DigitalRuneTransformedShape(TransformedShapeDescriptor descriptor)
        {
            UserData = descriptor.UserData;
        }
   
        public override IShape Shape { get; set; }
        public override Matrix4x4 Pose { get; set; }
    }
}
