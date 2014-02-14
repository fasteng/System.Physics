
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultTriangleMeshShape : BaseTriangleMeshShape
    {
        public DefaultTriangleMeshShape(TriangleMeshShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }
    }
}
