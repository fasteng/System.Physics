using System.Physics.Configurations;

namespace System.Physics.RigidBodies.Configurations
{
    public struct CcdConfiguration : IConfiguration<IRigidBody>
    {
        public CcdConfiguration(bool ccdEnabled) : this()
        {
            CcdEnabled = ccdEnabled;
        }

        public bool CcdEnabled { get; set; }

        public void ToDefault()
        {
            CcdEnabled = false;
        }
    }
}
