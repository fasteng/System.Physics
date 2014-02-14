using System;
using System.Collections.Generic;
using System.Linq;
using System.Physics.DigitalRune.Factories;
using System.Physics.Factories;
using System.Physics.Shapes;
using System.Text;
using DigitalRune.Geometry.Shapes;

namespace System.Physics.DigitalRune.Shapes
{
    internal partial class ShapePositioner
    {

        private class ShapePositionerShapeFactory : 
            DigitalRuneShapeFactoryBase
        {
            private ShapePositioner _shapePositioner;
            public ShapePositionerShapeFactory(ShapePositioner shapePositioner)
            {
                _shapePositioner = shapePositioner;
            }

            protected override void Store(Shape wrappedShape)
            {
                _shapePositioner.WrappedGeometricObject.Shape = wrappedShape;
            }
        }
    }
}
