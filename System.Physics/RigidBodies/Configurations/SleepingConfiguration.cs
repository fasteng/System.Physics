using System.Physics.Configurations;

namespace System.Physics.RigidBodies.Configurations
{
    public struct SleepingConfiguration : IConfiguration<IRigidBody>
    {
        public bool IsSleeping;
        public bool CanSleep;
        public SleepingConfiguration(bool canSleep, bool isSleeping) : this()
        {
            IsSleeping = isSleeping;
            CanSleep = canSleep;
        }

        public void ToDefault()
        {
            CanSleep = true;
            IsSleeping = false;
        }
    }
}
