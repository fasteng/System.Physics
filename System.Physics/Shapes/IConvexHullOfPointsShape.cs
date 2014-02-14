using System.Collections.Generic;
using System.Maths;
using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultConvexHullOfPointsShape))]
    public interface IConvexHullOfPointsShape : IShape, IDescriptible<ConvexHullOfPointsShapeDescriptor>, IStateCopier<IConvexHullOfPointsShape>, IVisitableLeaf
    {
        
    }
}
