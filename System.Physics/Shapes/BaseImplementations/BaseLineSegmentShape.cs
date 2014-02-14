using System.Maths;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseLineSegmentShape : BaseUserDataStorer, ILineSegmentShape
    {
        public LineSegmentShapeDescriptor Descriptor
        {
            get
            {
                return new LineSegmentShapeDescriptor(StartPoint,
                                                      EndPoint);
            }
            set
            {
                StartPoint = value.StartPoint;
                EndPoint = value.EndPoint;
            }
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<ILineSegmentShape>(this);
        }
        public void CopyStateTo(ILineSegmentShape element)
        {
            element.Descriptor = Descriptor;
        }

        public abstract Vector3 StartPoint { get; set; }
        public abstract Vector3 EndPoint { get; set; }
        public abstract float Length { get; }
        public abstract float LengthSquared { get; }
    }
}