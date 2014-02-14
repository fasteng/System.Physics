using System.Maths;
using System.Physics.RigidBodies;

namespace System.Physics.Constraints.Descriptors
{
    public struct PrismaticJointDescriptor : IDescriptor
    {
        public PrismaticJointDescriptor(Matrix4x4 anchorPoseALocal, Matrix4x4 anchorPoseBLocal, float maximumDistance, float minimumDistance, IRigidBody rigidBodyA = null, IRigidBody rigidBodyB = null, object userData = null) : this()
        {
            AnchorPoseALocal = anchorPoseALocal;
            AnchorPoseBLocal = anchorPoseBLocal;
            MaximumDistance = maximumDistance;
            MinimumDistance = minimumDistance;
            RigidBodyA = rigidBodyA;
            RigidBodyB = rigidBodyB;
            UserData = userData;
        }

        public Matrix4x4 AnchorPoseALocal { get; set; }
        public Matrix4x4 AnchorPoseBLocal { get; set; }
        public float MaximumDistance { get; set; }
        public float MinimumDistance { get; set; }

        public void ToDefault()
        {
            throw new NotImplementedException();
        }

        public IRigidBody RigidBodyA { get; set; }
        public IRigidBody RigidBodyB { get; set; }
        public object UserData { get; set; }
    }
}