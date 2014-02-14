using System.Maths;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultTriangleShape : BaseTriangleShape
    {
        public DefaultTriangleShape(TriangleShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }
        public override Vector3 VertexA { get; set; }
        public override Vector3 VertexB { get; set; }
        public override Vector3 VertexC { get; set; }

        public override Vector3 Normal //todo implementar el calculo de la normal
        {
            get { throw new NotImplementedException(); }
        }
    }
}
