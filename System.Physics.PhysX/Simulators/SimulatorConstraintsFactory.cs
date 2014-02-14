using System.Maths;
using System.Physics.Constraints;
using System.Physics.Constraints.BaseImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.Factories;
using System.Physics.PhysX.RigidBodies;
using System.Physics.RigidBodies;
using StillDesign.PhysX;
using PX = StillDesign.PhysX;

namespace System.Physics.PhysX.Simulators
{

    public partial class PhysXSimulator
    {
        private class SimulatorConstraintsFactory :
            BaseMultipleFactory<IConstraint>,
            IFactoryOf<ISphericalJoint, SphericalJointDescriptor>
            //IFactoryOf<IHingeJoint, HingeJointDescriptor>,
            //IFactoryOf<IPrismaticJoint, PrismaticJointDescriptor>,
            //IFactoryOf<ICylindricalJoint, CylindricalJointDescriptor>,
            //IFactoryOf<IFixedJoint, FixedJointDescriptor>,
            //IFactoryOf<IDistanceRangeJoint, DistanceRangeJointDescriptor>,
            //IFactoryOf<IPointOnLineJoint, PointOnLineJointDescriptor>,
            //IFactoryOf<IPointOnPlaneJoint, PointOnPlaneJointDescriptor>
        {
            private readonly PhysXSimulator _simulator;
            public SimulatorConstraintsFactory(PhysXSimulator simulator)
            {
                _simulator = simulator;
            }

            ISphericalJoint IFactoryOf<ISphericalJoint, SphericalJointDescriptor>.Create(SphericalJointDescriptor descriptor)
            {
                return new SphericalJoint(_simulator, descriptor);
            }

            //IHingeJoint IFactoryOf<IHingeJoint, HingeJointDescriptor>.Create(HingeJointDescriptor descriptor)
            //{
            //    return new HingeJoint(_simulator, descriptor);
            //}

            //IPrismaticJoint IFactoryOf<IPrismaticJoint, PrismaticJointDescriptor>.Create(PrismaticJointDescriptor descriptor)
            //{
            //    return new PrismaticJoint(_simulator, descriptor);
            //}

            //ICylindricalJoint IFactoryOf<ICylindricalJoint, CylindricalJointDescriptor>.Create(CylindricalJointDescriptor descriptor)
            //{
            //    return new CylindricalJoint(_simulator, descriptor);
            //}

            //IFixedJoint IFactoryOf<IFixedJoint, FixedJointDescriptor>.Create(FixedJointDescriptor descriptor)
            //{
            //    return new FixedJoint(_simulator, descriptor);
            //}

            //IDistanceRangeJoint IFactoryOf<IDistanceRangeJoint, DistanceRangeJointDescriptor>.Create(DistanceRangeJointDescriptor descriptor)
            //{
            //    return new DistanceRangeJoint(_simulator, descriptor);
            //}

            //IPointOnLineJoint IFactoryOf<IPointOnLineJoint, PointOnLineJointDescriptor>.Create(PointOnLineJointDescriptor descriptor)
            //{
            //    return new PointOnLineJoint(_simulator, descriptor);
            //}

            //IPointOnPlaneJoint IFactoryOf<IPointOnPlaneJoint, PointOnPlaneJointDescriptor>.Create(PointOnPlaneJointDescriptor descriptor)
            //{
            //    return new PointOnPlaneJoint(_simulator, descriptor);
            //}

        }
    }

    //public class PointOnPlaneJoint : BasePointOnPlaneJoint
    //{
    //    private PointInPlaneJoint _wrappedPointInPlaneJoint;
    //    private IRigidBody _rigidBodyA;
    //    private IRigidBody _rigidBodyB;

    //    internal PointOnPlaneJoint(PhysXSimulator simulator, PointOnPlaneJointDescriptor descriptor)
    //    {
    //        var pointInPlaneJointDescription = new PointInPlaneJointDescription
    //        {
    //            Actor1 = ((RigidBody)descriptor.RigidBodyA).WrappedActor,
    //            Actor2 = ((RigidBody)descriptor.RigidBodyB).WrappedActor
    //        };
    //        _rigidBodyA = descriptor.RigidBodyA;
    //        _rigidBodyB = descriptor.RigidBodyB;
    //        _wrappedPointInPlaneJoint = (PX.PointInPlaneJoint)simulator._wrappedScene.CreateJoint(pointInPlaneJointDescription);
    //        Descriptor = descriptor;
    //    }

