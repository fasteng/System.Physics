
using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.Constraints.BaseImplementations;
using System.Physics.Constraints.Descriptors;

namespace System.Physics.Constraints.DefaultImplementations
{
    public class DefaultPrismaticJoint : BasePrismaticJoint
    {
        private IRigidBody _rigidBodyA;
        private IRigidBody _rigidBodyB;
        private Matrix4x4 _anchorPoseALocal;
        private Matrix4x4 _anchorPoseBLocal;
        private float _maximumDistance;
        private float _minimumDistance;

        public DefaultPrismaticJoint(PrismaticJointDescriptor descriptor)
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

        public override float MaximumDistance
        {
            get { return _maximumDistance; }
        }

        public override float MinimumDistance
        {
            get { return _minimumDistance; }
        }
    }
}