
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
    public class DigitalRuneNoRotationJoint: BaseNoRotationJoint, IDigitalRuneTwoRigidBodiesConstraint 
    {
        internal NoRotationConstraint WrappedNoRotationJoint { get; private set; }

        internal DigitalRuneNoRotationJoint(NoRotationJointDescriptor descriptor)
        {
            WrappedNoRotationJoint = new NoRotationConstraint();

            #region set RigidBodies
            if (!(descriptor.RigidBodyA is RigidBody))
                throw new ArgumentException(String.Format("The type of the property 'RigidBodyA' must be '{0}'.", typeof(RigidBody)));
            WrappedNoRotationJoint.BodyA = ((RigidBody)descriptor.RigidBodyA).WrappedRigidBody;
            _rigidBodyA = descriptor.RigidBodyA;

            if (!(descriptor.RigidBodyB is RigidBody))
                throw new ArgumentException("The type of the property 'RigidBodyB' must be 'System.Physics.DigitalRune.RigidBody'.");
            WrappedNoRotationJoint.BodyB = ((RigidBody)descriptor.RigidBodyB).WrappedRigidBody;
            _rigidBodyB = descriptor.RigidBodyB;
            #endregion
            WrappedNoRotationJoint.AnchorOrientationALocal = descriptor.AnchorOrientationALocal.ToDigitalRune();
            WrappedNoRotationJoint.AnchorOrientationBLocal = descriptor.AnchorOrientationBLocal.ToDigitalRune();


            Descriptor = descriptor;
        }

        
        public override Matrix3x3 AnchorOrientationALocal
        {
            get { return WrappedNoRotationJoint.AnchorOrientationALocal.ToStandard(); }

        }
        public override Matrix3x3 AnchorOrientationBLocal
        {
            get { return WrappedNoRotationJoint.AnchorOrientationBLocal.ToStandard(); }

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