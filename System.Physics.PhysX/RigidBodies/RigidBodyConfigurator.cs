using System.Physics.RigidBodies;
using System.Physics.Configurations;
using System.Physics.RigidBodies.Configurations;

namespace System.Physics.PhysX.RigidBodies
{
    public  partial class RigidBody
    {
        private class RigidBodyConfigurator : 
            BaseConfigurator<IRigidBody>
        {
            private readonly RigidBody _rigidBody;

            public RigidBodyConfigurator(RigidBody rigidBody)
            {
                _rigidBody = rigidBody;
            }
        }
    }
}
