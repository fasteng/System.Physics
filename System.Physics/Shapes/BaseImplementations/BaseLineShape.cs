using System.Maths;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseLineShape : BaseUserDataStorer, ILineShape
    {
        public LineShapeDescriptor Descriptor
        {
            get
            {
                return new LineShapeDescriptor(PointOnLine, Direction, UserData);
            }
            set
            {
                PointOnLine = value.PointOnLine;
                Direction = value.Direction;
                UserData = value.UserData;
            }
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<ILineShape>(this);
        }
        public void CopyStateTo(ILineShape element)
        {
            element.Descriptor = Descriptor;
        }

        public abstract Vector3 Direction { get; set; }
        public abstract Vector3 PointOnLine { get; set; }
    }
}