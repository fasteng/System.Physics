using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseCircleShape : BaseUserDataStorer, ICircleShape
    {
        public CircleShapeDescriptor Descriptor
        {
            get
            {
                return new CircleShapeDescriptor(Radius, UserData);
            }
            set
            {
                Radius = value.Radius;
                UserData = value.UserData;
            }
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<ICircleShape>(this);
        }
        public void CopyStateTo(ICircleShape element)
        {
            element.Descriptor = Descriptor;
        }

        public abstract float Radius { get; set; }
    }
}