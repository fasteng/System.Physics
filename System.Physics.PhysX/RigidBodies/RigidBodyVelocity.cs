using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.PhysX;

namespace System.Physics.PhysX.RigidBodies
{
    public partial class RigidBody
    {
        private class RigidBodyVelocity : IVelocity
        {
            private readonly RigidBody _rigidBody;

            public RigidBodyVelocity(RigidBody rigidBody)
            {
                _rigidBody = rigidBody;
            }

            private Vector3 ToCorrectSpace(CoordinateSpace velocitySpace, Vector3 result)
            {
                return velocitySpace == CoordinateSpace.Global
                           ? result
                           : _rigidBody.Pose.ToLocalPosition(result);
            }

            public Vector3 GetVelocity(Vector3 position, CoordinateSpace positionSpace = CoordinateSpace.Global, CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                Vector3 result = positionSpace == CoordinateSpace.Global
                                      ? _rigidBody.WrappedActor.GetPointVelocity(position.ToPhysX()).ToStandard()
                                      : _rigidBody.WrappedActor.GetLocalPointVelocity(position.ToPhysX()).ToStandard();
                return ToCorrectSpace(velocitySpace, result);
            }

            public Vector3 GetLinearVelocity(CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                Vector3 result = _rigidBody.WrappedActor.LinearVelocity.ToStandard();
                return ToCorrectSpace(velocitySpace, result);
            }

            public Vector3 GetAngularVelocity(CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                Vector3 result = _rigidBody.WrappedActor.AngularVelocity.ToStandard();
                return ToCorrectSpace(velocitySpace, result);
            }

            public void SetAngularVelocity(Vector3 velocity, CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                if (velocitySpace == CoordinateSpace.Local) velocity = _rigidBody.Pose.ToGlobalDirection(velocity);
                _rigidBody.WrappedActor.AngularVelocity = velocity.ToPhysX();
            }


            public void SetLinearVelocity(Vector3 velocity, CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                if (velocitySpace == CoordinateSpace.Local) velocity = _rigidBody.Pose.ToGlobalDirection(velocity);
                _rigidBody.WrappedActor.LinearVelocity = velocity.ToPhysX();
            }
        }
    }
}
