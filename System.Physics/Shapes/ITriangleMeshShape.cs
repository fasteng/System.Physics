using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultTriangleMeshShape))]
    public interface ITriangleMeshShape : IShape, IDescriptible<TriangleMeshShapeDescriptor>, IStateCopier<ITriangleMeshShape>, IVisitableLeaf
    {
    }
}
