using System.Maths;

namespace System.Physics.RigidBodies 
{
    public interface IForces
    {
        //todo si es conveniente añadir el bool autoWake (esto implicaria que el simulador tiene ISleepingSupport)
        void AddForce(Vector3 force, CoordinateSpace forceSpace = CoordinateSpace.Global);
        void AddForce(Vector3 force, Vector3 position, CoordinateSpace forceSpace = CoordinateSpace.Global, CoordinateSpace positionSpace = CoordinateSpace.Global);
        void AddTorque(Vector3 torque, CoordinateSpace torqueSpace = CoordinateSpace.Global);
        void ApplyAngularImpulse(Vector3 impulse, CoordinateSpace impulseSpace = CoordinateSpace.Global);
        void ApplyLinearImpulse(Vector3 impulse, CoordinateSpace impulseSpace = CoordinateSpace.Global);
        void ApplyImpulse(Vector3 impulse, Vector3 position, CoordinateSpace impulseSpace = CoordinateSpace.Global, CoordinateSpace positionSpace = CoordinateSpace.Global);
    }
}