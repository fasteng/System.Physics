using System;
using System.Collections.Generic;
using System.Linq;
using System.Physics.DigitalRune.Fixtures;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Text;
using System.Threading.Tasks;
using DigitalRune.Geometry;
using DigitalRune.Geometry.Shapes;
using DigitalRune.Physics.Materials;

namespace System.Physics.DigitalRune.RigidBodies
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
                return new SimpleFixture(_rigidBody.WrappedRigidBody, descriptor);
            }

            ICompositeFixture IFactoryOf<ICompositeFixture, FixtureDescriptor>.Create(FixtureDescriptor descriptor)
            {
                return new CompositeFixture(_rigidBody.WrappedRigidBody, descriptor);
            }
        }
    }
}
