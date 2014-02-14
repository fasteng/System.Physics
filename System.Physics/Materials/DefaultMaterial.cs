using System.Physics.Configurations;

namespace System.Physics.Materials
{
    public class DefaultMaterial : BaseMaterial
    {
        public DefaultMaterial()
        {
            //todo gestionar el descriptor
            //todo gestionar el configurator
            //Configurator = new BaseConfigurator();
        }

        public override IConfigurator<IMaterial> Configurator { get; protected set; }
    }
}
