using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.DigitalRune.Shapes
{
    public class DigitalRuneConvexPolyhedronShape : BaseConvexPolyhedronShape, IDigitalRuneShape 
    {
        public DigitalRuneConvexPolyhedronShape(ConvexPolyhedronShapeDescriptor descriptor)
        {
            UserData = descriptor.UserData;
        }
        
    }
}
