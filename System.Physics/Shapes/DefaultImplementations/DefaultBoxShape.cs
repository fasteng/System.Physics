using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultBoxShape : BaseBoxShape
    {
        public DefaultBoxShape(BoxShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }

        public override float WidthX { get; set; }
        public override float WidthY { get; set; }
        public override float WidthZ { get; set; }
    }
}
