using System.Physics.Factories;
using System.Physics.Visitor;

namespace System.Physics.Fixtures
{
    public abstract class BaseCompositeFixture : BaseFixture, ICompositeFixture
    {
        public override void AcceptVisit(IVisitor visitor)
        {
            visitor.StartVisit<ICompositeFixture>(this);
            FixtureFactory.AcceptVisit(visitor);
            visitor.EndVisit<ICompositeFixture>(this);
        }

        public abstract IMultipleFactory<IFixture> FixtureFactory { get; protected set; }
    }
}