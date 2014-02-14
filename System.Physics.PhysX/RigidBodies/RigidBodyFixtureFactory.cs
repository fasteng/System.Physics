using System.Maths;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Physics.PhysX.Fixtures;
using System.Physics.Shapes.DefaultImplementations;
using StillDesign.PhysX.MathPrimitives;
using Maths = System.Maths;
using System.Physics.PhysX.Shapes;

namespace System.Physics.PhysX.RigidBodies
{
    public partial class RigidBody
    {
        private class RigidBodyFixtureFactory :
            BaseSingleFactory<IFixture>,
            IFactoryOf<ISimpleFixture, FixtureDescriptor>,
            IFactoryOf<ICompositeFixture, FixtureDescriptor>
        {
            private RigidBody _rigidBody;

            public RigidBodyFixtureFactory(RigidBody rigidBody)
            {
                _rigidBody = rigidBody;
            }

            ISimpleFixture IFactoryOf<ISimpleFixture, FixtureDescriptor>.Create(FixtureDescriptor descriptor)
            {
                return new SimpleFixture(_rigidBody, descriptor, Matrices.I);
            }

            ICompositeFixture IFactoryOf<ICompositeFixture, FixtureDescriptor>.Create(FixtureDescriptor descriptor)
            {
                return new CompositeFixture(_rigidBody, descriptor, Matrices.I);
            }
        }
    }
}