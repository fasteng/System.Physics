using System.Maths;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultPlaneShape : BasePlaneShape 
    {
        public DefaultPlaneShape(PlaneShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }
        public override Vector3 Normal { get; set; }
        public override float DistanceFromOrigin { get; set; }
    }
}
