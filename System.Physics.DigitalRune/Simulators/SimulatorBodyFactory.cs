using System.Physics.RigidBodies;
using System.Physics.DigitalRune.RigidBodies;
using System.Physics.Factories;
using System.Physics.RigidBodies;
using DigitalRune.Physics;
using DR = DigitalRune.Physics;
using Std = System.Physics;
namespace System.Physics.DigitalRune.Simulators
{
    public partial class DigitalRuneSimulator
    {
        private class SimulatorRigidBodyFactory : BaseMultipleFactory<IActor>, IFactoryOf<IRigidBody,RigidBodyDescriptor>
        {
            private readonly DigitalRuneSimulator _simulator;

            public SimulatorRigidBodyFactory(DigitalRuneSimulator simulator)
            {
                _simulator = simulator;
            }

            IRigidBody IFactoryOf<IRigidBody,RigidBodyDescriptor>.Create(RigidBodyDescriptor descriptor)
            {
                var rigidBody = new RigidBodies.RigidBody(descriptor);
                _simulator._wrappedSimulation.RigidBodies.Add(rigidBody.WrappedRigidBody);
                return rigidBody;
            }
        }
    }
}
