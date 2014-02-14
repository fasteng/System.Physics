using System.Maths;
using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultTransformedShape))]
    public interface ITransformedShape : IShape, IDescriptible<TransformedShapeDescriptor>, IStateCopier<ITransformedShape>, IVisitableLeaf
    {

        IShape Shape
        {
            get;
            set;
        }

        Matrix4x4 Pose
        {
            get;
            set;
        }
    }
}
