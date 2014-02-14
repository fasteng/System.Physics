using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultCircleShape))]
    public interface ICircleShape : IShape, IDescriptible<CircleShapeDescriptor>, IStateCopier<ICircleShape>, IVisitableLeaf
    {
        float Radius
        {
            get;
            set;
        }
    }
}
