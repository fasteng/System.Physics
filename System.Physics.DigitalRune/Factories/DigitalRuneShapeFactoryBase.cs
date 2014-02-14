using System.Physics.DigitalRune.Shapes;
using System.Physics.Factories;
using System.Physics.Shapes;
using System.Physics.Shapes.Descriptors;
using DigitalRune.Geometry.Shapes;
using BoxShape = System.Physics.DigitalRune.Shapes.BoxShape;
using CapsuleShape = System.Physics.DigitalRune.Shapes.CapsuleShape;
using CircleShape = System.Physics.DigitalRune.Shapes.CircleShape;
using CompositeShape = System.Physics.DigitalRune.Shapes.CompositeShape;
using CylinderShape = System.Physics.DigitalRune.Shapes.CylinderShape;
using LineSegmentShape = System.Physics.DigitalRune.Shapes.LineSegmentShape;
using LineShape = System.Physics.DigitalRune.Shapes.LineShape;
using PlaneShape = System.Physics.DigitalRune.Shapes.PlaneShape;
using PointShape = System.Physics.DigitalRune.Shapes.PointShape;
using RectangleShape = System.Physics.DigitalRune.Shapes.RectangleShape;
using SphereShape = System.Physics.DigitalRune.Shapes.SphereShape;
using TriangleShape = System.Physics.DigitalRune.Shapes.TriangleShape;

namespace System.Physics.DigitalRune.Factories
{
    internal abstract class DigitalRuneShapeFactoryBase : 
        BaseSingleFactory<IShape>, 
        IFactoryOf<IPointShape, 
        PointShapeDescriptor>, 
        IFactoryOf<ILineShape, 
        LineShapeDescriptor>, 
        IFactoryOf<ILineSegmentShape, 
        LineSegmentShapeDescriptor>, 
        IFactoryOf<ITriangleShape, 
        TriangleShapeDescriptor>, 
        IFactoryOf<IRectangleShape, 
        RectangleShapeDescriptor>, 
        IFactoryOf<ICircleShape, 
        CircleShapeDescriptor>, 
        IFactoryOf<IPlaneShape, 
        PlaneShapeDescriptor>, 
        IFactoryOf<IBoxShape, BoxShapeDescriptor>, 
        IFactoryOf<ICapsuleShape, 
        CapsuleShapeDescriptor>, 
        IFactoryOf<ICylinderShape, CylinderShapeDescriptor>, 
        IFactoryOf<ISphereShape, SphereShapeDescriptor>,
        IFactoryOf<ICompositeShape, CompositeShapeDescriptor>
    {
        IPlaneShape IFactoryOf<IPlaneShape, PlaneShapeDescriptor>.Create(PlaneShapeDescriptor descriptor)
        {
            var planeShape = new PlaneShape(descriptor);
            Store(planeShape.WrappedPlaneShape);
            return planeShape;
        }

        protected abstract void Store(Shape wrappedShape);

        ISphereShape IFactoryOf<ISphereShape, SphereShapeDescriptor>.Create(SphereShapeDescriptor descriptor)
        {
            var sphereShape = new SphereShape(descriptor);
            Store(sphereShape.WrappedSphereShape);
            return sphereShape;
        }

        IBoxShape IFactoryOf<IBoxShape, BoxShapeDescriptor>.Create(BoxShapeDescriptor descriptor)
        {
            var boxShape = new BoxShape(descriptor);
            Store(boxShape.WrappedBoxShape);
            return boxShape;
        }

        ICylinderShape IFactoryOf<ICylinderShape, CylinderShapeDescriptor>.Create(CylinderShapeDescriptor descriptor)
        {
            var cylinderShape = new CylinderShape(descriptor);
            Store(cylinderShape.WrappedCylinderShape);
            return cylinderShape;
        }

        ICapsuleShape IFactoryOf<ICapsuleShape, CapsuleShapeDescriptor>.Create(CapsuleShapeDescriptor descriptor)
        {
            var capsuleShape = new CapsuleShape(descriptor);
            Store(capsuleShape.WrappedCapsuleShape);
            return capsuleShape;
        }

        IPointShape IFactoryOf<IPointShape, PointShapeDescriptor>.Create(PointShapeDescriptor descriptor)
        {
            var pointShape = new PointShape(descriptor);
            Store(pointShape.WrappedPointShape);
            return pointShape;
        }

        ILineShape IFactoryOf<ILineShape, LineShapeDescriptor>.Create(LineShapeDescriptor descriptor)
        {
            var lineShape = new LineShape(descriptor);
            Store(lineShape.WrappedLineShape);
            return lineShape;
        }

        ILineSegmentShape IFactoryOf<ILineSegmentShape, LineSegmentShapeDescriptor>.Create(LineSegmentShapeDescriptor descriptor)
        {
            var lineSegmentShape = new LineSegmentShape(descriptor);
            Store(lineSegmentShape.WrappedLineSegmentShape);
            return lineSegmentShape;
        }

        ITriangleShape IFactoryOf<ITriangleShape, TriangleShapeDescriptor>.Create(TriangleShapeDescriptor descriptor)
        {
            var triangleShape = new TriangleShape(descriptor);
            Store(triangleShape.WrappedTriangleShape);
            return triangleShape;
        }

        IRectangleShape IFactoryOf<IRectangleShape, RectangleShapeDescriptor>.Create(RectangleShapeDescriptor descriptor)
        {
            var rectangleShape = new RectangleShape(descriptor);
            Store(rectangleShape.WrappedRectangleShape);
            return rectangleShape;
        }

        ICircleShape IFactoryOf<ICircleShape, CircleShapeDescriptor>.Create(CircleShapeDescriptor descriptor)
        {
            var circleShape = new CircleShape(descriptor);
            Store(circleShape.WrappedCircleShape);
            return circleShape;
        }

        ICompositeShape IFactoryOf<ICompositeShape, CompositeShapeDescriptor>.Create(CompositeShapeDescriptor descriptor)
        {
            var compositeShape = new CompositeShape(descriptor);
            Store(compositeShape.WrappedCompositeShape);
            return compositeShape;
        }
    }
}