    //    public override IRigidBody RigidBodyA { get { return _rigidBodyA; } }
    //    public override IRigidBody RigidBodyB { get { return _rigidBodyB; } }

    //    public override Vector3 AnchorPositionALocal { get; }
    //    public override Vector3 XAxisALocal { get; }
    //    public override Vector3 YAxisALocal { get; }
    //    public override Vector3 AnchorPositionBLocal { get; }
    //    public override float MaximumDistanceX { get; }
    //    public override float MinimumDistanceX { get; }
    //    public override float MaximumDistanceY { get; }
    //    public override float MinimumDistanceY { get; }
    //    public override Vector2 RelativePosition
    //    {
    //        get { throw new NotImplementedException(); }
    //    }
    //}

    //public class PointOnLineJoint : BasePointOnLineJoint
    //{
    //    private PX.PointOnLineJoint _wrappedPointOnLineJoint;
    //    private IRigidBody _rigidBodyA;
    //    private IRigidBody _rigidBodyB;

    //    internal PointOnLineJoint(PhysXSimulator simulator, PointOnLineJointDescriptor descriptor)
    //    {
    //        var pointOnLineJointDescription = new PointOnLineJointDescription
    //        {
    //            Actor1 = ((RigidBody)descriptor.RigidBodyA).WrappedActor,
    //            Actor2 = ((RigidBody)descriptor.RigidBodyB).WrappedActor
    //        };
    //        _rigidBodyA = descriptor.RigidBodyA;
    //        _rigidBodyB = descriptor.RigidBodyB;
    //        _wrappedPointOnLineJoint = (PX.PointOnLineJoint)simulator._wrappedScene.CreateJoint(pointOnLineJointDescription);
    //        Descriptor = descriptor;
    //    }

    //    public override IRigidBody RigidBodyA { get { return _rigidBodyA; } }
    //    public override IRigidBody RigidBodyB { get { return _rigidBodyB; } }

    //    public override Vector3 AnchorPositionALocal { get; }
    //    public override Vector3 AxisALocal { get; }
    //    public override Vector3 AnchorPositionBLocal { get; }
    //    public override float MaximumDistance { get; }
    //    public override float MinimumDistance { get; }

    //    public override float Distance
    //    {
    //        get { throw new NotImplementedException(); }
    //    }
    //}

    //public class DistanceRangeJoint : BaseDistanceRangeJoint
    //{
    //    private PX.FixedJoint _wrappedFixedJoint;
    //    private IRigidBody _rigidBodyA;
    //    private IRigidBody _rigidBodyB;

    //    internal DistanceRangeJoint(PhysXSimulator simulator, DistanceRangeJointDescriptor descriptor)
    //    {
    //        var fixedJointDescription = new FixedJointDescription
    //        {
    //            Actor1 = ((RigidBody)descriptor.RigidBodyA).WrappedActor,
    //            Actor2 = ((RigidBody)descriptor.RigidBodyB).WrappedActor
    //        };
    //        _rigidBodyA = descriptor.RigidBodyA;
    //        _rigidBodyB = descriptor.RigidBodyB;
    //        _wrappedFixedJoint = (PX.FixedJoint)simulator._wrappedScene.CreateJoint(fixedJointDescription);
    //        Descriptor = descriptor;
    //    }

    //    public override IRigidBody RigidBodyA { get { return _rigidBodyA; } }
    //    public override IRigidBody RigidBodyB { get { return _rigidBodyB; } }
    //    public override Vector3 AnchorPositionALocal { get; }
    //    public override Vector3 AnchorPositionBLocal { get; }
    //    public override float MinimumDistance { get; }
    //    public override float MaximumDistance { get; }
    //}

    //public class FixedJoint : BaseFixedJoint
    //{
    //    private PX.FixedJoint _wrappedFixedJoint;
    //    private IRigidBody _rigidBodyA;
    //    private IRigidBody _rigidBodyB;

