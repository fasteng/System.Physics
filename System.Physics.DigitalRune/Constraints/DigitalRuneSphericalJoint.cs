
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
    public class DigitalRuneSphericalJoint : BaseSphericalJoint, IDigitalRuneTwoRigidBodiesConstraint
    {
        internal BallJoint WrappedSphericalJoint { get; private set; }

        internal DigitalRuneSphericalJoint(SphericalJointDescriptor descriptor)
        {
            WrappedSphericalJoint = new BallJoint();

            #region set RigidBodies
            if (!(descriptor.RigidBodyA is RigidBody))
                throw new ArgumentException(String.Format("The type of the property 'RigidBodyA' must be '{0}'.", typeof(RigidBody)));
            WrappedSphericalJoint.BodyA = ((RigidBody)descriptor.RigidBodyA).WrappedRigidBody;
            _rigidBodyA = descriptor.RigidBodyA;

            if (!(descriptor.RigidBodyB is RigidBody))
                throw new ArgumentException("The type of the property 'RigidBodyB' must be 'System.Physics.DigitalRune.RigidBody'.");
            WrappedSphericalJoint.BodyB = ((RigidBody)descriptor.RigidBodyB).WrappedRigidBody;
            _rigidBodyB = descriptor.RigidBodyB;
            #endregion
            WrappedSphericalJoint.AnchorPositionALocal = descriptor.AnchorPositionALocal.ToDigitalRune();
            WrappedSphericalJoint.AnchorPositionBLocal = descriptor.AnchorPositionBLocal.ToDigitalRune();

            Descriptor = descriptor;
        }
        public override Vector3 AnchorPositionALocal
        {
            get { return WrappedSphericalJoint.AnchorPositionALocal.ToStandard(); }
        }
        public override Vector3 AnchorPositionBLocal
        {
            get { return WrappedSphericalJoint.AnchorPositionBLocal.ToStandard(); }
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