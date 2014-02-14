using System.Maths;
using System.Physics.RigidBodies;

namespace System.Physics.Constraints.Descriptors
{
    public struct NoRotationJointDescriptor : IDescriptor
    {
        public NoRotationJointDescriptor(Matrix3x3 anchorOrientationALocal, Matrix3x3 anchorOrientationBLocal, IRigidBody rigidBodyA = null, IRigidBody rigidBodyB = null, object userData = null) : this()
        {
            AnchorOrientationALocal = anchorOrientationALocal;
            AnchorOrientationBLocal = anchorOrientationBLocal;
            RigidBodyA = rigidBodyA;
            RigidBodyB = rigidBodyB;
            UserData = userData;
        }

        public Matrix3x3 AnchorOrientationALocal { get; set; }
        public Matrix3x3 AnchorOrientationBLocal { get; set; }

        public void ToDefault()
        {
            throw new NotImplementedException();
        }

        public IRigidBody RigidBodyA { get; set; }
        public IRigidBody RigidBodyB { get; set; }
        public object UserData { get; set; }
    }
}