using System.Maths;
using System.Physics.RigidBodies;

namespace System.Physics.RigidBodies
{
    public struct RigidBodyDescriptor : IDescriptor
    {
        public RigidBodyDescriptor(MotionType motionType, Matrix4x4 pose, object userData = null) : this()
        {
            MotionType = motionType;
            Pose = pose;
            UserData = userData;
        }

        public MotionType MotionType
        {
            get;
            set;
        }

        public Matrix4x4 Pose
        {
            get;
            set;
        }

        public object UserData
        {
            get;
            set;
        }

        public void ToDefault()
        {
            MotionType = MotionType.Dynamic;
            Pose = Matrices.I;
            UserData = null;

        }
    }
}