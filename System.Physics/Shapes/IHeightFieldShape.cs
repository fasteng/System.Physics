using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultHeightFieldShape))]
    public interface IHeightFieldShape : IShape, IDescriptible<HeightFieldShapeDescriptor>, IStateCopier<IHeightFieldShape>, IVisitableLeaf
    {
    }
}
