using System.Maths;
using System.Physics.DigitalRune;
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using DigitalRune.Geometry.Shapes;

namespace System.Physics.DigitalRune.Shapes
{
    public class PlaneShape : BasePlaneShape, IDigitalRuneShape
    {
        internal global::DigitalRune.Geometry.Shapes.PlaneShape WrappedPlaneShape {get; private set;}
        public PlaneShape(PlaneShapeDescriptor descriptor)
        {
            WrappedPlaneShape = new global::DigitalRune.Geometry.Shapes.PlaneShape(descriptor.Normal.ToDigitalRune(),
                                                descriptor.DistanceFromOrigin);
            UserData = descriptor.UserData;
        }
 
        public override Vector3 Normal
        {
            get { return WrappedPlaneShape.Normal.ToStandard(); }
            set { WrappedPlaneShape.Normal = value.ToDigitalRune(); }
        }
        public override float DistanceFromOrigin
        {
            get { return WrappedPlaneShape.DistanceFromOrigin; }
            set { WrappedPlaneShape.DistanceFromOrigin = value; }
        }
    }
}
