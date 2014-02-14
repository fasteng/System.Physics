using System.Maths;
using System.Physics.RigidBodies;

namespace System.Physics.Constraints.Descriptors
{
    public struct PointOnPlaneJointDescriptor : IDescriptor
    {
        public PointOnPlaneJointDescriptor(Vector3 anchorPositionALocal, Vector3 xAxisALocal, Vector3 yAxisALocal, Vector3 anchorPositionBLocal, float maximumDistanceX, float minimumDistanceX, float maximumDistanceY, float minimumDistanceY, IRigidBody rigidBodyA = null, IRigidBody rigidBodyB = null, object userData = null)
            : this()
        {
            AnchorPositionALocal = anchorPositionALocal;
            YAxisALocal = yAxisALocal;
            AnchorPositionBLocal = anchorPositionBLocal;
            MaximumDistanceX = maximumDistanceX;
            MinimumDistanceX = minimumDistanceX;
            MaximumDistanceY = maximumDistanceY;
            MinimumDistanceY = minimumDistanceY;
            RigidBodyA = rigidBodyA;
            RigidBodyB = rigidBodyB;
            UserData = userData;
            XAxisALocal = xAxisALocal;
        }

        public Vector3 AnchorPositionALocal { get; set; }
        public Vector3 XAxisALocal { get; set; }
        public Vector3 YAxisALocal { get; set; }
        public Vector3 AnchorPositionBLocal { get; set; }
        public float MaximumDistanceX { get; set; }
        public float MinimumDistanceX { get; set; }
        public float MaximumDistanceY { get; set; }
        public float MinimumDistanceY { get; set; }

        public void ToDefault()
        {
            throw new NotImplementedException();
        }

        public IRigidBody RigidBodyA { get; set; }
        public IRigidBody RigidBodyB { get; set; }
        public object UserData { get; set; }
    }
}