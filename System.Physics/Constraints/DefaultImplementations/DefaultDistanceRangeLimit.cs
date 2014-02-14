using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.Constraints.BaseImplementations;
using System.Physics.Constraints.Descriptors;

namespace System.Physics.Constraints.DefaultImplementations
{
    public class DefaultDistanceRangeJoint : BaseDistanceRangeJoint
    {
        private IRigidBody _rigidBodyA;
        private IRigidBody _rigidBodyB;
        private Vector3 _anchorPositionALocal;
        private Vector3 _anchorPositionBLocal;
        private float _minimumDistance;
        private float _maximumDistance;

        public DefaultDistanceRangeJoint(DistanceRangeJointDescriptor descriptor)
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

        public override Vector3 AnchorPositionBLocal
        {
            get { return _anchorPositionBLocal; }
        }

        public override float MinimumDistance
        {
            get { return _minimumDistance; }
        }

        public override float MaximumDistance
        {
            get { return _maximumDistance; }
        }
    }
}