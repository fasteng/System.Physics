using System.Maths;
using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultPlaneShape))]
    public interface IPlaneShape : IShape, IDescriptible<PlaneShapeDescriptor>, IStateCopier<IPlaneShape>, IVisitableLeaf
    {
        Vector3 Normal
        {
            get;
            set;
        }

        float DistanceFromOrigin { get; set; }
    }
}
