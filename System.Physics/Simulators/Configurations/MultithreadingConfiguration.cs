using System.Physics.Configurations;

namespace System.Physics.Simulators.Configurations
{
    public struct MultithreadingConfiguration : IConfiguration<ISimulator>
    {
        public bool MultithreadingEnabled { get; set; }
        public void ToDefault()
        {
            throw new NotImplementedException();
        }
    }
}
