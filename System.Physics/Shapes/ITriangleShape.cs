using System.Maths;
using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultTriangleShape))]
    public interface ITriangleShape : IShape, IDescriptible<TriangleShapeDescriptor>, IStateCopier<ITriangleShape>, IVisitableLeaf
    {
        Vector3 VertexA
        {
            get;
            set;
        }

        Vector3 VertexB
        {
            get;
            set;
        }

        Vector3 VertexC
        {
            get;
            set;
        }

        Vector3 Normal
        {
            get;
        }
    }
}
