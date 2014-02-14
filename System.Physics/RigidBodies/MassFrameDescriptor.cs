using System.Maths;

namespace System.Physics.RigidBodies
{
    public struct MassFrameDescriptor : IDescriptor
    {
        public MassFrameDescriptor(float mass, Vector3 inertia, Matrix4x4 pose): this()
        {
            Mass = mass;
            Inertia = inertia;
            LocalPose = pose;
        }

        public float Mass { get; set; }
        public Vector3 Inertia { get; set; }
        public Matrix4x4 LocalPose { get; set; }

        public void ToDefault() 
        {
            Mass = 1000;
            LocalPose = Matrices.I;
            Inertia = new Vector3(166.6667f);
        }
    }
}