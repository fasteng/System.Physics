using System.Physics.Factories;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseCompositeShape : BaseUserDataStorer, ICompositeShape
    {
        public CompositeShapeDescriptor Descriptor
        {
            get { return new CompositeShapeDescriptor(UserData); }
            set { UserData = value.UserData; }
        }
        public void CopyStateTo(ICompositeShape element)
        {
            element.Descriptor = Descriptor;
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.StartVisit<ICompositeShape>(this);
            ShapePositionerFactory.AcceptVisit(visitor);
            visitor.EndVisit<ICompositeShape>(this);
        }
        public abstract IMultipleFactory<IShapePositioner> ShapePositionerFactory { get; protected set; }
    }
}