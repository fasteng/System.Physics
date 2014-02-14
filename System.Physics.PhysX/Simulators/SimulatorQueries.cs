using System.Physics.Simulators;

namespace System.Physics.PhysX.Simulators
{
    public partial class PhysXSimulator
    {
        private class SimulatorQueries : IQueries
        {
            private readonly PhysXSimulator _simulator;

            public SimulatorQueries(PhysXSimulator simulator)
            {
                _simulator = simulator;
            }
        }
    }
}
