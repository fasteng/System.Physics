using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultConvexPolyhedronShape : BaseConvexPolyhedronShape
    {
        public DefaultConvexPolyhedronShape(ConvexPolyhedronShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }
        
    }
}
