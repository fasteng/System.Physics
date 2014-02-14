using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.Constraints.BaseImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.DigitalRune.RigidBodies;
using System.Physics.DigitalRune;
using DigitalRune.Physics.Constraints;

namespace System.Physics.DigitalRune.Constraints
{
    public class DigitalRunePointOnLineJoint : BasePointOnLineJoint, IDigitalRuneTwoRigidBodiesConstraint
    {
        private IRigidBody _rigidBodyA;
        private IRigidBody _rigidBodyB;

        internal DigitalRunePointOnLineJoint(PointOnLineJointDescriptor descriptor)
        {
            WrappedPointOnLineJoint = new PointOnLineConstraint();

            #region set RigidBodies
            if (!(descriptor.RigidBodyA is RigidBody))
                throw new ArgumentException(String.Format("The type of the property 'RigidBodyA' must be '{0}'.", typeof(RigidBody)));
            WrappedPointOnLineJoint.BodyA = ((RigidBody)descriptor.RigidBodyA).WrappedRigidBody;
            _rigidBodyA = descriptor.RigidBodyA;

            if (!(descriptor.RigidBodyB is RigidBody))
                throw new ArgumentException("The type of the property 'RigidBodyB' must be 'System.Physics.DigitalRune.RigidBody'.");
            WrappedPointOnLineJoint.BodyB = ((RigidBody)descriptor.RigidBodyB).WrappedRigidBody;
            _rigidBodyB = descriptor.RigidBodyB;
            #endregion
            WrappedPointOnLineJoint.AnchorPositionALocal = descriptor.AnchorPositionALocal.ToDigitalRune();
            WrappedPointOnLineJoint.AxisALocal = descriptor.AxisALocal.ToDigitalRune();
            WrappedPointOnLineJoint.AnchorPositionBLocal = descriptor.AnchorPositionBLocal.ToDigitalRune();
            WrappedPointOnLineJoint.Maximum = descriptor.MaximumDistance;
            WrappedPointOnLineJoint.Minimum = descriptor.MinimumDistance; 


            Descriptor = descriptor;
        }

        internal PointOnLineConstraint WrappedPointOnLineJoint { get; private set; }

        public override Vector3 AnchorPositionALocal
        {
            get { return WrappedPointOnLineJoint.AnchorPositionALocal.ToStandard(); }

        }

        public override Vector3 AxisALocal
        {
            get { return WrappedPointOnLineJoint.AxisALocal.ToStandard(); }

        }

        public override Vector3 AnchorPositionBLocal
        {
            get { return WrappedPointOnLineJoint.AnchorPositionBLocal.ToStandard(); }
 
        }

        public override float MaximumDistance
        {
            get { return WrappedPointOnLineJoint.Maximum; }

        }

        public override float MinimumDistance
        {
            get { return WrappedPointOnLineJoint.Minimum; }
        }

        public override float Distance
        {
            get { return WrappedPointOnLineJoint.RelativePosition; }
        }

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