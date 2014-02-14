using System.Physics.Simulators;

namespace System.Physics.ForceEffects
{
    public interface IForceEffect
    {
        ISimulator Simulator { get; }
        void AddedToSimulator(ISimulator simulator);
        void RemovedFromSimulator(ISimulator simulator);
        void ApplyEffect();
    }
}
