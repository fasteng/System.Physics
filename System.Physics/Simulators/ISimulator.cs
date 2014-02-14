using System.Physics.ForceEffects;
using System.Physics.RigidBodies;
using System.Physics.Configurations;
using System.Physics.Constraints;
using System.Physics.Factories;
using System.Physics.Visitor;

namespace System.Physics.Simulators
{
    public interface ISimulator : IUserDataStorer, IVisitableTree
    {
        IMultipleFactory<IActor> ActorsFactory
        {
            get;
        }

        IMultipleFactory<IConstraint> ConstraintsFactory
        {
            get;
        }

        IConfigurator<ISimulator> Configurator
        {
            get;
        }

        IQueries Queries
        {
            get;
        }

        void AddForceEffect(IForceEffect forceEffect);

        void RemoveForceEffect(IForceEffect forceEffect);

        void Update(float seconds);
    }
}
