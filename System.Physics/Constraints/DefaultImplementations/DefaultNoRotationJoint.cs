
using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.Constraints.BaseImplementations;
using System.Physics.Constraints.Descriptors;

namespace System.Physics.Constraints.DefaultImplementations
{
    public class DefaultNoRotationJoint : BaseNoRotationJoint
    {
        private IRigidBody _rigidBodyA;
        private IRigidBody _rigidBodyB;
        private Matrix3x3 _anchorOrientationALocal;
        private Matrix3x3 _anchorOrientationBLocal;

        public DefaultNoRotationJoint(NoRotationJointDescriptor descriptor)
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

        public override Matrix3x3 AnchorOrientationALocal
        {
            get { return _anchorOrientationALocal; }
        }

        public override Matrix3x3 AnchorOrientationBLocal
        {
            get { return _anchorOrientationBLocal; }
        }
    }
}