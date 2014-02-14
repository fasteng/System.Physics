
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultConvexHullOfPointsShape : BaseConvexHullOfPointsShape
    {
        public DefaultConvexHullOfPointsShape(ConvexHullOfPointsShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }
        
    }
}
