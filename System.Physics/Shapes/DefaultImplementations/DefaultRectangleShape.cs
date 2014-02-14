
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultRectangleShape : BaseRectangleShape
    {
        public DefaultRectangleShape(RectangleShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }

        public override float WidthY { get; set; }
        public override float WidthX { get; set; }
    }
}
