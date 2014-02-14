using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultSphereShape))]
    public interface ISphereShape : IShape, IDescriptible<SphereShapeDescriptor>, IStateCopier<ISphereShape>, IVisitableLeaf
    {
        float Radius { get; set; }
    }
}
