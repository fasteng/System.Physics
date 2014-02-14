using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Physics.RigidBodies;
using System.Text;
using System.Threading.Tasks;

namespace System.Physics.DigitalRune.RigidBodies
{
    public partial class RigidBody
    {
        private class RigidBodyForces : IForces
        {
            private readonly RigidBody _rigidBody;

            public RigidBodyForces(RigidBody rigidBody)
            {
                _rigidBody = rigidBody;
            }

            public void AddForce(Vector3 force, CoordinateSpace forceSpace = CoordinateSpace.Global)
            {
                if (forceSpace == CoordinateSpace.Local) force = _rigidBody.Pose.ToGlobalDirection(force);
                _rigidBody.WrappedRigidBody.AddForce(force.ToDigitalRune());
            }

            public void AddForce(Vector3 force, Vector3 position, CoordinateSpace forceSpace = CoordinateSpace.Global, CoordinateSpace positionSpace = CoordinateSpace.Global)
            {
                if (forceSpace == CoordinateSpace.Local) force = _rigidBody.Pose.ToGlobalDirection(force);
                if (positionSpace == CoordinateSpace.Local) position = _rigidBody.Pose.ToGlobalPosition(position);
                _rigidBody.WrappedRigidBody.AddForce(force.ToDigitalRune(),position.ToDigitalRune());
            }

            public void AddTorque(Vector3 torque, CoordinateSpace torqueSpace = CoordinateSpace.Global)
            {
                if (torqueSpace == CoordinateSpace.Local) torque = _rigidBody.Pose.ToGlobalDirection(torque);
                _rigidBody.WrappedRigidBody.AddTorque(torque.ToDigitalRune());
            }

            public void ApplyAngularImpulse(Vector3 impulse, CoordinateSpace impulseSpace = CoordinateSpace.Global)
            {
                if (impulseSpace == CoordinateSpace.Local) impulse = _rigidBody.Pose.ToGlobalDirection(impulse);
                _rigidBody.WrappedRigidBody.ApplyAngularImpulse(impulse.ToDigitalRune());
            }

            public void ApplyLinearImpulse(Vector3 impulse, CoordinateSpace impulseSpace = CoordinateSpace.Global)
            {
                if (impulseSpace == CoordinateSpace.Local) impulse = _rigidBody.Pose.ToGlobalDirection(impulse);
                _rigidBody.WrappedRigidBody.ApplyLinearImpulse(impulse.ToDigitalRune());
            }

            public void ApplyImpulse(Vector3 impulse, Vector3 position, CoordinateSpace impulseSpace = CoordinateSpace.Global, CoordinateSpace positionSpace = CoordinateSpace.Global)
            {
                if (impulseSpace == CoordinateSpace.Local) impulse = _rigidBody.Pose.ToGlobalDirection(impulse);
                if (positionSpace == CoordinateSpace.Local) position = _rigidBody.Pose.ToGlobalPosition(position);
                _rigidBody.WrappedRigidBody.ApplyImpulse(impulse.ToDigitalRune(), position.ToDigitalRune());
            }
        }
    }
}
