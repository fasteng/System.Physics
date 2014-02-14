
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.DigitalRune.Shapes
{
    public class DigitalRuneConvexHullOfPointsShape : BaseConvexHullOfPointsShape, IDigitalRuneShape 
    {
        public DigitalRuneConvexHullOfPointsShape(ConvexHullOfPointsShapeDescriptor descriptor)
        {
            UserData = descriptor.UserData;
        }
  
    }
}
