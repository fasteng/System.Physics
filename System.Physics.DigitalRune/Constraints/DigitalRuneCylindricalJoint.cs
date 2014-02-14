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
    public class DigitalRuneCylindricalJoint : BaseCylindricalJoint, IDigitalRuneTwoRigidBodiesConstraint
    {
        internal CylindricalJoint WrappedCylindricalJoint { get; private set; }

        internal DigitalRuneCylindricalJoint(CylindricalJointDescriptor descriptor)
        {
            WrappedCylindricalJoint = new CylindricalJoint();

            #region set RigidBodies
            if (!(descriptor.RigidBodyA is RigidBody))
                throw new ArgumentException(String.Format("The type of the property 'RigidBodyA' must be '{0}'.", typeof(RigidBody)));
            WrappedCylindricalJoint.BodyA = ((RigidBody)descriptor.RigidBodyA).WrappedRigidBody;
            _rigidBodyA = descriptor.RigidBodyA;

            if (!(descriptor.RigidBodyB is RigidBody))
                throw new ArgumentException("The type of the property 'RigidBodyB' must be 'System.Physics.DigitalRune.RigidBody'.");
            WrappedCylindricalJoint.BodyB = ((RigidBody)descriptor.RigidBodyB).WrappedRigidBody;
            _rigidBodyB = descriptor.RigidBodyB;
            #endregion
            WrappedCylindricalJoint.AnchorPoseALocal = descriptor.AnchorPoseALocal.ToDigitalRune();
            WrappedCylindricalJoint.AnchorPoseBLocal = descriptor.AnchorPoseBLocal.ToDigitalRune();
            WrappedCylindricalJoint.AngularMaximum = descriptor.MaximumAngle;
            WrappedCylindricalJoint.AngularMinimum = descriptor.MinimumAngle;
            WrappedCylindricalJoint.LinearMaximum = descriptor.MaximumDistance;
            WrappedCylindricalJoint.LinearMinimum = descriptor.MinimumDistance; 


            Descriptor = descriptor;
        }

        public override Matrix4x4 AnchorPoseALocal
        {
            get { return WrappedCylindricalJoint.AnchorPoseALocal.ToStandard(); }

        }
        public override Matrix4x4 AnchorPoseBLocal
        {
            get { return WrappedCylindricalJoint.AnchorPoseBLocal.ToStandard(); }

        }
        public override float MaximumAngle
        {
            get { return WrappedCylindricalJoint.AngularMaximum; }

        }
        public override float MinimumAngle
        {
            get { return WrappedCylindricalJoint.AngularMinimum; }

        }
        public override float MaximumDistance
        {
            get { return WrappedCylindricalJoint.LinearMaximum; }

        }
        public override float MinimumDistance
        {
            get { return WrappedCylindricalJoint.LinearMinimum; }


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
 
        //todo poner el maximumLinear
    }
}