using System.Physics.RigidBodies;
using System.Physics.Constraints;
using System.Physics.Constraints.Descriptors;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Physics.Materials;
using System.Physics.RigidBodies;
using System.Physics.Shapes;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Factories
{
    public static class FactoryExtensors
    {
        #region Shapes

        #region Box
        public static IBoxShape CreateBox(this IFactory<IShape> factory,
                                                    BoxShapeDescriptor descriptor)
        {
            return factory.Create<IBoxShape, BoxShapeDescriptor>(descriptor);
        }

        public static IBoxShape CreateBox(this IFactory<IShape> factory)
        {
            return factory.Create<IBoxShape>();
        }
        #endregion

        #region Capsule

        public static ICapsuleShape CreateCapsule(this IFactory<IShape> factory,
                                             CapsuleShapeDescriptor descriptor)
        {
            return factory.Create<ICapsuleShape, CapsuleShapeDescriptor>(descriptor);
        }

        public static ICapsuleShape CreateCapsule(this IFactory<IShape> factory)
        {
            return factory.Create<ICapsuleShape>();
        }

        #endregion

        #region Circle

        public static ICircleShape CreateCircle(this IFactory<IShape> factory,
                                             CircleShapeDescriptor descriptor)
        {
            return factory.Create<ICircleShape, CircleShapeDescriptor>(descriptor);
        }

        public static ICircleShape CreateCircle(this IFactory<IShape> factory)
        {
            return factory.Create<ICircleShape>();
        }

        #endregion

        #region Composite

        public static ICompositeShape CreateComposite(this IFactory<IShape> factory,
                                             CompositeShapeDescriptor descriptor)
        {
            return factory.Create<ICompositeShape, CompositeShapeDescriptor>(descriptor);
        }

        public static ICompositeShape CreateComposite(this IFactory<IShape> factory)
        {
            return factory.Create<ICompositeShape>();
        }

        #endregion

        #region ConvexHullOfPoints

        public static IConvexHullOfPointsShape CreateConvexHullOfPoints(this IFactory<IShape> factory,
                                             ConvexHullOfPointsShapeDescriptor descriptor)
        {
            return factory.Create<IConvexHullOfPointsShape, ConvexHullOfPointsShapeDescriptor>(descriptor);
        }

        public static IConvexHullOfPointsShape CreateConvexHullOfPoints(this IFactory<IShape> factory)
        {
            return factory.Create<IConvexHullOfPointsShape>();
        }

        #endregion

        #region ConvexHullOfShapes

        public static IConvexHullOfShapesShape CreateConvexHullOfShapes(this IFactory<IShape> factory,
                                             ConvexHullOfShapesShapeDescriptor descriptor)
        {
            return factory.Create<IConvexHullOfShapesShape, ConvexHullOfShapesShapeDescriptor>(descriptor);
        }

        public static IConvexHullOfShapesShape CreateConvexHullOfShapes(this IFactory<IShape> factory)
        {
            return factory.Create<IConvexHullOfShapesShape>();
        }

        #endregion

        #region ConvexPolyhedron

        public static IConvexPolyhedronShape CreateConvexPolyhedron(this IFactory<IShape> factory,
                                             ConvexPolyhedronShapeDescriptor descriptor)
        {
            return factory.Create<IConvexPolyhedronShape, ConvexPolyhedronShapeDescriptor>(descriptor);
        }

        public static IConvexPolyhedronShape CreateConvexPolyhedron(this IFactory<IShape> factory)
        {
            return factory.Create<IConvexPolyhedronShape>();
        }

        #endregion

        #region Cylinder

        public static ICylinderShape CreateCylinder(this IFactory<IShape> factory,
                                             CylinderShapeDescriptor descriptor)
        {
            return factory.Create<ICylinderShape, CylinderShapeDescriptor>(descriptor);
        }

        public static ICylinderShape CreateCylinder(this IFactory<IShape> factory)
        {
            return factory.Create<ICylinderShape>();
        }

        #endregion

        #region HeightField

        public static IHeightFieldShape CreateHeightField(this IFactory<IShape> factory,
                                             HeightFieldShapeDescriptor descriptor)
        {
            return factory.Create<IHeightFieldShape, HeightFieldShapeDescriptor>(descriptor);
        }

        public static IHeightFieldShape CreateHeightField(this IFactory<IShape> factory)
        {
            return factory.Create<IHeightFieldShape>();
        }

        #endregion

        #region LineSegment

        public static ILineSegmentShape CreateLineSegment(this IFactory<IShape> factory,
                                             LineSegmentShapeDescriptor descriptor)
        {
            return factory.Create<ILineSegmentShape, LineSegmentShapeDescriptor>(descriptor);
        }

        public static ILineSegmentShape CreateLineSegment(this IFactory<IShape> factory)
        {
            return factory.Create<ILineSegmentShape>();
        }

        #endregion

        #region Line

        public static ILineShape CreateLine(this IFactory<IShape> factory,
                                             LineShapeDescriptor descriptor)
        {
            return factory.Create<ILineShape, LineShapeDescriptor>(descriptor);
        }

        public static ILineShape CreateLine(this IFactory<IShape> factory)
        {
            return factory.Create<ILineShape>();
        }

        #endregion

        #region Plane

        public static IPlaneShape CreatePlane(this IFactory<IShape> factory,
                                             PlaneShapeDescriptor descriptor)
        {
            return factory.Create<IPlaneShape, PlaneShapeDescriptor>(descriptor);
        }

        public static IPlaneShape CreatePlane(this IFactory<IShape> factory)
        {
            return factory.Create<IPlaneShape>();
        }

        #endregion

        #region Point

        public static IPointShape CreatePoint(this IFactory<IShape> factory,
                                             PointShapeDescriptor descriptor)
        {
            return factory.Create<IPointShape, PointShapeDescriptor>(descriptor);
        }

        public static IPointShape CreatePoint(this IFactory<IShape> factory)
        {
            return factory.Create<IPointShape>();
        }

        #endregion

        #region Rectangle

        public static IRectangleShape CreateRectangle(this IFactory<IShape> factory,
                                             RectangleShapeDescriptor descriptor)
        {
            return factory.Create<IRectangleShape, RectangleShapeDescriptor>(descriptor);
        }

        public static IRectangleShape CreateRectangle(this IFactory<IShape> factory)
        {
            return factory.Create<IRectangleShape>();
        }

        #endregion

        #region Sphere

        public static ISphereShape CreateSphere(this IFactory<IShape> factory,
                                             SphereShapeDescriptor descriptor)
        {
            return factory.Create<ISphereShape, SphereShapeDescriptor>(descriptor);
        }

        public static ISphereShape CreateSphere(this IFactory<IShape> factory)
        {
            return factory.Create<ISphereShape>();
        }

        #endregion

        #region Transformed

        public static ITransformedShape CreateTransformed(this IFactory<IShape> factory,
                                             TransformedShapeDescriptor descriptor)
        {
            return factory.Create<ITransformedShape, TransformedShapeDescriptor>(descriptor);
        }

        public static ITransformedShape CreateTransformed(this IFactory<IShape> factory)
        {
            return factory.Create<ITransformedShape>();
        }

        #endregion

        #region TriangleMesh

        public static ITriangleMeshShape CreateTriangleMesh(this IFactory<IShape> factory,
                                             TriangleMeshShapeDescriptor descriptor)
        {
            return factory.Create<ITriangleMeshShape, TriangleMeshShapeDescriptor>(descriptor);
        }

        public static ITriangleMeshShape CreateTriangleMesh(this IFactory<IShape> factory)
        {
            return factory.Create<ITriangleMeshShape>();
        }

        #endregion

        #region Triangle

        public static ITriangleShape CreateTriangle(this IFactory<IShape> factory,
                                             TriangleShapeDescriptor descriptor)
        {
            return factory.Create<ITriangleShape, TriangleShapeDescriptor>(descriptor);
        }

        public static ITriangleShape CreateTriangle(this IFactory<IShape> factory)
        {
            return factory.Create<ITriangleShape>();
        }

        #endregion

        #endregion

        #region Constrains




        #region CylindricalJoint

        public static ICylindricalJoint CreateCylindricalJoint(this IFactory<IConstraint> factory,
                                      CylindricalJointDescriptor descriptor)
        {
            return factory.Create<ICylindricalJoint, CylindricalJointDescriptor>(descriptor);
        }

        public static ICylindricalJoint CreateCylindricalJoint(this IFactory<IConstraint> factory)
        {
            return factory.Create<ICylindricalJoint>();
        }

        #endregion


        #region DistanceRangeJoint

        public static IDistanceRangeJoint CreateDistanceRangeJoint(this IFactory<IConstraint> factory,
                                      DistanceRangeJointDescriptor descriptor)
        {
            return factory.Create<IDistanceRangeJoint, DistanceRangeJointDescriptor>(descriptor);
        }

        public static IDistanceRangeJoint CreateDistanceRangeJoint(this IFactory<IConstraint> factory)
        {
            return factory.Create<IDistanceRangeJoint>();
        }

        #endregion


        #region FixedJoint

        public static IFixedJoint CreateFixedJoint(this IFactory<IConstraint> factory,
                                      FixedJointDescriptor descriptor)
        {
            return factory.Create<IFixedJoint, FixedJointDescriptor>(descriptor);
        }

        public static IFixedJoint CreateFixedJoint(this IFactory<IConstraint> factory)
        {
            return factory.Create<IFixedJoint>();
        }

        #endregion

        #region HingeJoint

        public static IHingeJoint CreateHingeJoint(this IFactory<IConstraint> factory,
                                      HingeJointDescriptor descriptor)
        {
            return factory.Create<IHingeJoint, HingeJointDescriptor>(descriptor);
        }

        public static IHingeJoint CreateHingeJoint(this IFactory<IConstraint> factory)
        {
            return factory.Create<IHingeJoint>();
        }

        #endregion

        #region NoRotationJoint

        public static INoRotationJoint CreateNoRotationJoint(this IFactory<IConstraint> factory,
                                           NoRotationJointDescriptor descriptor)
        {
            return factory.Create<INoRotationJoint, NoRotationJointDescriptor>(descriptor);
        }

        public static INoRotationJoint CreateNoRotationJoint(this IFactory<IConstraint> factory)
        {
            return factory.Create<INoRotationJoint>();
        }

        #endregion


        #region PointOnLineJoint

        public static IPointOnLineJoint CreatePointOnLineJoint(this IFactory<IConstraint> factory,
                                           PointOnLineJointDescriptor descriptor)
        {
            return factory.Create<IPointOnLineJoint, PointOnLineJointDescriptor>(descriptor);
        }

        public static IPointOnLineJoint CreatePointOnLineJoint(this IFactory<IConstraint> factory)
        {
            return factory.Create<IPointOnLineJoint>();
        }

        #endregion

        #region PointOnPlaneJoint

        public static IPointOnPlaneJoint CreatePointOnPlaneJoint(this IFactory<IConstraint> factory,
                                           PointOnPlaneJointDescriptor descriptor)
        {
            return factory.Create<IPointOnPlaneJoint, PointOnPlaneJointDescriptor>(descriptor);
        }

        public static IPointOnPlaneJoint CreatePointOnPlaneJoint(this IFactory<IConstraint> factory)
        {
            return factory.Create<IPointOnPlaneJoint>();
        }

        #endregion


        #region PrismaticJoint

        public static IPrismaticJoint CreatePrismaticJoint(this IFactory<IConstraint> factory,
                                           PrismaticJointDescriptor descriptor)
        {
            return factory.Create<IPrismaticJoint, PrismaticJointDescriptor>(descriptor);
        }

        public static IPrismaticJoint CreatePrismaticJoint(this IFactory<IConstraint> factory)
        {
            return factory.Create<IPrismaticJoint>();
        }

        #endregion



        #region SphericalJoint

        public static ISphericalJoint CreateSphericalJoint(this IFactory<IConstraint> factory,
                                           SphericalJointDescriptor descriptor)
        {
            return factory.Create<ISphericalJoint, SphericalJointDescriptor>(descriptor);
        }

        public static ISphericalJoint CreateSphericalJoint(this IFactory<IConstraint> factory)
        {
            return factory.Create<ISphericalJoint>();
        }

        #endregion

        #endregion

        #region Actors

        #region RigidBody
        public static IRigidBody 
            CreateRigidBody(this IFactory<IActor> factory,
                                                    RigidBodyDescriptor descriptor)
        {
            return factory.Create<IRigidBody, RigidBodyDescriptor>(descriptor);
        }

        public static IRigidBody CreateRigidBody(this IFactory<IActor> factory)
        {
            return factory.Create<IRigidBody>();
        }
        #endregion

        #endregion

        #region Material
        public static IMaterial CreateMaterial(this IFactory<IMaterial> factory,
                                                    MaterialDescriptor descriptor)
        {
            return factory.Create<IMaterial, MaterialDescriptor>(descriptor);
        }

        public static IMaterial CreateMaterial(this IFactory<IMaterial> factory)
        {
            return factory.Create<IMaterial>();
        }
        #endregion

        #region Fixtures

        #region SimpleFixture
        public static ISimpleFixture CreateSimpleFixture(this IFactory<IFixture> factory,
                                                    FixtureDescriptor descriptor)
        {
            return factory.Create<ISimpleFixture, FixtureDescriptor>(descriptor);
        }

        public static ISimpleFixture CreateSimpleFixture(this IFactory<IFixture> factory)
        {
            return factory.Create<ISimpleFixture>();
        }
        #endregion

        #region CompositeFixture
        public static ICompositeFixture CreateCompositeFixture(this IFactory<IFixture> factory,
                                                    FixtureDescriptor descriptor)
        {
            return factory.Create<ICompositeFixture, FixtureDescriptor>(descriptor);
        }

        public static ICompositeFixture CreateCompositeFixture(this IFactory<IFixture> factory)
        {
            return factory.Create<ICompositeFixture>();
        }
        #endregion

        #endregion

        #region ShapePositioner

        public static IShapePositioner CreateShapePositioner(this IFactory<IShapePositioner> factory,
                                                    ShapePositionerDescriptor descriptor)
        {
            return factory.Create<IShapePositioner, ShapePositionerDescriptor>(descriptor);
        }

        public static IShapePositioner CreateShapePositioner(this IFactory<IShapePositioner> factory)
        {
            return factory.Create<IShapePositioner>();
        }
        #endregion

    }

}