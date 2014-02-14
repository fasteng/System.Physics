using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Physics.Materials;
using System.Physics.PhysX.Materials;
using System.Physics.Shapes;
using System.Physics.Shapes.Descriptors;
using System.Text;

namespace System.Physics.PhysX.Fixtures
{
    public partial class SimpleFixture
    {

        internal class SimpleFixtureShapeFactory : BaseSingleFactory<IShape>,
                                                   IFactoryOf<IBoxShape, BoxShapeDescriptor>,
                                                   IFactoryOf<ISphereShape, SphereShapeDescriptor>,
                                                   IFactoryOf<IPlaneShape, PlaneShapeDescriptor>
        //,IFactoryOf<ICapsuleShape, CapsuleShapeDescriptor>
        {
            private SimpleFixture _simpleFixture;

            public SimpleFixtureShapeFactory(SimpleFixture simpleFixture)
            {
                _simpleFixture = simpleFixture;

            }

            IBoxShape IFactoryOf<IBoxShape, BoxShapeDescriptor>.Create(BoxShapeDescriptor descriptor)
            {
                return new Shapes.BoxShape(_simpleFixture._rigidBody, _simpleFixture._realPose, (Material)_simpleFixture.MaterialFactory.Element, descriptor);
            }

            ISphereShape IFactoryOf<ISphereShape, SphereShapeDescriptor>.Create(SphereShapeDescriptor descriptor)
            {
                return new Shapes.SphereShape(_simpleFixture._rigidBody, _simpleFixture._realPose, (Material)_simpleFixture.MaterialFactory.Element, descriptor);
            }

            IPlaneShape IFactoryOf<IPlaneShape, PlaneShapeDescriptor>.Create(PlaneShapeDescriptor descriptor)
            {
                return new Shapes.PlaneShape(_simpleFixture._rigidBody, _simpleFixture._realPose, (Material)_simpleFixture.MaterialFactory.Element, descriptor);
            }

            //ICapsuleShape IFactoryOf<ICapsuleShape, CapsuleShapeDescriptor>.Create(CapsuleShapeDescriptor descriptor)
            //{
            //    return new CapsuleShape(_simpleFixture._rigidBody, _simpleFixture._realPose, descriptor);
            //}
        }
    }
}