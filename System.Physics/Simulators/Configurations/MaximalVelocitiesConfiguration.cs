using System.Physics.Configurations;

namespace System.Physics.Simulators.Configurations
{
    public struct MaximumVelocitiesConfiguration : IConfiguration<ISimulator>
    {
        public float MaximumAngularVelocity { get; set; }
        public float MaximumLinearVelocity { get; set; }
        public void ToDefault()
        {
            throw new NotImplementedException();
        }
    }
}
