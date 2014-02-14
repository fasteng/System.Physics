using System.Maths;
using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultLineShape))]
    public interface ILineShape : IShape, IDescriptible<LineShapeDescriptor>, IStateCopier<ILineShape>, IVisitableLeaf
    {
        Vector3 Direction
        {
            get;
            set;
        }

        Vector3 PointOnLine
        {
            get;
            set;
        }
    }
}
