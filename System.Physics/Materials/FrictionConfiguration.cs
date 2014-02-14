using System.Physics.Configurations;

namespace System.Physics.Materials
{
    public struct FrictionConfiguration : IConfiguration<IMaterial>
    {
        public FrictionConfiguration(float friction)
            : this()
        {
            Friction = friction;
        }

        public float Friction { get; set; }

        public void ToDefault()
        {
            Friction = 0.5f;
        }
    }
}