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
    public class DigitalRuneFixedJoint: BaseFixedJoint, IDigitalRuneTwoRigidBodiesConstraint
    {
        internal FixedJoint WrappedFixedJoint { get; private set; }

        internal DigitalRuneFixedJoint(FixedJointDescriptor descriptor)
        {
            WrappedFixedJoint = new FixedJoint();

            #region set RigidBodies
            if (!(descriptor.RigidBodyA is RigidBody))
                throw new ArgumentException(String.Format("The type of the property 'RigidBodyA' must be '{0}'.", typeof(RigidBody)));
            WrappedFixedJoint.BodyA = ((RigidBody)descriptor.RigidBodyA).WrappedRigidBody;
            _rigidBodyA = descriptor.RigidBodyA;

            if (!(descriptor.RigidBodyB is RigidBody))
                throw new ArgumentException("The type of the property 'RigidBodyB' must be 'System.Physics.DigitalRune.RigidBody'.");
            WrappedFixedJoint.BodyB = ((RigidBody)descriptor.RigidBodyB).WrappedRigidBody;
            _rigidBodyB = descriptor.RigidBodyB;
            #endregion
            WrappedFixedJoint.AnchorPoseALocal = descriptor.AnchorPoseALocal.ToDigitalRune();
            WrappedFixedJoint.AnchorPoseBLocal = descriptor.AnchorPoseBLocal.ToDigitalRune(); 



            Descriptor = descriptor;
        }

        public override Matrix4x4 AnchorPoseALocal
        {
            get { return WrappedFixedJoint.AnchorPoseALocal.ToStandard(); }

        }
        public override Matrix4x4 AnchorPoseBLocal
        {
            get { return WrappedFixedJoint.AnchorPoseBLocal.ToStandard(); }

        }        private IRigidBody _rigidBodyA;
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