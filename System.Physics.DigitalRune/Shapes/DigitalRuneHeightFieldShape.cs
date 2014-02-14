using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.DigitalRune.Shapes
{
    public class DigitalRuneHeightFieldShape : BaseHeightFieldShape, IDigitalRuneShape
    {
        public DigitalRuneHeightFieldShape(HeightFieldShapeDescriptor descriptor)
        {
            UserData = descriptor.UserData;
        }
       
    }
}
