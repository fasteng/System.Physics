using System.Maths;
using System.Physics.RigidBodies;
using System.Physics.Configurations;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Physics.Visitor;

namespace System.Physics.RigidBodies
{
    public abstract class BaseRigidBody : IRigidBody
    {
        public abstract float KineticEnergy { get;}

        public IConfigurator<IRigidBody> Configurator { get; protected set; }

        public ISingleFactory<IFixture> FixtureFactory { get; protected set; }

        public abstract MotionType MotionType { get; }

        public abstract Matrix4x4 Pose { get; set; }

        public IForces Forces { get; protected set; }

        public IVelocity Velocity { get; protected set; }

        public IMassFrame MassFrame { get; protected set; }

        public IEnergy Energy { get; protected set; }

        public RigidBodyDescriptor Descriptor
        {
            get { return new RigidBodyDescriptor(MotionType, Pose, UserData); }
            set
            {
                Pose = value.Pose;
                UserData = value.UserData;
            }
        }

        public object UserData { get; set; }

        public void AcceptVisit(IVisitor visitor)
        {
            visitor.StartVisit<IRigidBody>(this);
            FixtureFactory.AcceptVisit(visitor);
            visitor.EndVisit<IRigidBody>(this);
        }
    }
}
