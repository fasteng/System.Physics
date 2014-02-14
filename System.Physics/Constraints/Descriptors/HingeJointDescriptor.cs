using System.Maths;
using System.Physics.RigidBodies;

namespace System.Physics.Constraints.Descriptors
{
    public struct HingeJointDescriptor : IDescriptor
    {
        public HingeJointDescriptor(Matrix4x4 anchorPoseALocal, Matrix4x4 anchorPoseBLocal, float maximumAngle, float minimumAngle, IRigidBody rigidBodyA = null, IRigidBody rigidBodyB = null, object userData = null) : this()
        {
            AnchorPoseALocal = anchorPoseALocal;
            AnchorPoseBLocal = anchorPoseBLocal;
            MaximumAngle = maximumAngle;
            MinimumAngle = minimumAngle;
            RigidBodyA = rigidBodyA;
            RigidBodyB = rigidBodyB;
            UserData = userData;
        }

        public Matrix4x4 AnchorPoseALocal { get; set; }
        public Matrix4x4 AnchorPoseBLocal { get; set; }
        public float MaximumAngle { get; set; }
        public float MinimumAngle { get; set; }

        public void ToDefault()
        {
            throw new NotImplementedException();
        }

        public IRigidBody RigidBodyA { get; set; }
        public IRigidBody RigidBodyB { get; set; }
        public object UserData { get; set; }
    }
}