using System.Maths;
using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultLineSegmentShape))]
    public interface ILineSegmentShape : IShape, IDescriptible<LineSegmentShapeDescriptor>, IStateCopier<ILineSegmentShape>,IVisitableLeaf
    {
        Vector3 StartPoint
        {
            get;
            set;
        }

        Vector3 EndPoint
        {
            get;
            set;
        }

        float Length
        {
            get;
        }

        float LengthSquared
        {
            get;
        }
    }
}
