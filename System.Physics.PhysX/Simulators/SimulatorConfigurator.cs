using System.Physics.Configurations;
using System.Physics.Simulators;
using System.Physics.Simulators.Configurations;
using StillDesign.PhysX;

namespace System.Physics.PhysX.Simulators
{
    public partial class PhysXSimulator
    {
        private class SimulatorConfigurator :
            BaseConfigurator<ISimulator>
            //,IConfiguratorOf<ISimulator, CcdConfiguration>
        {
            private readonly PhysXSimulator _simulator;

            public SimulatorConfigurator(PhysXSimulator simulator)
            {
                _simulator = simulator;
            }

            //public void Set(CcdConfiguration configuration)
            //{
            //    _simulator._wrappedCore.SetParameter(PhysicsParameter.ContinuousCollisionDetection, configuration.CcdEnabled);
            //    _simulator._wrappedCore.SetParameter(PhysicsParameter.ContinuousCollisionDetectionEpsilon, 10);
            //}
        }
    }
}
