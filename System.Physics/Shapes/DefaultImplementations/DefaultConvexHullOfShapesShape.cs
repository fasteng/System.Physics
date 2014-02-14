
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultConvexHullOfShapesShape : BaseConvexHullOfShapesShape
    {
        public DefaultConvexHullOfShapesShape(ConvexHullOfShapesShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }
        
    }
}
