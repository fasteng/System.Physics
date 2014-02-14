using System;
using System.Collections.Generic;
using System.Linq;
using System.Maths;
using System.Physics.DigitalRune.RigidBodies;
using System.Physics.DigitalRune;
using System.Physics.DigitalRune.Materials;
using System.Physics.DigitalRune.Shapes;
using System.Physics.Factories;
using System.Physics.Materials;
using System.Physics.Shapes;
using System.Physics.Shapes.Descriptors;
using System.Text;
using System.Threading.Tasks;
using DigitalRune.Geometry.Shapes;
using DigitalRune.Physics.Materials;
using IMaterial = System.Physics.Materials.IMaterial;

namespace System.Physics.DigitalRune.Fixtures
{
    internal partial class SimpleFixture
    {
        private class SimpleFixtureMaterialFactory : 
            BaseSingleFactory<IMaterial>,
            IFactoryOf<IMaterial, MaterialDescriptor>
        {
            private readonly SimpleFixture _simpleFixture;

            public 
                SimpleFixtureMaterialFactory(SimpleFixture simpleFixture)
            {
                _simpleFixture = simpleFixture;

                //create a default material
                var descriptor = new MaterialDescriptor();
                descriptor.ToDefault();
                this.CreateMaterial(descriptor);
            }

            IMaterial IFactoryOf<IMaterial, MaterialDescriptor>.Create(MaterialDescriptor descriptor)
            {
                var material = new Material(descriptor);
                SetMaterial(material);
                return material;
            }

            void SetMaterial(Material material)
            {
                if (_simpleFixture._root)
                    _simpleFixture._wrappedRigidBody.Material = material.WrappedUniformMaterial;
                else
                {
                    int index = _simpleFixture._materialCollection.IndexOf(_simpleFixture._material);
                    _simpleFixture._material = _simpleFixture._materialCollection[index] = material.WrappedUniformMaterial; 

                }
            }
        }
    }
}