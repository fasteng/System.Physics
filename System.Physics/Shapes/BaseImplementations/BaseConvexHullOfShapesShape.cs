using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseConvexHullOfShapesShape : BaseUserDataStorer, IConvexHullOfShapesShape
    {
        public ConvexHullOfShapesShapeDescriptor Descriptor { get; set; }
        public void CopyStateTo(IConvexHullOfShapesShape element)
        {
            element.Descriptor = Descriptor;
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IConvexHullOfShapesShape>(this);
        }
    }
}