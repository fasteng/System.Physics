using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseConvexPolyhedronShape : BaseUserDataStorer, IConvexPolyhedronShape
    {
        public ConvexPolyhedronShapeDescriptor Descriptor { get; set; }
        public void CopyStateTo(IConvexPolyhedronShape element)
        {
            element.Descriptor = Descriptor;
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IConvexPolyhedronShape>(this);
        }
    }
}