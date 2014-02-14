using System.Maths;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseTransformedShape : BaseUserDataStorer, ITransformedShape
    {
        public TransformedShapeDescriptor Descriptor { get; set; }
        public void CopyStateTo(ITransformedShape element)
        {
            element.Descriptor = Descriptor;
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<ITransformedShape>(this);
        }
        public abstract IShape Shape { get; set; }
        public abstract Matrix4x4 Pose { get; set; }
    }
}