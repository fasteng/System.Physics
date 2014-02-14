using System.Physics.Configurations;
using System.Physics.Materials;
using DigitalRune.Physics.Materials;
using IMaterial = System.Physics.Materials.IMaterial;

namespace System.Physics.DigitalRune.Materials
{
    internal partial class Material : BaseMaterial
    {
        internal UniformMaterial WrappedUniformMaterial { get; private set; }
        public 
            Material(MaterialDescriptor descriptor)
        {
            WrappedUniformMaterial = new UniformMaterial();
            Configurator = new MaterialConfigurator(this);
            Descriptor = descriptor;
        }

        public override IConfigurator<IMaterial> Configurator { get; protected set; }

    }
}