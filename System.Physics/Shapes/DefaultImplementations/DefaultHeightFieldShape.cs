using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultHeightFieldShape : BaseHeightFieldShape
    {
        public DefaultHeightFieldShape(HeightFieldShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }
       
    }
}
