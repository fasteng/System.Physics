using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Text;
using DigitalRune.Geometry;
using DigitalRune.Geometry.Shapes;
using DigitalRune.Physics.Materials;

namespace System.Physics.DigitalRune.Fixtures
{
    public partial class CompositeFixture
    {
        public class CompositeFixtureFixtureFactory : 
            BaseMultipleFactory<IFixture>,
            IFactoryOf<ISimpleFixture, FixtureDescriptor>,
            IFactoryOf<ICompositeFixture,FixtureDescriptor>
        {
            private CompositeFixture _compositeFixture;
            public CompositeFixtureFixtureFactory(CompositeFixture compositeFixture)
            {
                _compositeFixture = compositeFixture;
            }

            ISimpleFixture IFactoryOf<ISimpleFixture, FixtureDescriptor>.Create(FixtureDescriptor descriptor)
            {
                var wrappedCompositeShape = _compositeFixture._wrappedCompositeShape;
                var wrappedCompositeMaterial = _compositeFixture._wrappedCompositeMaterial;

                var childPose = GMath.mul(descriptor.Pose , _compositeFixture._realPose);
                var geometricObject = new GeometricObject(new EmptyShape(), childPose.ToDigitalRune());

                var uniformMaterial = new UniformMaterial();
                wrappedCompositeShape.Children.Add(geometricObject);
                wrappedCompositeMaterial.Materials.Add(uniformMaterial);
                return new SimpleFixture(geometricObject, wrappedCompositeMaterial.Materials, uniformMaterial, descriptor, _compositeFixture._realPose);
            }

            ICompositeFixture IFactoryOf<ICompositeFixture, FixtureDescriptor>.Create(FixtureDescriptor descriptor)
            {
                return new CompositeFixture(_compositeFixture._wrappedCompositeShape, _compositeFixture._wrappedCompositeMaterial, _compositeFixture._realPose, descriptor);
            }
        }
    }
}
