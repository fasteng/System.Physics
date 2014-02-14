using System.Collections.Generic;
using System.Maths;
using System.Physics.Configurations;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Physics.RigidBodies;
using System.Physics.Visitor;

namespace System.Physics.RigidBodies
{
    public interface IRigidBody : IDescriptible<RigidBodyDescriptor>, IUserDataStorer, System.Physics.IActor, IVisitableTree
    {
        float KineticEnergy { get; }

        IConfigurator<IRigidBody> Configurator
        {
            get;
        }

        IForces Forces
        {
            get;
        }

        IVelocity Velocity
        {
            get;
        }

        IMassFrame MassFrame
        {
            get;
        }

        IEnergy Energy
        {
            get;
        }

        ISingleFactory<IFixture> FixtureFactory
        {
            get;
        }

        MotionType MotionType { get; }

        Matrix4x4 Pose { get; set; }
    }
}