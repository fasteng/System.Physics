using System.Maths;
using System.Physics.RigidBodies;

namespace System.Physics.Constraints.Descriptors
{
    public struct FixedJointDescriptor : IDescriptor
    {
        public FixedJointDescriptor(Matrix4x4 anchorPoseALocal, Matrix4x4 anchorPoseBLocal, IRigidBody rigidBodyA = null, IRigidBody rigidBodyB = null,  object userData = null)
            : this()
        {
            AnchorPoseALocal = anchorPoseALocal;
            AnchorPoseBLocal = anchorPoseBLocal;
            RigidBodyA = rigidBodyA;
            RigidBodyB = rigidBodyB;
            UserData = userData;
        }

        public Matrix4x4 AnchorPoseALocal { get; set; }
        public Matrix4x4 AnchorPoseBLocal { get; set; }
        public IRigidBody RigidBodyA { get; set; }
        public IRigidBody RigidBodyB { get; set; }
        public object UserData { get; set; }

        public void ToDefault()
        {
            throw new NotImplementedException();
        }
    }
}