using System.Maths;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes.BaseImplementations
{
    public abstract class BaseTriangleShape : BaseUserDataStorer, ITriangleShape
    {
        public TriangleShapeDescriptor Descriptor
        {
            get
            {
                return new TriangleShapeDescriptor(VertexA, VertexB, VertexC, UserData);
            }
            set
            {
                VertexA = value.VertexA;
                VertexB = value.VertexB;
                VertexC = value.VertexC;
                UserData = value.UserData;
            }
        }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.Visit<ITriangleShape>(this);
        }
        public void CopyStateTo(ITriangleShape element)
        {
            element.Descriptor = Descriptor;
        }

        public abstract Vector3 VertexA { get; set; }
        public abstract Vector3 VertexB { get; set; }
        public abstract Vector3 VertexC { get; set; }
        public abstract Vector3 Normal { get; }
    }
}