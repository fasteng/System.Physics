using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.PhysX;
using System.Text;
using StillDesign.PhysX;

namespace System.Physics.PhysX.RigidBodies
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
                _rigidBody.WrappedActor.AddForce(force.ToPhysX(),ForceMode.Force);
            }

            public void AddForce(Vector3 force, Vector3 position, CoordinateSpace forceSpace = CoordinateSpace.Global, CoordinateSpace positionSpace = CoordinateSpace.Global)
            {
                if (forceSpace == CoordinateSpace.Local) force = _rigidBody.Pose.ToGlobalDirection(force);
                if (positionSpace == CoordinateSpace.Local) position = _rigidBody.Pose.ToGlobalPosition(position);
                _rigidBody.WrappedActor.AddForceAtPosition(force.ToPhysX(),position.ToPhysX(),ForceMode.Force);
            }

            public void AddTorque(Vector3 torque, CoordinateSpace torqueSpace = CoordinateSpace.Global)
            {
                if (torqueSpace == CoordinateSpace.Local) torque = _rigidBody.Pose.ToGlobalDirection(torque);
                _rigidBody.WrappedActor.AddTorque(torque.ToPhysX(),ForceMode.Force);
            }

            public void ApplyAngularImpulse(Vector3 impulse, CoordinateSpace impulseSpace = CoordinateSpace.Global)
            {
                if (impulseSpace == CoordinateSpace.Local) impulse = _rigidBody.Pose.ToGlobalDirection(impulse);
                _rigidBody.WrappedActor.AddTorque(impulse.ToPhysX(),ForceMode.Impulse);
            }

            public void ApplyLinearImpulse(Vector3 impulse, CoordinateSpace impulseSpace = CoordinateSpace.Global)
            {
                if (impulseSpace == CoordinateSpace.Local) impulse = _rigidBody.Pose.ToGlobalDirection(impulse);
                _rigidBody.WrappedActor.AddForce(impulse.ToPhysX(), ForceMode.Impulse);
            }

            public void ApplyImpulse(Vector3 impulse, Vector3 position, CoordinateSpace impulseSpace = CoordinateSpace.Global, CoordinateSpace positionSpace = CoordinateSpace.Global)
            {
                if (impulseSpace == CoordinateSpace.Local) impulse = _rigidBody.Pose.ToGlobalDirection(impulse);
                if (positionSpace == CoordinateSpace.Local) position = _rigidBody.Pose.ToGlobalPosition(position);
                _rigidBody.WrappedActor.AddForceAtPosition(impulse.ToPhysX(), position.ToPhysX(), ForceMode.Impulse);
            }
        }
    }
}
