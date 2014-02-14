
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
    public class DigitalRunePrismaticJoint : BasePrismaticJoint, IDigitalRuneTwoRigidBodiesConstraint
    {
        internal PrismaticJoint WrappedPrismaticJoint { get; private set; }

        internal DigitalRunePrismaticJoint(PrismaticJointDescriptor descriptor)
        {
            WrappedPrismaticJoint = new PrismaticJoint();

            #region set RigidBodies
            if (!(descriptor.RigidBodyA is RigidBody))
                throw new ArgumentException(String.Format("The type of the property 'RigidBodyA' must be '{0}'.", typeof(RigidBody)));
            WrappedPrismaticJoint.BodyA = ((RigidBody)descriptor.RigidBodyA).WrappedRigidBody;
            _rigidBodyA = descriptor.RigidBodyA;

            if (!(descriptor.RigidBodyB is RigidBody))
                throw new ArgumentException("The type of the property 'RigidBodyB' must be 'System.Physics.DigitalRune.RigidBody'.");
            WrappedPrismaticJoint.BodyB = ((RigidBody)descriptor.RigidBodyB).WrappedRigidBody;
            _rigidBodyB = descriptor.RigidBodyB;
            #endregion
            WrappedPrismaticJoint.AnchorPoseALocal = descriptor.AnchorPoseALocal.ToDigitalRune();
            WrappedPrismaticJoint.AnchorPoseBLocal = descriptor.AnchorPoseBLocal.ToDigitalRune();
            WrappedPrismaticJoint.Maximum = descriptor.MaximumDistance;
            WrappedPrismaticJoint.Minimum = descriptor.MinimumDistance; 



            Descriptor = descriptor;
        }
        public override Matrix4x4 AnchorPoseALocal
        {
            get { return WrappedPrismaticJoint.AnchorPoseALocal.ToStandard(); }

        }
        public override Matrix4x4 AnchorPoseBLocal
        {
            get { return WrappedPrismaticJoint.AnchorPoseBLocal.ToStandard(); }

        }
        public override float MaximumDistance
        {
            get { return WrappedPrismaticJoint.Maximum; }

        }
        public override float MinimumDistance
        {
            get { return WrappedPrismaticJoint.Minimum; }

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