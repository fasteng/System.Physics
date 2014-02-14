using System.Maths;
using System.Physics.Factories;
using System.Physics.Visitor;

namespace System.Physics.Fixtures
{
    public interface IFixture : IDescriptible<FixtureDescriptor>, IUserDataStorer, IVisitableTree
    {
        Matrix4x4 Pose { get; set; }
    }
}
