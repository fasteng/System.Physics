using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.DigitalRune;
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

            private Vector3 FromGlobalToCorrectSpace(CoordinateSpace velocitySpace, Vector3 globalResult)
            {
                return velocitySpace == CoordinateSpace.Global
                           ? globalResult
                           : _rigidBody.Pose.ToLocalPosition(globalResult);
            }

            public Vector3 GetVelocity(Vector3 position, CoordinateSpace positionSpace = CoordinateSpace.Global, CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                Vector3 globalResult = positionSpace == CoordinateSpace.Global
                                     ? _rigidBody.WrappedRigidBody.GetVelocityOfWorldPoint(position.ToDigitalRune()).ToStandard()
                                     : _rigidBody.WrappedRigidBody.GetVelocityOfLocalPoint(position.ToDigitalRune()).ToStandard();
                return FromGlobalToCorrectSpace(velocitySpace, globalResult);
            }

            public Vector3 GetAngularVelocity(CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                Vector3 globalResult = _rigidBody.WrappedRigidBody.AngularVelocity.ToStandard();
                return FromGlobalToCorrectSpace(velocitySpace, globalResult);
            }

            public Vector3 GetLinearVelocity
                (CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                Vector3 globalResult = _rigidBody.WrappedRigidBody.LinearVelocity.ToStandard();
                return FromGlobalToCorrectSpace(velocitySpace, globalResult);
            }

            public void SetAngularVelocity(Vector3 velocity, CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                if (velocitySpace == CoordinateSpace.Local) velocity = _rigidBody.Pose.ToGlobalDirection(velocity);
                _rigidBody.WrappedRigidBody.AngularVelocity = velocity.ToDigitalRune();
            }

            public void SetLinearVelocity(Vector3 velocity, CoordinateSpace velocitySpace = CoordinateSpace.Global)
            {
                if (velocitySpace == CoordinateSpace.Local) velocity = _rigidBody.Pose.ToGlobalDirection(velocity);
                _rigidBody.WrappedRigidBody.LinearVelocity = velocity.ToDigitalRune();
            }
        }
    }
}
