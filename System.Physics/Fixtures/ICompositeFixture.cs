using System.Collections.Generic;
using System.Maths;
using System.Physics.Factories;
using System.Physics.Materials;

namespace System.Physics.Fixtures
{
    public interface ICompositeFixture : IFixture
    {
        IMultipleFactory<IFixture> FixtureFactory
        {
            get;
        }
    }
}
