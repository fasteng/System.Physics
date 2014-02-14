using System.Collections.Generic;
using System.Physics.Configurations;
using System.Physics.Constraints;
using System.Physics.Factories;
using System.Physics.ForceEffects;
using System.Physics.Visitor;

namespace System.Physics.Simulators
{
    public abstract class BaseSimulator : ISimulator
    {
        public object UserData { get; set; }
        public void AcceptVisit(IVisitor visitor)
        {
            visitor.StartVisit<ISimulator>(this);
            ActorsFactory.AcceptVisit(visitor);
            ConstraintsFactory.AcceptVisit(visitor);
            visitor.EndVisit<ISimulator>(this);
        }

        public abstract IMultipleFactory<IActor> ActorsFactory { get; protected set; }
        public abstract IMultipleFactory<IConstraint> ConstraintsFactory { get; protected set; }
        public abstract IConfigurator<ISimulator> Configurator { get; protected set; }
        public abstract IQueries Queries { get; protected set; }

        HashSet<IForceEffect> _forceEffects = new HashSet<IForceEffect>();
        public void AddForceEffect(IForceEffect forceEffect)
        {
            _forceEffects.Add(forceEffect);
            forceEffect.AddedToSimulator(this);
        }

        public void RemoveForceEffect(IForceEffect forceEffect)
        {
            _forceEffects.Remove(forceEffect);
            forceEffect.RemovedFromSimulator(this);

        }

        public abstract void Update(float seconds);

        protected void ApplyForceEffects()
        {
            foreach (var forceEffect in _forceEffects)
            {
                forceEffect.ApplyEffect();
            }
        }
    }
}