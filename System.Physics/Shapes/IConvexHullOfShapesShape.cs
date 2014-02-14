using System.Collections.Generic;
using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultConvexHullOfShapesShape))]
    public interface IConvexHullOfShapesShape : IShape, IDescriptible<ConvexHullOfShapesShapeDescriptor>, IStateCopier<IConvexHullOfShapesShape>, IVisitableLeaf
    {
        
    }
}
