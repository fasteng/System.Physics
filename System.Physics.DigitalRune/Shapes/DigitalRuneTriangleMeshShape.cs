
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.DigitalRune.Shapes
{
    public class DigitalRuneTriangleMeshShape : BaseTriangleMeshShape, IDigitalRuneShape 
    {
        public DigitalRuneTriangleMeshShape(TriangleMeshShapeDescriptor descriptor)
        {
            UserData = descriptor.UserData;
        }
        
    }
}
