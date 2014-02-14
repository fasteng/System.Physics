
using System.Collections.Generic;
using System.Physics.Factories;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;

namespace System.Physics.Shapes.DefaultImplementations
{
    public class DefaultCompositeShape : BaseCompositeShape
    {
        public DefaultCompositeShape(CompositeShapeDescriptor descriptor)
        {
            Descriptor = descriptor;
        }

        public override IMultipleFactory<IShapePositioner> ShapePositionerFactory { get; protected set; }
    }
}
