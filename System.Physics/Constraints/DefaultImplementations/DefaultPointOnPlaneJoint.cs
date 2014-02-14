
using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.Constraints.BaseImplementations;
using System.Physics.Constraints.Descriptors;

namespace System.Physics.Constraints.DefaultImplementations
{
    public class DefaultPointOnPlaneJoint : BasePointOnPlaneJoint
    {
        private IRigidBody _rigidBodyA;
        private IRigidBody _rigidBodyB;
        private Vector3 _anchorPositionALocal;
        private Vector3 _xAxisALocal;
        private Vector3 _yAxisALocal;
        private Vector3 _anchorPositionBLocal;
        private float _maximumDistanceX;
        private float _minimumDistanceX;
        private float _maximumDistanceY;
        private float _minimumDistanceY;

        public DefaultPointOnPlaneJoint(PointOnPlaneJointDescriptor descriptor)
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

        public override Vector3 AnchorPositionALocal
        {
            get { return _anchorPositionALocal; }
        }

        public override Vector3 XAxisALocal
        {
            get { return _xAxisALocal; }
        }

        public override Vector3 YAxisALocal
        {
            get { return _yAxisALocal; }
        }

        public override Vector3 AnchorPositionBLocal
        {
            get { return _anchorPositionBLocal; }
        }

        public override float MaximumDistanceX
        {
            get { return _maximumDistanceX; }
        }

        public override float MinimumDistanceX
        {
            get { return _minimumDistanceX; }
        }

        public override float MaximumDistanceY
        {
            get { return _maximumDistanceY; }
        }

        public override float MinimumDistanceY
        {
            get { return _minimumDistanceY; }
        }

        public override Vector2 RelativePosition
        {
            get { throw new NotImplementedException(); }
        }
    }
}