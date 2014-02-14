using System;
using System.Collections.Generic;
using System.Linq;
using System.Physics.Factories;
using System.Text;

namespace System.Physics.DigitalRune.Shapes
{
    public partial class CompositeShape
    {
        private class CompositeShapeShapePositionerFactory :
            BaseMultipleFactory<IShapePositioner>,
            IFactoryOf<IShapePositioner, ShapePositionerDescriptor>
        {
            CompositeShape _compositeShape;
            public CompositeShapeShapePositionerFactory(CompositeShape compositeShape)
            {
                _compositeShape = compositeShape;
            }

            public IShapePositioner Create(ShapePositionerDescriptor descriptor)
            {
                var shapePositioner = new ShapePositioner(descriptor);
                _compositeShape.WrappedCompositeShape.Children.Add(shapePositioner.WrappedGeometricObject);
                return shapePositioner;
            }
        }
    }
}
