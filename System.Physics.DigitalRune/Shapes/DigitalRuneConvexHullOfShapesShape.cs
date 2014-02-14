
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.DigitalRune.Shapes
{
    public class DigitalRuneConvexHullOfShapesShape : BaseConvexHullOfShapesShape, IDigitalRuneShape
    {
        public DigitalRuneConvexHullOfShapesShape(ConvexHullOfShapesShapeDescriptor descriptor)
        {
            UserData = descriptor.UserData;
        }
   

    }
}
