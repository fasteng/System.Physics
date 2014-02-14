using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultCapsuleShape))]
    public interface ICapsuleShape : IShape, IDescriptible<CapsuleShapeDescriptor>, IStateCopier<ICapsuleShape>, IVisitableLeaf
    {
        float Height
        {
            get;
            set;
        }

        float Radius
        {
            get;
            set;
        }
    }
}
