using System.Maths;

namespace System.Physics.RigidBodies
{
    public interface IMassFrame : IDescriptible<MassFrameDescriptor>
    {
        float Mass { get; set; }
        Vector3 Inertia { get; set; }
        void SetPose(Matrix4x4 pose, CoordinateSpace space = CoordinateSpace.Local);
        Matrix4x4 GetPose(CoordinateSpace space = CoordinateSpace.Local);
        void UpdateFromShape();
    }
}