using System.Physics.Configurations;

namespace System.Physics.Simulators.Configurations
{
    public struct AllowedConstrainErrorsConfiguration :IConfiguration<ISimulator>
    {
        public float AllowedAngularDeviation { get; set; }
        public float AllowedLinearDeviation { get; set; }
        public float AllowedPenetration { get; set; }
        public void ToDefault()
        {
            throw new NotImplementedException();
        }
    }
}
