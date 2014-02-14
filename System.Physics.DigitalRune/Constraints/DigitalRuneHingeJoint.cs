using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.Constraints.BaseImplementations;
using System.Physics.Constraints.Descriptors;
using System.Physics.DigitalRune.RigidBodies;
using System.Physics.DigitalRune;
using DigitalRune.Physics.Constraints;

namespace System.Physics.DigitalRune.Constraints
{
    public class DigitalRuneHingeJoint : BaseHingeJoint, IDigitalRuneTwoRigidBodiesConstraint
    {
        private IRigidBody _rigidBodyA;
        private IRigidBody _rigidBodyB;

        internal DigitalRuneHingeJoint(HingeJointDescriptor descriptor)
        {
            WrappedHingeJoint = new HingeJoint();

            #region set RigidBodies
            if (!(descriptor.RigidBodyA is RigidBody))
                throw new ArgumentException(String.Format("The type of the property 'RigidBodyA' must be '{0}'.", typeof(RigidBody)));
            WrappedHingeJoint.BodyA = ((RigidBody)descriptor.RigidBodyA).WrappedRigidBody;
            _rigidBodyA = descriptor.RigidBodyA;

            if (!(descriptor.RigidBodyB is RigidBody))
                throw new ArgumentException("The type of the property 'RigidBodyB' must be 'System.Physics.DigitalRune.RigidBody'.");
            WrappedHingeJoint.BodyB = ((RigidBody)descriptor.RigidBodyB).WrappedRigidBody;
            _rigidBodyB = descriptor.RigidBodyB;
            #endregion
            WrappedHingeJoint.AnchorPoseALocal = descriptor.AnchorPoseALocal.ToDigitalRune();
            WrappedHingeJoint.AnchorPoseBLocal = descriptor.AnchorPoseBLocal.ToDigitalRune();
            WrappedHingeJoint.Maximum = descriptor.MaximumAngle;
            WrappedHingeJoint.Minimum = descriptor.MinimumAngle;

            Descriptor = descriptor;
        }

        internal HingeJoint WrappedHingeJoint { get; private set; }

        public override Matrix4x4 AnchorPoseALocal
        {
            get { return WrappedHingeJoint.AnchorPoseALocal.ToStandard(); }

        }

        public override Matrix4x4 AnchorPoseBLocal
        {
            get { return WrappedHingeJoint.AnchorPoseBLocal.ToStandard(); }

        }

        public override float MaximumAngle
        {
            get { return WrappedHingeJoint.Maximum; }

        }

        public override float MinimumAngle
        {
            get { return WrappedHingeJoint.Minimum; }

        }

        public override float Angle
        {
            get { return WrappedHingeJoint.RelativePosition; }
        }

        public override float RelativeAngularVelocity
        {
            get { return WrappedHingeJoint.RelativeAngularVelocity; }
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