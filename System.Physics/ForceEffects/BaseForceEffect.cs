using System.Physics.Simulators;

namespace System.Physics.ForceEffects
{
    public abstract class BaseForceEffect : IForceEffect
    {
        private ISimulator _simulator;
        public ISimulator Simulator
        {
            get { return _simulator; }
        }

        public void AddedToSimulator(ISimulator simulator)
        {
            _simulator = simulator;
        }

        public void RemovedFromSimulator(ISimulator simulator)
        {
            _simulator = null;
        }

        public abstract void ApplyEffect();
    }
}
