using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultCylinderShape))]
    public interface ICylinderShape : IShape, IDescriptible<CylinderShapeDescriptor>, IStateCopier<ICylinderShape>, IVisitableLeaf
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
