using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseHeightFieldShape : BaseUserDataStorer, IHeightFieldShape
    {
        public HeightFieldShapeDescriptor Descriptor { get; set; }
        public void CopyStateTo(IHeightFieldShape element)
        {
            element.Descriptor = Descriptor;
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<IHeightFieldShape>(this);
        }
    }
}