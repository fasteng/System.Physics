using System.Maths;
using System.Physics.RigidBodies;

namespace System.Physics.Constraints.Descriptors
{
    public struct PointOnLineJointDescriptor : IDescriptor
    {
        public PointOnLineJointDescriptor(Vector3 anchorPositionALocal, Vector3 axisALocal, Vector3 anchorPositionBLocal, float maximumDistance, float minimumDistance, IRigidBody rigidBodyA = null, IRigidBody rigidBodyB = null, object userData = null) : this()
        {
            AnchorPositionALocal = anchorPositionALocal;
            AxisALocal = axisALocal;
            AnchorPositionBLocal = anchorPositionBLocal;
            MaximumDistance = maximumDistance;
            MinimumDistance = minimumDistance;
            RigidBodyA = rigidBodyA;
            RigidBodyB = rigidBodyB;
            UserData = userData;
        }

        public Vector3 AnchorPositionALocal { get; set; }
        public Vector3 AxisALocal { get; set; }
        public Vector3 AnchorPositionBLocal { get; set; }
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