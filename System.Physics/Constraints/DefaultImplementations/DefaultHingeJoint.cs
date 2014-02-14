
using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.Constraints.BaseImplementations;
using System.Physics.Constraints.Descriptors;

namespace System.Physics.Constraints.DefaultImplementations
{
    public class DefaultHingeJoint : BaseHingeJoint
    {
        private IRigidBody _rigidBodyA;
        private IRigidBody _rigidBodyB;
        private Matrix4x4 _anchorPoseALocal;
        private Matrix4x4 _anchorPoseBLocal;
        private float _maximumAngle;
        private float _minimumAngle;

        public DefaultHingeJoint(HingeJointDescriptor descriptor)
        {
            Descriptor = descriptor;
        }

        public override IRigidBody RigidBodyA
        {
            get { return _rigidBodyA; }
        }

        public override IRigidBody RigidBodyB
        {
            get { return _rigidBodyB; }
        }

        public override Matrix4x4 AnchorPoseALocal
        {
            get { return _anchorPoseALocal; }
        }

        public override Matrix4x4 AnchorPoseBLocal
        {
            get { return _anchorPoseBLocal; }
        }

        public override float MaximumAngle
        {
            get { return _maximumAngle; }
        }

        public override float MinimumAngle
        {
            get { return _minimumAngle; }
        }

        public override float Angle
        {
            get { throw new NotImplementedException(); }
        }

        public override float RelativeAngularVelocity
        {
            get { throw new NotImplementedException(); }
        }
    }
}