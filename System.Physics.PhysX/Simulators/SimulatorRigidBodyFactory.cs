using System.Physics.RigidBodies;
using System.Physics.Factories;
using System.Physics.PhysX.RigidBodies;
using System.Physics.RigidBodies;

namespace System.Physics.PhysX.Simulators
{
    public partial class PhysXSimulator
    {
        private class SimulatorRigidBodyFactory : 
            BaseMultipleFactory<IActor>, 
            IFactoryOf<IRigidBody,RigidBodyDescriptor>
        {
            private readonly PhysXSimulator _simulator;

            public SimulatorRigidBodyFactory(PhysXSimulator simulator)
            {
                _simulator = simulator;
            }

            IRigidBody IFactoryOf<IRigidBody,RigidBodyDescriptor>.Create(RigidBodyDescriptor descriptor)
            {
                return new RigidBody(descriptor,_simulator._wrappedScene);
            }
        }
    }
}
