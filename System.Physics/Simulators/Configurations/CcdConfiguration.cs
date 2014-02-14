using System.Physics.Configurations;

namespace System.Physics.Simulators.Configurations
{
    public struct CcdConfiguration : IConfiguration<ISimulator>
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
