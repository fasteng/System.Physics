using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseSphereShape : BaseUserDataStorer, ISphereShape
    {
        public SphereShapeDescriptor Descriptor
        {
            get
            {
                return new SphereShapeDescriptor(Radius,
                                                 UserData);
            }
            set
            {
                Radius = value.Radius;
                UserData = value.UserData;
            }
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<ISphereShape>(this);
        }
        public void CopyStateTo(ISphereShape element)
        {
            element.Descriptor = Descriptor;
        }

        public abstract float Radius { get; set; }
    }
}