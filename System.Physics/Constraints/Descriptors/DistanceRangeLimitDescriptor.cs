using System.Maths;
using System.Physics.RigidBodies;

namespace System.Physics.Constraints.Descriptors
{
    public struct DistanceRangeJointDescriptor : IDescriptor
    {
        public DistanceRangeJointDescriptor(Vector3 anchorPositionALocal, Vector3 anchorPositionBLocal, float minDistance, float maxDistance, IRigidBody rigidBodyA = null, IRigidBody rigidBodyB = null, object userData = null) : this()
        {
            RigidBodyA = rigidBodyA;
            RigidBodyB = rigidBodyB;
            UserData = userData;
            AnchorPositionALocal = anchorPositionALocal;
            AnchorPositionBLocal = anchorPositionBLocal;
            MinimumDistance = minDistance;
            MaximumDistance = maxDistance;
        }

        public void ToDefault()
        {
            throw new NotImplementedException();
        }
        public Vector3 AnchorPositionALocal { get; set; }
        public Vector3 AnchorPositionBLocal { get; set; }
        public float MinimumDistance { get; set; }
        public float MaximumDistance { get; set; }
        public IRigidBody RigidBodyA { get; set; }
        public IRigidBody RigidBodyB { get; set; }
        public object UserData { get; set; }
    }
}