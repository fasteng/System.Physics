using System.Physics.Configurations;

namespace System.Physics.Simulators.Configurations
{
    public struct TimeStepingConfiguration : IConfiguration<ISimulator>
    {
        public float TimeStepSize { get; set; }
        public int MaxNumberOfTimeSteps { get; set; }
        public EventHandler TimeStepFinishedHandler; 
        public bool TimeStepingEnabled { get; set; }

        public void ToDefault()
        {
            throw new NotImplementedException();
        }
    }
}