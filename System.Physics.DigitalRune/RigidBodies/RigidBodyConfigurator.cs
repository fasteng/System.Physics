using System.Physics.RigidBodies;
using System.Physics.RigidBodies.Configurations;
using System.Physics.Configurations;

namespace System.Physics.DigitalRune.RigidBodies
{
    public  partial class RigidBody
    {
        private class RigidBodyConfigurator : 
            BaseConfigurator<IRigidBody>,
            IConfiguratorOf<IRigidBody, SleepingConfiguration>,
            IConfiguratorOf<IRigidBody, CcdConfiguration>,
            IConfiguratorOf<IRigidBody, LockRotationConfiguration>,
            IConfiguratorOf<IRigidBody, CollisionResponseConfiguration> 
        {
            private readonly RigidBody _rigidBody;

            public RigidBodyConfigurator(RigidBody rigidBody)
            {
                _rigidBody = rigidBody;
            }

            public void Set(SleepingConfiguration configuration)
            {
                if (configuration.CanSleep)
                {
                    _rigidBody.WrappedRigidBody.CanSleep = true;
                    if (configuration.IsSleeping)
                    {
                        _rigidBody.WrappedRigidBody.Sleep();
                    }
                    else
                    {
                        _rigidBody.WrappedRigidBody.WakeUp();
                    }
                }
                else if(configuration.IsSleeping)
                {
                    throw new ArgumentException("The argument 'configuration' is invalid, the properties 'CanSleep' and 'IsSleeping' can't be both 'true'.");
                }
            }

            public void Set(CcdConfiguration configuration)
            {
                _rigidBody.WrappedRigidBody.CcdEnabled = configuration.CcdEnabled;
            }

            public void Set(LockRotationConfiguration configuration)
            {
                _rigidBody.WrappedRigidBody.LockRotationX = configuration.LockRotationX;
                _rigidBody.WrappedRigidBody.LockRotationY = configuration.LockRotationY;
                _rigidBody.WrappedRigidBody.LockRotationZ = configuration.LockRotationZ;
            }

            public void Set(CollisionResponseConfiguration configuration)
            {
                _rigidBody.WrappedRigidBody.CollisionResponseEnabled = configuration.CollisionResponseEnabled;
            }
        }
    }
}
