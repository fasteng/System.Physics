
using System.Collections.Generic;
using System.Physics.Factories;
using System.Physics.Shapes;
using System.Physics.Shapes.BaseImplementations;
using System.Physics.Shapes.Descriptors;
using DigitalRune.Geometry.Shapes;
using DR = DigitalRune;

namespace System.Physics.DigitalRune.Shapes
{
    public partial class CompositeShape : BaseCompositeShape, IDigitalRuneShape
    {
        internal DR.Geometry.Shapes.CompositeShape WrappedCompositeShape { get; private set; }

        public 
            CompositeShape(CompositeShapeDescriptor descriptor)
        {
            WrappedCompositeShape = new DR.Geometry.Shapes.CompositeShape();
            UserData = descriptor.UserData;
            ShapePositionerFactory = new CompositeShapeShapePositionerFactory(this);
        }

        public override IMultipleFactory<IShapePositioner> ShapePositionerFactory { get; protected set; }
    }
}
