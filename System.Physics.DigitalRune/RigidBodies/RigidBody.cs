using System.Collections.Generic;
using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.Configurations;
using System.Physics.DigitalRune;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Physics.RigidBodies;
using System.Physics.Shapes;
using DigitalRune.Geometry;
using DigitalRune.Geometry.Shapes;
using DigitalRune.Physics;
using DigitalRune.Physics.Materials;
using MotionType = System.Physics.RigidBodies.MotionType;
using DigitalRuneMotionType = DigitalRune.Physics.MotionType;
using DR = DigitalRune.Physics;

namespace System.Physics.DigitalRune.RigidBodies
{
    public partial class RigidBody : BaseRigidBody
    {
        internal readonly DR.RigidBody WrappedRigidBody;

        internal RigidBody(RigidBodyDescriptor descriptor)
        {
            WrappedRigidBody = new DR.RigidBody {AutoUpdateMass = true, MotionType = descriptor.MotionType.ToDigitalRune()};

            Configurator = new RigidBodyConfigurator(this);
            FixtureFactory = new RigidBodyFixtureFactory(this);
            Forces = new RigidBodyForces(this);
            Velocity = new RigidBodyVelocity(this);
            MassFrame = new RigidBodyMassFrame(this);
            Descriptor = descriptor;
        }

        public override float KineticEnergy { get { return WrappedRigidBody.KineticEnergy; } }

        public override MotionType MotionType
        {
            get { return WrappedRigidBody.MotionType.ToStandard(); }
        }

        public override Matrix4x4 Pose
        {
            get { return WrappedRigidBody.Pose.ToStandard(); }
            set { WrappedRigidBody.Pose = value.ToDigitalRune(); }
        }
    }
}
