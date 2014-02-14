using System.Maths;
using System.Physics.Factories;
using System.Physics.Materials;
using System.Physics.Shapes;
using System.Physics.Visitor;

namespace System.Physics.Fixtures
{
    public interface ISimpleFixture : IFixture
    {
        ISingleFactory<IMaterial> MaterialFactory
        {
            get;
        }

        ISingleFactory<IShape> ShapeFactory
        {
            get;
        }
    }

    public abstract class BaseSimpleFixture:BaseFixture,ISimpleFixture
    {
        public override void AcceptVisit(IVisitor visitor)
        {
            visitor.StartVisit<ISimpleFixture>(this);
            MaterialFactory.AcceptVisit(visitor);
            ShapeFactory.AcceptVisit(visitor);
            visitor.EndVisit<ISimpleFixture>(this);
        }

        public abstract ISingleFactory<IMaterial> MaterialFactory { get; protected set; }
        public abstract ISingleFactory<IShape> ShapeFactory { get; protected set; }
    }
}