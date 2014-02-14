using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.DigitalRune.Conversions;
using System.Text;
using System.Threading.Tasks;
using DigitalRune.Mathematics.Algebra;

namespace System.Physics.DigitalRune.RigidBodies
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

            public Vector3 GetVelocity(Vector3 position, CoordinateSpace positionSpace = CoordinateSpace.Global, CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                Vector3 result = positionSpace == CoordinateSpace.Global
                                     ? _rigidBody.WrappedRigidBody.GetVelocityOfWorldPoint(position.ToDigitalRune()).ToStandard()
                                     : _rigidBody.WrappedRigidBody.GetVelocityOfLocalPoint(position.ToDigitalRune()).ToStandard();
                return velocitySpace == CoordinateSpace.Global
                           ?  result
                           : _rigidBody.Pose.ToLocalPosition(result);
            }

            public Vector3 GetAngularVelocity(CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                Vector3 result = _rigidBody.WrappedRigidBody.AngularVelocity.ToStandard();
                return velocitySpace == CoordinateSpace.Global
                           ? result
                           : _rigidBody.Pose.ToLocalPosition(result);
            }

            public void SetAngularVelocity(Vector3 velocity, CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                if (velocitySpace == CoordinateSpace.Local) velocity = _rigidBody.Pose.ToGlobalDirection(velocity);
                _rigidBody.WrappedRigidBody.AngularVelocity = velocity.ToDigitalRune();
            }

            public Vector3 GetLinearVelocity(CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                Vector3 result = _rigidBody.WrappedRigidBody.LinearVelocity.ToStandard();
                return velocitySpace == CoordinateSpace.Global
                           ? result
                           : _rigidBody.Pose.ToLocalPosition(result);
            }

            public void SetLinearVelocity(Vector3 velocity, CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                if (velocitySpace == CoordinateSpace.Local) velocity = _rigidBody.Pose.ToGlobalDirection(velocity);
                _rigidBody.WrappedRigidBody.LinearVelocity = velocity.ToDigitalRune();
            }
        }
    }
}
