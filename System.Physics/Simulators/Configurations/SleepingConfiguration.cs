using System.Physics.Configurations;

namespace System.Physics.Simulators.Configurations
{
    public struct SleepingConfiguration : IConfiguration<ISimulator>
    {
        public float AngularVelocityThreshold { get; set; }
        public float LinearVelocityThreshold { get; set; }
        public float TimeThreshold { get; set; }
        public void ToDefault()
        {
            throw new NotImplementedException();
        }
    }
}
