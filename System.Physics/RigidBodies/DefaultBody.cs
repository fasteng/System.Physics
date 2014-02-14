using System.Maths;
using System.Physics.RigidBodies;

namespace System.Physics.RigidBodies
{
    public class DefaultRigidBody: BaseRigidBody
    {
        private MotionType _motionType;

        public DefaultRigidBody(RigidBodyDescriptor descriptor)
        {
            _motionType = descriptor.MotionType;
        }


        public override float KineticEnergy { get { return 0; }}

        public override MotionType MotionType { get { return _motionType; } }
        public override Matrix4x4 Pose { get; set; }
    }
}