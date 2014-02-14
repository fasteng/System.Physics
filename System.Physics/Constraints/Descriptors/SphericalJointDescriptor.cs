using System.Maths;
using System.Physics.RigidBodies;

namespace System.Physics.Constraints.Descriptors
{
    public struct SphericalJointDescriptor : IDescriptor
    {
        public SphericalJointDescriptor(Vector3 anchorPositionALocal, Vector3 anchorPositionBLocal, IRigidBody rigidBodyA = null, IRigidBody rigidBodyB = null, object userData = null) : this()
        {
            AnchorPositionALocal = anchorPositionALocal;
            AnchorPositionBLocal = anchorPositionBLocal;
            RigidBodyA = rigidBodyA;
            RigidBodyB = rigidBodyB;
            UserData = userData;
        }

        public Vector3 AnchorPositionALocal { get; set; }
        public Vector3 AnchorPositionBLocal { get; set; }

        public void ToDefault()
        {
            throw new NotImplementedException();
        }

        public IRigidBody RigidBodyA { get; set; }
        public IRigidBody RigidBodyB { get; set; }
        public object UserData { get; set; }
    }
}