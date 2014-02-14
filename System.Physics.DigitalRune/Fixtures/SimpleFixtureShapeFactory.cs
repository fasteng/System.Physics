using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Physics.DigitalRune.RigidBodies;
using System.Physics.DigitalRune;
using System.Physics.DigitalRune.Factories;
using System.Physics.DigitalRune.Shapes;
using System.Physics.Factories;
using System.Physics.Shapes;
using System.Physics.Shapes.Descriptors;
using System.Text;
using System.Threading.Tasks;
using DigitalRune.Geometry.Shapes;
using DigitalRune.Geometry;

namespace System.Physics.DigitalRune.Fixtures
{
    internal partial class SimpleFixture
    {
        private class SimpleFixtureShapeFactory : 
             DigitalRuneShapeFactoryBase
        {
            private readonly SimpleFixture _simpleFixture;

            public SimpleFixtureShapeFactory(SimpleFixture simpleFixture)
            {
                _simpleFixture = simpleFixture;
            }

            protected override void Store(Shape wrappedShape)
            {
                _simpleFixture._wrappedGeometricObject.Shape = wrappedShape;
            }
        }
    }
}
