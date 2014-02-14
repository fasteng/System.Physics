using System.Collections.Generic;
using System.Physics.Factories;
using System.Physics.Shapes.DefaultImplementations;
using System.Physics.Shapes.Descriptors;
using System.Physics.Visitor;

namespace System.Physics.Shapes
{
    [DefaultImplementationType(typeof(DefaultCompositeShape))]
    public interface ICompositeShape : IShape, IDescriptible<CompositeShapeDescriptor>, IStateCopier<ICompositeShape>, IVisitableTree
    {
        IMultipleFactory<IShapePositioner> ShapePositionerFactory { get; }
    }
}
