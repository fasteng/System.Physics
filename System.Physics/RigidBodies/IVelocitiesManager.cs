using System.Maths;

namespace System.Physics.RigidBodies
{
    public interface IVelocity
    {
        Vector3 GetVelocity(Vector3 position, CoordinateSpace positionSpace = CoordinateSpace.Global, CoordinateSpace velocitySpace = CoordinateSpace.Global);
        Vector3 GetAngularVelocity(CoordinateSpace velocitySpace = CoordinateSpace.Global);
        void SetAngularVelocity(Vector3 velocity, CoordinateSpace velocitySpace = CoordinateSpace.Global);
        Vector3 GetLinearVelocity(CoordinateSpace velocitySpace = CoordinateSpace.Global);
        void SetLinearVelocity(Vector3 velocity, CoordinateSpace velocitySpace = CoordinateSpace.Global);
    }
}