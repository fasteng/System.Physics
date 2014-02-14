using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultRectangleShape))]
    public interface IRectangleShape : IShape, IDescriptible<RectangleShapeDescriptor>, IStateCopier<IRectangleShape>, IVisitableLeaf
    {
        float WidthY
        {
            get;
            set;
        }

        float WidthX
        {
            get;
            set;
        }
    }
}
