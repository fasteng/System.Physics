using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultBoxShape))]
    public interface IBoxShape : IShape, IDescriptible<BoxShapeDescriptor>, IStateCopier<IBoxShape>, IVisitableLeaf
    {
        float WidthX
        {
            get;
            set;
        }

        float WidthY
        {
            get;
            set;
        }

        float WidthZ
        {
            get;
            set;
        }
    }
}
