using System.Maths;
using System.Physics.DigitalRune;
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using DigitalRune.Geometry.Shapes;

namespace System.Physics.DigitalRune.Shapes
{
    public class TriangleShape : BaseTriangleShape, IDigitalRuneShape
    {
        internal global::DigitalRune.Geometry.Shapes.TriangleShape WrappedTriangleShape {get; private set;}

        public TriangleShape(TriangleShapeDescriptor descriptor)
        {
            WrappedTriangleShape = new global::DigitalRune.Geometry.Shapes.TriangleShape(descriptor.VertexA.ToDigitalRune(), 
                                                      descriptor.VertexB.ToDigitalRune(), 
                                                      descriptor.VertexC.ToDigitalRune());
            UserData = descriptor.UserData;
        }

        public override Vector3 VertexA
        {
            get { return WrappedTriangleShape.Vertex0.ToStandard(); }
            set { WrappedTriangleShape.Vertex0 = value.ToDigitalRune(); }
        }

        public override Vector3 VertexB
        {
            get { return WrappedTriangleShape.Vertex1.ToStandard(); }
            set { WrappedTriangleShape.Vertex1 = value.ToDigitalRune(); }
        }

        public override Vector3 VertexC
        {
            get { return WrappedTriangleShape.Vertex2.ToStandard(); }
            set { WrappedTriangleShape.Vertex2 = value.ToDigitalRune(); }
        }

        public override Vector3 Normal 
        {
            get { return Normal; }
        }
    }
}
