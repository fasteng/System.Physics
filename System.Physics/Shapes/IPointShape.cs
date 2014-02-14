using System.Maths;
using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultPointShape))]
    public interface IPointShape : IShape, IDescriptible<PointShapeDescriptor>, IStateCopier<IPointShape>, IVisitableLeaf
    {
        Vector3 Position
        {
            get;
            set;
        }
    }
}
