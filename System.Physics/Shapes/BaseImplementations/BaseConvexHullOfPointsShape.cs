using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseConvexHullOfPointsShape : BaseUserDataStorer, IConvexHullOfPointsShape
    {
        public ConvexHullOfPointsShapeDescriptor Descriptor { get; set; }
        public void CopyStateTo(IConvexHullOfPointsShape element)
        {
            element.Descriptor = Descriptor;
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IConvexHullOfPointsShape>(this);
        }
    }
}