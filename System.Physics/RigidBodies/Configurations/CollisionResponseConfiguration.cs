using System.Physics.Configurations;

namespace System.Physics.RigidBodies.Configurations
{
    public struct CollisionResponseConfiguration : IConfiguration<IRigidBody>
    {
        public CollisionResponseConfiguration(bool collisionResponse) : this()
        {
            CollisionResponseEnabled = collisionResponse;
        }

        public bool CollisionResponseEnabled { get; set; }

        public void ToDefault()
        {
            CollisionResponseEnabled = true;
        }
    }
}