    //    internal FixedJoint(PhysXSimulator simulator, FixedJointDescriptor descriptor)
    //    {
    //        var fixedJointDescription = new FixedJointDescription
    //        {
    //            Actor1 = ((RigidBody)descriptor.RigidBodyA).WrappedActor,
    //            Actor2 = ((RigidBody)descriptor.RigidBodyB).WrappedActor
    //        };
    //        _rigidBodyA = descriptor.RigidBodyA;
    //        _rigidBodyB = descriptor.RigidBodyB;
    //        _wrappedFixedJoint = (PX.FixedJoint)simulator._wrappedScene.CreateJoint(fixedJointDescription);
    //        Descriptor = descriptor;
    //    }

    //    public override IRigidBody RigidBodyA { get { return _rigidBodyA; } }
    //    public override IRigidBody RigidBodyB { get { return _rigidBodyB; } }
    //    public override Matrix4x4 AnchorPoseALocal { get; }
    //    public override Matrix4x4 AnchorPoseBLocal { get; }
    //}

    //public class CylindricalJoint : BaseCylindricalJoint
    //{
    //    private PX.CylindricalJoint _wrappedCylindricalJoint;
    //    private IRigidBody _rigidBodyA;
    //    private IRigidBody _rigidBodyB;

    //    internal CylindricalJoint(PhysXSimulator simulator, CylindricalJointDescriptor descriptor)
    //    {
    //        var cylindricalJointDescription = new CylindricalJointDescription
    //        {
    //            Actor1 = ((RigidBody)descriptor.RigidBodyA).WrappedActor,
    //            Actor2 = ((RigidBody)descriptor.RigidBodyB).WrappedActor
    //        };
    //        _rigidBodyA = descriptor.RigidBodyA;
    //        _rigidBodyB = descriptor.RigidBodyB;
    //        _wrappedCylindricalJoint = (PX.CylindricalJoint)simulator._wrappedScene.CreateJoint(cylindricalJointDescription);
    //        Descriptor = descriptor;
    //    }

    //    public override IRigidBody RigidBodyA { get { return _rigidBodyA; } }
    //    public override IRigidBody RigidBodyB { get { return _rigidBodyB; } }
    //    public override Matrix4x4 AnchorPoseALocal { get; }
    //    public override Matrix4x4 AnchorPoseBLocal { get; }
    //    public override float MaximumAngle { get; }
    //    public override float MinimumAngle { get; }
    //    public override float MaximumDistance { get; }
    //    public override float MinimumDistance { get; }
    //}

    //public class PrismaticJoint : BasePrismaticJoint
    //{
    //    private PX.PrismaticJoint _wrappedPrismaticJoint;
    //    private IRigidBody _rigidBodyA;
    //    private IRigidBody _rigidBodyB;

    //    internal PrismaticJoint(PhysXSimulator simulator, PrismaticJointDescriptor descriptor)
    //    {
    //        var prismaticJointDescription = new PrismaticJointDescription
    //        {
    //            Actor1 = ((RigidBody)descriptor.RigidBodyA).WrappedActor,
    //            Actor2 = ((RigidBody)descriptor.RigidBodyB).WrappedActor
    //        };
    //        _rigidBodyA = descriptor.RigidBodyA;
    //        _rigidBodyB = descriptor.RigidBodyB;
    //        _wrappedPrismaticJoint = (PX.PrismaticJoint)simulator._wrappedScene.CreateJoint(prismaticJointDescription);
    //        Descriptor = descriptor;
    //    }

    //    public override IRigidBody RigidBodyA { get { return _rigidBodyA; } }
    //    public override IRigidBody RigidBodyB { get { return _rigidBodyB; } }
    //    public override Matrix4x4 AnchorPoseALocal { get; }
    //    public override Matrix4x4 AnchorPoseBLocal { get; }
    //    public override float MaximumDistance { get; }
    //    public override float MinimumDistance { get; }
    //}

    //public class HingeJoint : BaseHingeJoint
    //{
    //    private RevoluteJoint _wrappedRevoluteJoint;
    //    private IRigidBody _rigidBodyA;
    //    private IRigidBody _rigidBodyB;

