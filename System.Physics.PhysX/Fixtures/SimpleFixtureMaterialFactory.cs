using System;
using System.Collections.Generic;
using System.Linq;
using System.Physics.Factories;
using System.Physics.Fixtures;
using System.Physics.Materials;
using System.Text;
using StillDesign.PhysX;
using Material = System.Physics.PhysX.Materials.Material;

namespace System.Physics.PhysX.Fixtures
{
    public partial class SimpleFixture : BaseSimpleFixture, ISeteableRealPose
    {
        internal class SimpleFixtureMaterialFactory : BaseSingleFactory<IMaterial>,
                                                     IFactoryOf<IMaterial, MaterialDescriptor>
        {
            private SimpleFixture _simpleFixture;
            internal StillDesign.PhysX.Material WrappedMaterial;

            public SimpleFixtureMaterialFactory(SimpleFixture simpleFixture)
            {
                _simpleFixture = simpleFixture;
                var defatulMaterialDescriptor = new MaterialDescriptor();
                defatulMaterialDescriptor.ToDefault();
                WrappedMaterial = simpleFixture._rigidBody.WrappedActor.Scene.CreateMaterial(new MaterialDescription());
                Element = new Material(simpleFixture._rigidBody, WrappedMaterial, defatulMaterialDescriptor);

            }

            IMaterial IFactoryOf<IMaterial, MaterialDescriptor>.Create(MaterialDescriptor descriptor)
            {
                return new Material(_simpleFixture._rigidBody, WrappedMaterial, descriptor);
            }
        }
    }
}
