using System.Physics.Configurations;

namespace System.Physics.Materials
{
    public struct RestitutionConfiguration : IConfiguration<IMaterial>
    {
        public RestitutionConfiguration(float restitution) : this()
        {
            Restitution = restitution;
        }

        public float Restitution { get; set; }

        public void ToDefault()
        {
            Restitution = 0.1f;
        }
    }
}
