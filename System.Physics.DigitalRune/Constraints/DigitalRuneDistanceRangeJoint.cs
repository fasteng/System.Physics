using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.Constraints;
using System.Physics.Constraints.BaseImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.DigitalRune.RigidBodies;
using System.Physics.DigitalRune;
using DigitalRune.Physics.Constraints;

namespace System.Physics.DigitalRune.Constraints
{
    public class DigitalRuneDistanceRangeJoint: BaseDistanceRangeJoint, IDigitalRuneTwoRigidBodiesConstraint
    {
        internal DistanceLimit WrappedDistanceRangeJoint { get; private set; }

        internal DigitalRuneDistanceRangeJoint(DistanceRangeJointDescriptor descriptor)
        {
            WrappedDistanceRangeJoint = new DistanceLimit();

            #region set RigidBodies
            if (!(descriptor.RigidBodyA is RigidBody))
                throw new ArgumentException(String.Format("The type of the property 'RigidBodyA' must be '{0}'.", typeof(RigidBody)));
            WrappedDistanceRangeJoint.BodyA = ((RigidBody)descriptor.RigidBodyA).WrappedRigidBody;
            _rigidBodyA = descriptor.RigidBodyA;

            if (!(descriptor.RigidBodyB is RigidBody))
                throw new ArgumentException("The type of the property 'RigidBodyB' must be 'System.Physics.DigitalRune.RigidBody'.");
            WrappedDistanceRangeJoint.BodyB = ((RigidBody)descriptor.RigidBodyB).WrappedRigidBody;
            _rigidBodyB = descriptor.RigidBodyB;
            #endregion
            WrappedDistanceRangeJoint.AnchorPositionALocal = descriptor.AnchorPositionALocal.ToDigitalRune();
            WrappedDistanceRangeJoint.AnchorPositionBLocal = descriptor.AnchorPositionBLocal.ToDigitalRune();
            WrappedDistanceRangeJoint.MinDistance = descriptor.MinimumDistance;
            WrappedDistanceRangeJoint.MaxDistance = descriptor.MaximumDistance;

            Descriptor = descriptor;
        }
        public override Vector3 AnchorPositionALocal
        {
            get { return WrappedDistanceRangeJoint.AnchorPositionALocal.ToStandard(); }

        }
        public override Vector3 AnchorPositionBLocal
        {
            get { return WrappedDistanceRangeJoint.AnchorPositionBLocal.ToStandard(); }

        }
        public override float MinimumDistance
        {
            get { return WrappedDistanceRangeJoint.MinDistance; }

        }
        public override float MaximumDistance
        {
            get { return WrappedDistanceRangeJoint.MaxDistance; }

        }
        private IRigidBody _rigidBodyA;
        private IRigidBody _rigidBodyB;
        public override IRigidBody RigidBodyA
        {
            get { return _rigidBodyA; }
            
        }

        public override IRigidBody RigidBodyB
        {
            get { return _rigidBodyB; }
            
        }

    }
}