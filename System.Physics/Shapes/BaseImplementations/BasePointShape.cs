using System.Maths;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BasePointShape : BaseUserDataStorer, IPointShape
    {
        public PointShapeDescriptor Descriptor
        {
            get
            {
                return new PointShapeDescriptor(Position, UserData);
            }
            set
            {
                Position = value.Position;
                UserData = value.UserData;
            }
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IPointShape>(this);
        }

        public void CopyStateTo(IPointShape element)
        {
            element.Descriptor = Descriptor;
        }

        public abstract Vector3 Position { get; set; }
    }
}