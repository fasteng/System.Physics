using System.Maths;
using System.Physics.DigitalRune;
using System.Physics.Factories;
using System.Physics.Shapes;
using DigitalRune.Geometry;
using DigitalRune.Geometry.Shapes;

namespace System.Physics.DigitalRune.Shapes
{
    internal partial class ShapePositioner : BaseShapePositioner
    {
        internal GeometricObject WrappedGeometricObject { get; private set; }

        public ShapePositioner(ShapePositionerDescriptor descriptor)
        {
            WrappedGeometricObject = new GeometricObject();
            Descriptor = descriptor;
            ShapeFactory = new ShapePositionerShapeFactory(this);
        }



        public override  Matrix4x4 Pose
        {
            get { return WrappedGeometricObject.Pose.ToStandard(); }
            set { WrappedGeometricObject.Pose = value.ToDigitalRune(); }
        }

        public override ISingleFactory<IShape> ShapeFactory { get; protected set; }

       
    }
}