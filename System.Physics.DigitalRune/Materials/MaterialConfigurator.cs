using System;
using System.Collections.Generic;
using System.Linq;
using System.Physics.Configurations;
using System.Physics.Materials;
using System.Threading.Tasks;


namespace System.Physics.DigitalRune.Materials
{

    internal partial class Material
    {
        private class MaterialConfigurator : 
            BaseConfigurator<IMaterial>,
            IConfiguratorOf<IMaterial, FrictionConfiguration >,
            IConfiguratorOf<IMaterial, RestitutionConfiguration>
        {
            private Material _material;
            public MaterialConfigurator(Material material)
            {
                _material = material;
            }

            public void Set(FrictionConfiguration configuration)
            {
                _material.WrappedUniformMaterial.DynamicFriction = configuration.Friction;
                _material.WrappedUniformMaterial.StaticFriction = configuration.Friction;
            }

            public void Set(RestitutionConfiguration configuration)
            {
                _material.WrappedUniformMaterial.Restitution = configuration.Restitution;
            }
        }
    }
}
