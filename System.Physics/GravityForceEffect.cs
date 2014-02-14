using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Physics.ForceEffects;
using System.Physics.RigidBodies;
using System.Text;

namespace System.Physics
{
    public class GravityForceEffect :BaseForceEffect, IGlobalForceField
    {
        public GravityForceEffect(Vector3 acceleration)
        {
            Accelaration = acceleration;
        }

        public GravityForceEffect()
        {
            Accelaration = new Vector3(0,-9.8f,0);
        }
        public Vector3 Accelaration { get; set; }

        public override void ApplyEffect()
        {
            if(Simulator != null)
                foreach (IRigidBody rigidBody in Simulator.ActorsFactory.GetElements<IRigidBody>())
                    rigidBody.Forces.AddForce(Accelaration * rigidBody.MassFrame.Mass);
            else
            {
                throw new InvalidOperationException("A 'ForcEffect' object must be added to some 'ISimulator' object when 'ApplyEffect' method is called.");
            }
        }
    }

    public class AttractionForceEffect : BaseForceEffect, IGlobalForceField
    {
        public AttractionForceEffect(IRigidBody attractor, float acceleration = 10)
        {
            Attractor = attractor;
            Acceleration = acceleration;
        }

        public IRigidBody Attractor { get; set; }
        public float Acceleration { get; set; }

        public override void ApplyEffect()
        {
            if (Simulator != null)
            {
                var position1 = Attractor.MassFrame.GetPose(CoordinateSpace.Global).ExtractPosition();
                foreach (IRigidBody rigidBody in Simulator.ActorsFactory.GetElements<IRigidBody>())
                {
                    if (rigidBody != Attractor)
                    {
                        var position2 = rigidBody.MassFrame.GetPose(CoordinateSpace.Global).ExtractPosition();
                        var direction = GMath.normalize(position1 - position2);
                        rigidBody.Forces.AddForce(Acceleration * direction * rigidBody.MassFrame.Mass);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("A 'ForcEffect' object must be added to some 'ISimulator' object when 'ApplyEffect' method is called.");
            }
        }
    }

}