    //    internal HingeJoint(PhysXSimulator simulator, HingeJointDescriptor descriptor)
    //    {
    //        var revoluteJointDescription = new SphericalJointDescription
    //                                            {
    //                                                Actor1 = ((RigidBody)descriptor.RigidBodyA).WrappedActor,
    //                                                Actor2 = ((RigidBody)descriptor.RigidBodyB).WrappedActor,
    //                                                LocalAnchor1 = descriptor.AnchorPoseALocal.ExtractPosition().ToPhysX(),
    //                                                LocalAnchor2 = descriptor.AnchorPoseBLocal.ExtractPosition().ToPhysX(),
    //                                            };
    //        _rigidBodyA = descriptor.RigidBodyA;
    //        _rigidBodyB = descriptor.RigidBodyB;

    //        _wrappedRevoluteJoint = (PX.RevoluteJoint)simulator._wrappedScene.CreateJoint(revoluteJointDescription);
    //        Descriptor = descriptor;
    //    }

    //    public override IRigidBody RigidBodyA { get { return _rigidBodyA; } }
    //    public override IRigidBody RigidBodyB { get { return _rigidBodyB; } }
    //    public override Matrix4x4 AnchorPoseALocal { get{} }
    //    public override Matrix4x4 AnchorPoseBLocal { get { }
    //    }
    //    public override float MaximumAngle { get{} }
    //    public override float MinimumAngle { get{}  }

    //    public override float Angle
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public override float RelativeAngularVelocity
    //    {
    //        get { throw new NotImplementedException(); }
    //    }
    //}

    public class SphericalJoint : BaseSphericalJoint
    {
        private PX.SphericalJoint _wrappedSphericalJoint;
        private IRigidBody _rigidBodyA;
        private IRigidBody _rigidBodyB;
        private Vector3 _anchorPositionALocal;
        private Vector3 _anchorPositionBLocal;

        internal SphericalJoint(PhysXSimulator simulator, SphericalJointDescriptor descriptor)
        {
            Actor wrappedActorA = ((RigidBody) descriptor.RigidBodyA).WrappedActor;
            if (!wrappedActorA.IsDynamic)
            {
                var vector4 = GMath.mul(new Vector4(descriptor.AnchorPositionALocal, 1), descriptor.RigidBodyA.Pose);
                descriptor.AnchorPositionALocal = new Vector3(vector4.X, vector4.Y, vector4.Z);
                wrappedActorA = null;
            }


            Actor wrappedActorB = ((RigidBody) descriptor.RigidBodyB).WrappedActor;
            if (!wrappedActorB.IsDynamic)
            {
                var vector4 = GMath.mul(new Vector4(descriptor.AnchorPositionBLocal, 1), descriptor.RigidBodyB.Pose);
                descriptor.AnchorPositionBLocal = new Vector3(vector4.X, vector4.Y, vector4.Z);
                wrappedActorB = null;
            }

            var sphericalJointDescription = new SphericalJointDescription
                                                {
                                                    Actor1 = wrappedActorA,
                                                    Actor2 = wrappedActorB,
                                                    LocalAnchor1 = descriptor.AnchorPositionALocal.ToPhysX(),
                                                    LocalAnchor2 = descriptor.AnchorPositionBLocal.ToPhysX(),
                                                    JointFlags = JointFlag.CollisionEnabled
                                                };
            _wrappedSphericalJoint = (PX.SphericalJoint)simulator._wrappedScene.CreateJoint(sphericalJointDescription);
            _rigidBodyA = descriptor.RigidBodyA;
            _rigidBodyB = descriptor.RigidBodyB;
            _anchorPositionALocal = descriptor.AnchorPositionALocal;
            _anchorPositionBLocal = descriptor.AnchorPositionBLocal;
            UserData = descriptor.UserData;
        }

        public override IRigidBody RigidBodyA
        {
            get { return _rigidBodyA; }
        }
        public override IRigidBody RigidBodyB
        {
            get { return _rigidBodyB; }
        }
        public override Vector3 AnchorPositionALocal
        {
            get { return _anchorPositionALocal; }
        }
        public override Vector3 AnchorPositionBLocal
        {
            get { return _anchorPositionBLocal; }
        }
    }
}
