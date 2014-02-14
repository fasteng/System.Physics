using System.Collections.Generic;
using System.Maths;
using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultConvexPolyhedronShape))]
    public interface IConvexPolyhedronShape : IShape, IDescriptible<ConvexPolyhedronShapeDescriptor>, IStateCopier<IConvexPolyhedronShape>, IVisitableLeaf
    {
        
    }
}
