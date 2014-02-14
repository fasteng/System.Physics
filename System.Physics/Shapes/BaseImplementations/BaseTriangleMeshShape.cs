using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseTriangleMeshShape : BaseUserDataStorer, ITriangleMeshShape
    {
        public TriangleMeshShapeDescriptor Descriptor { get; set; }
        public void CopyStateTo(ITriangleMeshShape element)
        {
            element.Descriptor = Descriptor;
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<ITriangleMeshShape>(this);
        }
    }
}